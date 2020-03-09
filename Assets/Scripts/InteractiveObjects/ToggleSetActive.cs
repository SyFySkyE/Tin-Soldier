﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject
{
    [Header("This object will be toggled off when this.GO is interacted with")]
    [SerializeField] private GameObject objectToToggle;
    [Header("Check this if player can retoggle object")]
    [SerializeField] private bool isReuseable;
    private bool hasBeenUsed = false;   
    /// <summary>
    /// Toggles Set Active on ObjectToToggle
    /// </summary>
    public override void Interact()
    {        
        if (isReuseable || !hasBeenUsed)        
        {            
            objectToToggle.SetActive(!objectToToggle.activeSelf);
            base.Interact();
            hasBeenUsed = true;
            if (!isReuseable) displayText = string.Empty;                            
        }        
    }
}
