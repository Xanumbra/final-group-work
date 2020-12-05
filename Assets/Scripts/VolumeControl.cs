using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevel(float sliderValue)

    {
        //Instead of using directly slider value (that is too sensitive), it is converted with logarythmic scale (so that our slider value between 0.0001 to 1 is converted to -80 to 0 that is audio mixer fading ranger)
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }


}
