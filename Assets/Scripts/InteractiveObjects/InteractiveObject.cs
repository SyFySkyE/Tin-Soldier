using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour, IInteractable
{
    [Header("What UI Text will display when camera hovers over this object")]
    [SerializeField] private string displayText = "Interactive";
    public string DisplayText => this.displayText;

    private void Start()
    {
        this.tag = "Interactable";
    }

    public void Interact()
    {
        Debug.Log("Player interacted with " + this.name);
    }
}
