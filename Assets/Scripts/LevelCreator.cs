using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelCreator : MonoBehaviour
{
    // Used for creating cards in the Scene
    public GameObject CardPrefab;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GetComponent<GameManager>();
        initializeLevel();
    }
    void initializeLevel()
    {
        if (SceneManager.GetActiveScene().name.StartsWith("Level_"))
        {
            int levelNumber = int.Parse(SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 1));
            if(levelNumber == 1)
            {
                createMatchLevel(8);
            } else if (levelNumber == 2)
            {
                createMatchLevel(16);
            }
            else if (levelNumber == 3)
            {
                createMatchLevel(26);
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
    void createMatchLevel(int cardCount)
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
