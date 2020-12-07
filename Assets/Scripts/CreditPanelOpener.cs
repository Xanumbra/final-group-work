using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditPanelOpener : MonoBehaviour
{
    // I will asign what is the game object I'm refering in this script
    public GameObject CreditsPanel;

    // I create new public method to open Credits panel.
    public void OpenCreditsPanel()
    {
        // Here I'll check if this panel is opened or not
        if (CreditsPanel != null)
        {
            // I'll ask if Credit's Panel is active 
            bool isActive = CreditsPanel.activeSelf;

            //I will toggle active state if activeSelf-method is called
            CreditsPanel.SetActive(!isActive);
        }
        
    }

   
}
