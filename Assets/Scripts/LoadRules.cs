using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //To enable "collaboration" between scenes. 

public class LoadRules : MonoBehaviour
{
    public void loadRules()
    {
        SceneManager.LoadScene("Rules");
    }
}
