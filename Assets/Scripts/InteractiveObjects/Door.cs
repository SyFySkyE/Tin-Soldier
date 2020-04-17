using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [Header("Locked Parameters")]
    [SerializeField] private bool isLocked = false;
    [SerializeField] private string lockedText = "ERROR! Keycard required.";
    [Header("SFX for Door")]
    [SerializeField] private AudioClip openDoorSfx;
    [SerializeField] private AudioClip doorCloseSfx;
    [SerializeField] private AudioClip lockedDoorSfx;
    [Header("If door should close, what trigger should open it?")]
    [Tooltip("Leave empty to leave door open")]
    [SerializeField] private PlayerUnityTrigger closeTrigger;

    public override string DisplayText => isLocked ? lockedText : base.DisplayText;

    private Animator doorAnim;
    private AudioSource doorAudioSource;
    private int doorOpenAnimParameter = Animator.StringToHash("DoorOpen");

    public Door()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        doorAnim = GetComponent<Animator>();
        doorAudioSource = GetComponent<AudioSource>();
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
            doorAudioSource.PlayOneShot(doorCloseSfx);
        }
    }

    public override void Interact()
    {
        if (!isLocked)
        {            
            doorAnim.SetBool(doorOpenAnimParameter, true);
            objAudioSource.clip = openDoorSfx;            
        }
        else
        {
            objAudioSource.clip = lockedDoorSfx;            
        }
        base.Interact();
    }
}
