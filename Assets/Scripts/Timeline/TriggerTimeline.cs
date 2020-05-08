using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTimeline : InteractiveObject
{
    [Header("Timeline to activate")]
    [SerializeField] private UnityEngine.Playables.PlayableDirector timeline;

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
        if (other.CompareTag("Player"))
            this.Interact();
    }
}
