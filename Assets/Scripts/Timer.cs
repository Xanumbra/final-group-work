using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public GameObject GameOverTextPrefab;
    public Text timeText;

    private void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                GameOver();
            }
        }
        
        
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        Instantiate(GameOverTextPrefab, new Vector3(Screen.width / 2, Screen.height / 2,0), Quaternion.identity, GameObject.Find("Canvas").GetComponent<Transform>());
        Time.timeScale = 0f;
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(3);
        SceneController.instance.loadMainMenu();
    }
}
