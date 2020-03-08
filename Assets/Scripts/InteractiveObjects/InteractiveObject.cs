using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractable
{
    [Header("What UI Text will display when camera hovers over this object")]
    [SerializeField] private string displayText = nameof(InteractiveObject);
    public string DisplayText => this.displayText;
    private AudioSource objAudioSource;

    private void Awake()
    {
        objAudioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        Debug.Log("Player interacted with " + this.name);
        objAudioSource.Play();
    }
}
