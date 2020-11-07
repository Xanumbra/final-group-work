using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void loadSceneSingle(int index)
    {
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }
    public void loadLevel_1()
    {
        // Debug.Log("Loading Level 1...");
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }
    public void loadMainMenu()
    {
        // Debug.Log("Loading Main Menu");
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
