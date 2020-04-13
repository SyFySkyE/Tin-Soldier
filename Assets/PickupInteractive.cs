using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickupInteractive : InteractiveObject
{
    [Header("Functional Dependency as to where the object will be held")]
    [SerializeField] private GameObject playerHand;
    [SerializeField] private string pickupText = "Pick up";
    [SerializeField] private string releaseText = "Drop";
    private Rigidbody pickupRb;

    private bool isBeingHeld = false;

    protected override void Awake()
    {
        this.isReuseable = true;
        pickupRb = GetComponent<Rigidbody>();
        base.Awake();
    }

    public override void Interact()
    {
        isBeingHeld = !isBeingHeld;
        if (isBeingHeld)
        {
            Pickup();            
            StateChange();
        }
        else
        {
            Drop();            
            StateChange();            
        }
        base.Interact();
    }

    private void Pickup()
    {
        this.displayText = releaseText;
        pickupRb.useGravity = false;
        pickupRb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.impulse == Vector3.zero && collision.relativeVelocity == Vector3.zero) // Object is being dragged inside other objects
        {
            Drop();
        }
    }

    private void Update()
    {
        if (isBeingHeld)
        {
            transform.position = playerHand.transform.position;
        }
    }

    private void Drop()
    {
        pickupRb.velocity = Vector3.zero;
        pickupRb.useGravity = true;
        pickupRb.constraints = RigidbodyConstraints.None;
        isBeingHeld = false;
        this.displayText = pickupText;
    }
}
