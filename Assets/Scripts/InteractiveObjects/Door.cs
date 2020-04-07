using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [Header("SFX for Door Closing")]
    [SerializeField] private AudioClip doorCloseSfx;

    [Header("If door should close, what trigger should open it?")]
    [Tooltip("Leave empty to leave door open")]
    [SerializeField] private PlayerUnityTrigger closeTrigger;

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
        if (closeTrigger != null)
        {
            closeTrigger.OnTrigger += CloseTrigger_OnTrigger;
        }
    }

    private void CloseTrigger_OnTrigger()
    {        
        if (doorAnim.GetBool(doorOpenAnimParameter))
        {
            doorAnim.SetBool(doorOpenAnimParameter, false);
        }
    }

    public override void Interact()
    {
        base.Interact();
        doorAnim.SetBool(doorOpenAnimParameter, true);
    }
}
