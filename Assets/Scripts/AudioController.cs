using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance = null;

    public AudioSource audio;

    public List<AudioClip> clipArray = new List<AudioClip>();

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
    public void playMatchCardSound()
    {
        audio.PlayOneShot(clipArray[0], 0.2f);
    }

    public void playMismatchCardSound()
    {
        audio.PlayOneShot(clipArray[1], 0.2f);
    }

    public void playOnButtonPressSound()
    {
        audio.PlayOneShot(clipArray[2]);
    }

    public void playOnFlipCardSound()
    {
        audio.PlayOneShot(clipArray[3]);
    }
}
