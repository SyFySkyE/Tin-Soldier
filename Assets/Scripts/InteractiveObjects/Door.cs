using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    private Animator doorAnim;
    private int doorOpenAnimParameter = Animator.StringToHash("DoorOpen");

    public Door()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        doorAnim = GetComponent<Animator>();
    }

    public override void Interact()
    {
        base.Interact();
        doorAnim.SetBool(doorOpenAnimParameter, true);
    }
}
