using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelCreator : MonoBehaviour
{
    public static LevelCreator instance = null;
    // Used for creating cards in the Scene
    public GameObject CardPrefab;
    private GameManager _gameManager;

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
    private void Start()
    {
        _gameManager = GameManager.instance;
    }
    public void initializeLevel()
    {
        if (SceneManager.GetActiveScene().name.StartsWith("Level_"))
        {
            int levelNumber = int.Parse(SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 1));
            if(levelNumber == 1)
            {
                createEasyMatchLevel(8);
            } else if (levelNumber == 2)
            {
                createNormalMatchLevel(16);
            }
            else if (levelNumber == 3)
            {
                createHardMatchLevel(26);
            }
            else if (levelNumber == 4)
            {
                createMatchImageLevel(8);
            }
            else if (levelNumber == 5)
            {
                createMatchImageLevel(16);
            }
            else if (levelNumber == 6)
            {
                createMatchImageLevel(26);
            }
            else if (levelNumber == 7)
            {
                createMatchLetterLevel(8);
            }
            else if (levelNumber == 8)
            {
                createMatchLetterLevel(16);
            }
            else if (levelNumber == 9)
            {
                createMatchLetterLevel(26);
            }
        }
    }
    void createEasyMatchLevel(int cardCount)
    {
        GameObject clone;
        int index = 0;
        // Use prefab and create cards on a good location
        for(int i = 0; i < 4; i++)
        {
            clone = Instantiate(CardPrefab, new Vector3(Screen.width/4 + i * 300, 2 * Screen.height / 3, 0), Quaternion.identity, GameObject.Find("Canvas").GetComponent<Transform>());
            //_gameManager.cards.Add(clone);
            _gameManager.cards.Insert(index++,clone);
        }

        for (int i = 0; i < 4; i++)
        {
            clone = Instantiate(CardPrefab, new Vector3(Screen.width / 4 + i * 300,   Screen.height / 3, 0), Quaternion.identity,GameObject.Find("Canvas").GetComponent<Transform>());
            // _gameManager.cards.Add(clone);
            _gameManager.cards.Insert(index++, clone);
        }

        _gameManager.initializeCards(cardCount);
    }

    void createNormalMatchLevel(int cardCount)
    {
        GameObject clone;
        int index = 0;

        for (int i = 0; i < 8; i++)
        {
            clone = Instantiate(CardPrefab, new Vector3(Screen.width / 8 + i * 200, 2 * Screen.height / 3, 0), Quaternion.identity, GameObject.Find("Canvas").GetComponent<Transform>());
            clone.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            _gameManager.cards.Insert(index++, clone);
        }

        for (int i = 0; i < 8; i++)
        {
            clone = Instantiate(CardPrefab, new Vector3(Screen.width / 8 + i * 200, Screen.height / 3, 0), Quaternion.identity, GameObject.Find("Canvas").GetComponent<Transform>());
            clone.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            _gameManager.cards.Insert(index++, clone);
        }

        // _gameManager.initializeCards(cardCount);
    }
    void createHardMatchLevel(int cardCount)
    {
        GameObject clone;
        int index = 0;

        for (int i = 0; i < 5; i++)
        {
            clone = Instantiate(CardPrefab, new Vector3(43.6f + Screen.width / 4 + i * 125, 0.75f * Screen.height / 6, 0), Quaternion.identity, GameObject.Find("Canvas").GetComponent<Transform>());
            clone.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            _gameManager.cards.Insert(index++, clone);
        }

        for (int i = 0; i < 8; i++)
        {
            clone = Instantiate(CardPrefab, new Vector3(34.3f + Screen.width / 10 + i * 125, 2.25f * Screen.height / 6, 0), Quaternion.identity, GameObject.Find("Canvas").GetComponent<Transform>());
            clone.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            _gameManager.cards.Insert(index++, clone);
        }

        for (int i = 0; i < 8; i++)
        {
            clone = Instantiate(CardPrefab, new Vector3(34.3f + Screen.width / 10 + i * 125, 3.75f * Screen.height / 6, 0), Quaternion.identity, GameObject.Find("Canvas").GetComponent<Transform>());
            clone.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            _gameManager.cards.Insert(index++, clone);
        }

        for (int i = 0; i < 5; i++)
        {
            clone = Instantiate(CardPrefab, new Vector3(43.6f + Screen.width / 4 + i * 125, 5.25f * Screen.height / 6, 0), Quaternion.identity, GameObject.Find("Canvas").GetComponent<Transform>());
            clone.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            _gameManager.cards.Insert(index++, clone);
        }

        // _gameManager.initializeCards(cardCount);
    }
    void createMatchImageLevel(int cardCount)
    {
        GameObject clone;
        int index = 0;
        // Use prefab and create cards on a good location

    }
    void createMatchLetterLevel(int cardCount)
    {
        GameObject clone;
        int index = 0;
        // Use prefab and create cards on a good location
    }

}
