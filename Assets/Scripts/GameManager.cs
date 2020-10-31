using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int CARD_COUNT = 8;
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
    void shuffleArr(int[] arr)
    {
        int i,j,temp;
        for(i = arr.Length - 1; i >= 0; i--)
        {
            j = Random.Range(0, i);
            temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
    void initializeCards()
    {
        choices = new int[CARD_COUNT];
        for(int i = 0; i < CARD_COUNT; i++)
        {
            choices[i] = i;
        }
        shuffleArr(choices);


        for(int i = 0; i < CARD_COUNT; i++)
        {
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
            if (score == 400)
                SceneManager.LoadScene("MainMenu");
        }

        for(int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().state = x;
            cards[c[i]].GetComponent<Card>().falseCheck();
        }

    }
}
