using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameOnClickCard : MonoBehaviour
{

    public Sprite cardBack;
    public Sprite cardFace;
    public bool isClicked = false;
    // Start is called before the first frame update

    public void flipEndGameCard()
    {
        if (!isClicked)
        {
            GetComponent<Image>().sprite = cardFace;
            isClicked = true;
        }
    }
}
