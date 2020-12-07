using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
/* Card.cs
 * Class to define basic gameobject used in game levels.
 * It has specific attributes that makes it functional:
 *  CardValue to define which card face it will have
 *  State to define if the card is facing up or down
 *  Initialized to check if it is created or not
 *  CardFace to hold the Sprite for its front
 *  CardBack to hold the Sprite for its back
 */
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
    /* This method is the main method on the object that is triggered with OnClick() event.
     */
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
