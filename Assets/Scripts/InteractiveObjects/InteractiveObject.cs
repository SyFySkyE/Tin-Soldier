using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Player interacted with " + this.name);
    }
}
