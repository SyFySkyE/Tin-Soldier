using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerUnityTrigger : MonoBehaviour, ITrigger
{
    private Collider triggerCollider;

    public event Action OnTrigger;

    void Start()
    {
        triggerCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.CompareTag("Player"))
        {
            OnTrigger?.Invoke();
        }
    }
}
