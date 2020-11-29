using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // Singleton instance object
    public static AnimationController instance = null;

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
    public void TriggerAnimation()
    {

    }
    public void TriggerAnotherAnimation()
    {

    }
}
