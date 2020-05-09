using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TriggerTimeline : InteractiveObject // TODO Probably doesn't need to be an interactive. There's a few triggers like these, would have been better to subclass and use strategy
{
    [Header("Timeline to activate")]
    [SerializeField] private UnityEngine.Playables.PlayableDirector timeline;
    [SerializeField] private bool isTrigger;
    private string initialDisplayName;
    [SerializeField] private bool disableOnAwake;
    private bool isEnabled;
    protected override void Awake()
    {
        isEnabled = true;
        initialDisplayName = this.DisplayText;
        this.isReuseable = false;
        base.Awake();
        if (disableOnAwake)
        {
            this.displayText = string.Empty;
            isEnabled = false;
        }
    }

    public override void Interact()
    {
        if (isEnabled)
        {
            timeline.Play();
            base.Interact();
        }        
    }

    public void EnableInteract()
    {
        this.displayText = initialDisplayName;
        isEnabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isTrigger)
            this.Interact();
    }
}
