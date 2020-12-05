using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    // Assigne my game object that i want to open
    public GameObject VolumeSliderPanel;

    public void OpenPanel()
    {
        // I will check if game object is assigned or not (not = null) 
        if (VolumeSliderPanel != null)
        {
            // I will ask if panel is active. 
            bool isActive = VolumeSliderPanel.activeSelf;

            // Toggle active state of a panel.
            VolumeSliderPanel.SetActive(!isActive);
        
        }
    
    }


   
}
