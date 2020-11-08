using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int CARD_COUNT = 8; // Change this according to # of cards in the level.
    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;
    public Text matchText;
    public int[] choices;

    private bool _init = false;
    private int score = 0;

    private void Update()
    {
        if (!_init)
            initializeCards();
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
    void initializeCards()
    {
        choices = new int[CARD_COUNT];
        for(int i = 0; i < CARD_COUNT; i++)
        {
            choices[i] = i; // 0 1 2 3 4 5 6 7 ...
        }
        shuffleArr(choices);


        for(int i = 0; i < CARD_COUNT; i++)
        {
            // 0 1 2 3 4 5 6 7 
            // 4 5 7 2 1 3 0 6

            // 4 % 4 -> 0
            // 5 % 4 -> 1
            // 7 % 4 -> 3
            // 2 % 4 -> 2

            // 1 % 4 -> 1
            // 3 % 4 -> 3
            // 0 % 4 -> 0
            // 6 % 4 -> 2

            int choice = choices[i];
            cards[choice].GetComponent<Card>().cardValue = i % (CARD_COUNT/2);
            cards[choice].GetComponent<Card>().initialized = true;
        }

        foreach (GameObject c in cards)
        {
            c.GetComponent<Card>().setupGraphics();
        }
        if (!_init)
            _init = true;
    }

    public Sprite getCardBack()
    {
        return cardBack;
    }
    public Sprite getCardFace(int i)
    {
        return cardFace[i];
    }
    void checkCards()
    {
        List<int> c = new List<int>();

        for(int i = 0; i < cards.Length; i++)
        {
            if(cards[i].GetComponent<Card>().state == 1)
            {
                c.Add(i);
            }
        }

        if (c.Count == 2)
            cardComparison(c);
    }
    void cardComparison(List<int> c)
    {
        Card.CANT_FLIP = true;

        int x = 0;

        if(cards[c[0]].GetComponent<Card>().cardValue == cards[c[1]].GetComponent<Card>().cardValue)
        {
            x = 2;
            score += 100;
            // Add animation trigger here so that Animation happens when cards are matched.

            if (score == 100 * (CARD_COUNT/2))
                SceneManager.LoadScene("MainMenu");
        }

        for(int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().state = x;
            cards[c[i]].GetComponent<Card>().falseCheck();
        }

    }
}
