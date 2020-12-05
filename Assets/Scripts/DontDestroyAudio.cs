using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{
    // Background audio continues to play after changing the scene
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);        
    }
}
