using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerUnityTrigger : MonoBehaviour, ITrigger
{
    private Collider triggerCollider;

    public virtual event Action OnTrigger;

    void Start()
    {
        triggerCollider = GetComponent<Collider>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.CompareTag("Player"))
        {
            OnTrigger?.Invoke();
        }
    }
}
