using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTimeline : InteractiveObject // TODO Probably doesn't need to be an interactive. There's a few triggers like these, would have been better to subclass and use strategy
{
    [Header("Timeline to activate")]
    [SerializeField] private UnityEngine.Playables.PlayableDirector timeline;
    [SerializeField] private bool isTrigger;

    protected override void Awake()
    {
        this.isReuseable = false;
        base.Awake();
    }

    public override void Interact()
    {
        timeline.Play();
        base.Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isTrigger)
            this.Interact();
    }
}
