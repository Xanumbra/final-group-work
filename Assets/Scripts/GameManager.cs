using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static LevelCreator;
/* Game Manager
 * Singleton Class responsible for managing systems in order to create levels and trigger actions.
 * It has some attributes to help it with game management
 *  CardFaces and CardFacesPairs are used as containers for images to be used.
 *  CardBack is a container for Card Back Image.
 *  cards are used as a GameObject contrainer to interact with cards spawned on the Scene
 *  totalCardCount to store amount of cards spawned in a scene
 *  orders to create a random order for cards so they are random when the player plays the game
 *  usePairsArr to determine if the cardFacesPairs will be used
 *  score to determine the ending condition
 */
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public Sprite[] cardFaces;
    public Sprite[] cardFacesPairs;
    public Sprite cardBack;
    public List<GameObject> cards;
    public int totalCardCount;
    public int[] orders;
    public bool usePairsArr = false;

    [SerializeField]
    private int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            checkCards();
        }
            
    }
    public Sprite getCardBack()
    {
        return cardBack;
    }
    public Sprite getCardFace(int i)
    {
        return cardFaces[i];
    }
    public Sprite getCardFacePair(int i)
    {
        return cardFacesPairs[i];
    }
    void swap(int[] arr, int a, int b)
    {
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }
    void shuffleArr(int[] arr)
    {
        int i, j;
        for (i = arr.Length - 1; i >= 0; i--)
        {
            j = Random.Range(0, i);
            swap(arr, i, j);
        }
    }
    int[] initializeOrderArray(int[] arr, int cardCount)
    {
        orders = new int[cardCount];
        for (int i = 0; i < cardCount; i++)
        {
            orders[i] = i; // 0 1 2 3 4 5 6 7 ... until cardCount
        }
        return arr;
    }
    public void initializeCards(LevelType type)
    {
        totalCardCount = instance.cards.Count;
        initializeOrderArray(orders, totalCardCount);
        shuffleArr(orders);
        initializeCardValues();
        if (type.Equals(LevelType.MatchSame))
        {
            setupGraphics(cards);
        }
        else
        {
            setupGraphicsUsingDifferentPairs(cards);
        }


    }
    public void initializeCardValues()
    {
        for (int i = 0; i < totalCardCount; i++)
        {
            int choice = orders[i];
            cards[choice].GetComponent<Card>().CardValue = i % (totalCardCount / 2);
            cards[choice].GetComponent<Card>().Initialized = true;
        }
    }
    /*
     * This method find the pairs by checking the Array from the beginning first
     * and then from the end of the array.
     * This algorithm helps us to find the pairs accurately and determine their faces.
     */
    public void setupGraphicsUsingDifferentPairs(List<GameObject> cards)
    {
        for (int i = 0; i < cards.Count / 2; i++)
        {
            for (int j = 0; j < cards.Count; j++)
            {
                if (cards[j].GetComponent<Card>().CardValue == i)
                {
                    cards[j].GetComponent<Card>().CardBack = cardBack;
                    cards[j].GetComponent<Card>().CardFace = getCardFace(i);
                }
            }
        }

        for (int i = 0; i < cards.Count / 2; i++)
        {
            for (int j = cards.Count - 1; j >= 0; j--)
            {
                if (cards[j].GetComponent<Card>().CardValue == i)
                {
                    cards[j].GetComponent<Card>().CardBack = cardBack;
                    cards[j].GetComponent<Card>().CardFace = getCardFacePair(i);
                }
            }
        }
    }
    public void setupGraphics(List<GameObject> cards)
    {
        foreach (GameObject c in cards)
        {
            c.GetComponent<Card>().CardBack = cardBack;
            c.GetComponent<Card>().CardFace = getCardFace(c.GetComponent<Card>().CardValue);
        }
    }
    void checkCards()
    {
        List<int> c = new List<int>();
        int index = 0;
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].GetComponent<Card>().State == 1)
            {
                // Debug.Log("Inserted " + i + " at index " + index);
                c.Insert(index++, i);
            }
        }

        if (c.Count == 2)
            cardComparison(c);
    }
    /*
     * This method is the main method that makes it possible to compare cards
     * If cards are the same, they are destroyed and score is increased.
     * If the cards are not the same, they are flipped
     */
    void cardComparison(List<int> c)
    {
        Card.CAN_FLIP = false;

        int x = 0;

        if (cards[c[0]].GetComponent<Card>().CardValue == cards[c[1]].GetComponent<Card>().CardValue)
        {
            AudioController.instance.playMatchCardSound();
            score += 100;
            DestroyCard(c[0]);
            DestroyCard(c[1] - 1);
            AnimationController.instance.animator.SetTrigger("Correct");
            if (score == 100 * (totalCardCount / 2))
            {
                score = 0;
                if (SceneManager.GetActiveScene().name.Equals("Level_9"))
                {
                    SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
                }

            }
        }
        else
        {
            AudioController.instance.playMismatchCardSound();
            for (int i = 0; i < c.Count; i++)
            {
                cards[c[i]].GetComponent<Card>().State = x;
                cards[c[i]].GetComponent<Card>().falseCheck();
            }
        }
        Card.CAN_FLIP = true;
    }
    void DestroyCard(int index)
    {
        GameObject toBeDestroyed;
        toBeDestroyed = cards[index];
        cards.Remove(cards[index]);
        Destroy(toBeDestroyed, 1.0f);
    }
}
