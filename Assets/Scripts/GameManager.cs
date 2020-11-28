using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     
    public Sprite[] cardFaces;
    public Sprite[] cardFacesPairs;
    public Sprite cardBack;
    public List<GameObject> cards;
    public int totalCardCount;
    // public Text matchText;
    public int[] orders;

    private Component _levelCreator;

    [SerializeField]
    private int score = 0;

    public void Start()
    {
        DontDestroyOnLoad(this);
        _levelCreator = this.GetComponent<LevelCreator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            checkCards();
    }
    void swap(int[] arr, int a, int b)
    {
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }
    void shuffleArr(int[] arr)
    {
        int i,j;
        for(i = arr.Length - 1; i >= 0; i--)
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
            orders[i] = i; // 0 1 2 3 4 5 6 7 ...
        }
        return arr;
    }
    public void initializeCards(int cardCount)
    {
        totalCardCount = cardCount;
        // create orders array for mixing cards
        initializeOrderArray(orders, cardCount);
        // Shuffle order array
        shuffleArr(orders);
        for(int i = 0; i < cardCount; i++)
        {
            int choice = orders[i];
            cards[choice].GetComponent<Card>().CardValue = i % (cardCount/2);
            cards[choice].GetComponent<Card>().Initialized = true;
        }
        setupGraphics(cards);
    }
    public void setupGraphics(List<GameObject> cards)
    {
        foreach (GameObject c in cards)
        {
            c.GetComponent<Card>().CardBack = cardBack;
            c.GetComponent<Card>().CardFace = getCardFace(c.GetComponent<Card>().CardValue);
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
    void checkCards()
    {
        List<int> c = new List<int>();
        int index = 0;
        for(int i = 0; i < cards.Count; i++)
        {
            if(cards[i].GetComponent<Card>().State == 1)
            {
                Debug.Log("Inserted " + i + " at index " + index);
                c.Insert(index++, i);
            }
        }

        if (c.Count == 2)
            cardComparison(c);
    }
    void cardComparison(List<int> c)
    {
        Card.CAN_FLIP = false;

        int x = 0;
        int tempCardValue;
        
        if(cards[c[0]].GetComponent<Card>().CardValue == cards[c[1]].GetComponent<Card>().CardValue)
        {
            // Debug.Log("Cards are matched! "+cards[c[0]].GetComponent<Card>().CardFace.name + " and " + cards[c[1]].GetComponent<Card>().CardFace.name);
            x = 2;
            score += 100;
            tempCardValue = cards[c[0]].GetComponent<Card>().CardValue;
            // Debug.Log("Removing cards at indexes " + c[0] + " and " + c[1]);
            DestroyCard(c[0]);
            DestroyCard(c[1] - 1);
            // Add animation trigger here so that Animation happens when cards are matched.
            Debug.Log("Score: " + score);
            if (score == 100 * (totalCardCount / 2))
            {
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            }  
        }
        else
        {
            
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
