using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractable
{
    [Header("What UI Text will display when camera hovers over this object")]
    [SerializeField] protected string displayText = nameof(InteractiveObject);
    [Header("Check this if player can retoggle object")]
    [SerializeField] protected bool isReuseable;
    protected bool hasBeenUsed = false;
    public string DisplayText => this.displayText;
    protected AudioSource objAudioSource;

    public static event System.Action OnLookedAtStateChange;

    protected virtual void Awake()
    {
        objAudioSource = GetComponent<AudioSource>();
    }

    public virtual void Interact()
    {        
        if (isReuseable || !hasBeenUsed)
        {
            objAudioSource.Play();
            hasBeenUsed = true;
            if (!this.isReuseable)
            {                
                displayText = string.Empty;                
                OnLookedAtStateChange?.Invoke(); // If the object changes state, look at new display text
            }
        }
    }

    protected void StateChange()
    {
        OnLookedAtStateChange?.Invoke();
    }
}
