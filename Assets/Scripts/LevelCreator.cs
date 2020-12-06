using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelCreator : MonoBehaviour
{
    public static LevelCreator instance = null;
    // Used for creating cards in the Scene
    public GameObject CardPrefab;
    public GameObject TimerPrefab;
    private GameManager _gameManager;
    public enum LevelType { MatchSame, MatchImageWithWord, MatchImageWithLetter };

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
            if (levelNumber == 1)
            {
                createEasyMatchLevel(LevelType.MatchSame);
                initializeTimer(5);
            }
            else if (levelNumber == 2)
            {
                createNormalMatchLevel(LevelType.MatchSame);
                initializeTimer(120);
            }
            else if (levelNumber == 3)
            {
                createHardMatchLevel(LevelType.MatchSame);
                initializeTimer(240);
            }
            else if (levelNumber == 4)
            {
                createEasyMatchLevel(LevelType.MatchImageWithWord);
                initializeTimer(50);
            }
            else if (levelNumber == 5)
            {
                createNormalMatchLevel(LevelType.MatchImageWithWord);
                initializeTimer(120);
            }
            else if (levelNumber == 6)
            {
                createHardMatchLevel(LevelType.MatchImageWithWord);
                initializeTimer(240);
            }
            else if (levelNumber == 7)
            {
                createEasyMatchLevel(LevelType.MatchImageWithLetter);
                initializeTimer(50);
            }
            else if (levelNumber == 8)
            {
                createNormalMatchLevel(LevelType.MatchImageWithLetter);
                initializeTimer(120);
            }
            else if (levelNumber == 9)
            {
                createHardMatchLevel(LevelType.MatchImageWithLetter);
                initializeTimer(240);
            }
        }
    }
    void createEasyMatchLevel(LevelType type)
    {
        GameObject clone;
        int index = 0;
        // Use prefab and create cards on a good location
        for (int i = 0; i < 4; i++)
        {
            clone = Instantiate(CardPrefab, new Vector3(Screen.width / 4 + i * 300, 2 * Screen.height / 3, 0), Quaternion.identity, GameObject.Find("Canvas").GetComponent<Transform>());
            //_gameManager.cards.Add(clone);
            _gameManager.cards.Insert(index++, clone);
        }

        for (int i = 0; i < 4; i++)
        {
            clone = Instantiate(CardPrefab, new Vector3(Screen.width / 4 + i * 300, Screen.height / 3, 0), Quaternion.identity, GameObject.Find("Canvas").GetComponent<Transform>());
            // _gameManager.cards.Add(clone);
            _gameManager.cards.Insert(index++, clone);
        }

        _gameManager.initializeCards(type);
    }

    void createNormalMatchLevel(LevelType type)
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

        _gameManager.initializeCards(type);
    }
    void createHardMatchLevel(LevelType type)
    {
        GameObject clone;
        int index = 0;

        for (int i = 0; i < 5; i++)
        {
            clone = Instantiate(CardPrefab, new Vector3(43.6f + Screen.width / 4 + i * 200, 0.75f * Screen.height / 6, 0), Quaternion.identity, GameObject.Find("Canvas").GetComponent<Transform>());
            clone.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            _gameManager.cards.Insert(index++, clone);
        }

        for (int i = 0; i < 8; i++)
        {
            clone = Instantiate(CardPrefab, new Vector3(34.3f + Screen.width / 10 + i * 200, 2.25f * Screen.height / 6, 0), Quaternion.identity, GameObject.Find("Canvas").GetComponent<Transform>());
            clone.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            _gameManager.cards.Insert(index++, clone);
        }

        for (int i = 0; i < 8; i++)
        {
            clone = Instantiate(CardPrefab, new Vector3(34.3f + Screen.width / 10 + i * 200, 3.75f * Screen.height / 6, 0), Quaternion.identity, GameObject.Find("Canvas").GetComponent<Transform>());
            clone.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            _gameManager.cards.Insert(index++, clone);
        }

        for (int i = 0; i < 5; i++)
        {
            clone = Instantiate(CardPrefab, new Vector3(43.6f + Screen.width / 4 + i * 200, 5.25f * Screen.height / 6, 0), Quaternion.identity, GameObject.Find("Canvas").GetComponent<Transform>());
            clone.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            _gameManager.cards.Insert(index++, clone);
        }

        _gameManager.initializeCards(type);
    }

    void initializeTimer(float time)
    {
        GameObject timer;
        timer = Instantiate(TimerPrefab, new Vector3(Screen.width - TimerPrefab.GetComponent<RectTransform>().rect.width / 2, Screen.height - TimerPrefab.GetComponent<RectTransform>().rect.height / 2, 0), Quaternion.identity, GameObject.Find("Canvas").GetComponent<Transform>());
        timer.GetComponent<Timer>().timeRemaining = time;
    }
}
