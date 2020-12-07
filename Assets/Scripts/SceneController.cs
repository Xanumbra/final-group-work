using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * SceneController 
 * Singleton Class responsible for changing the scene from one to another 
 */
public class SceneController : MonoBehaviour
{
    public static SceneController instance = null;

    private GameObject _gameManager;
    private bool isInitialized = false;


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
        _gameManager = GameManager.instance.gameObject;
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    {
            _gameManager.GetComponent<LevelCreator>().initializeLevel();
    }
    public void loadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Single);
    }
    public void loadLevel_1()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
        
    }
    public void loadMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void exitApplication()
    {
        Application.Quit();
    }
}
