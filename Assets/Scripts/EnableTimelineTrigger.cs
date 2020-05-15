using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnableTimelineTrigger : MonoBehaviour
{
    [SerializeField] private GameObject objectWithTriggerTimeline;
    private TriggerTimeline triggerTimelineToEnable;

    private void Awake()
    {
        triggerTimelineToEnable = objectWithTriggerTimeline.GetComponent<TriggerTimeline>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerTimelineToEnable.EnableInteract();
        }
    }
}
