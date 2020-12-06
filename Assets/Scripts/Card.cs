using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public static bool CAN_FLIP = true;
    public int CardValue { get; set; }
    public int State { get; set; }
    public bool Initialized { get; set; }
    public Sprite CardFace { get; set; }
    public Sprite CardBack { get; set; }

    private void Start()
    {
        State = 0;
        CAN_FLIP = true;
    }
    public void flipCard()
    {
        if(Time.timeScale != 0)
        {
            if (State == 1 && CAN_FLIP)
                State = 0;
            else if (State == 0 && CAN_FLIP)
                State = 1;

            if (State == 0 && CAN_FLIP)
            {
                GetComponent<Image>().sprite = CardBack;
            }
            else if (State == 1 && CAN_FLIP)
            {
                GetComponent<Image>().sprite = CardFace;
                AudioController.instance.playOnFlipCardSound();
            }
        }
        
    }

    public void falseCheck()
    {
        StartCoroutine(pause());
    }
    IEnumerator pause()
    {
        yield return new WaitForSeconds(1);
        if (State == 0)
        {
            GetComponent<Image>().sprite = CardBack;
        }
        else if (State == 1)
        {
            GetComponent<Image>().sprite = CardFace;
        }
        CAN_FLIP = true;
    }

}
