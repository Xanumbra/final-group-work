using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{

    public static DontDestroyAudio instance = null;

    // Background audio continues to play after changing the scene
    void Awake()
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
}
