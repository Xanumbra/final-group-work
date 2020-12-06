using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance = null;

    public AudioSource audioSource;

    public float volume = 0.5f;
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
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playFlipCardSound()
    {
        audioSource.PlayOneShot(clipArray[0], volume);
    }
    public void playMatchCardSound()
    {
        audioSource.PlayOneShot(clipArray[1], volume);
    }

    public void playMismatchCardSound()
    {
        audioSource.PlayOneShot(clipArray[2], volume);
    }

    public void playOnButtonPressSound()
    {
        audioSource.PlayOneShot(clipArray[3], volume);
    }



}
