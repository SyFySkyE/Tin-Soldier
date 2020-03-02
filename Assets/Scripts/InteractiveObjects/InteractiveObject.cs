using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour, IInteractable
{
    private void Start()
    {
        this.tag = "Interactable";
    }

    public void Interact()
    {
        Debug.Log("Player interacted with " + this.name);
    }
}
