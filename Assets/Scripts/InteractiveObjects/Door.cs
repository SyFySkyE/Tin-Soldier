using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [Header("Locked Parameters")]    
    [SerializeField] private string lockedText = "ERROR! Keycard required.";
    [SerializeField] private string unlockText = "Access granted!";
    [Header("Assign inventory GO needed to unlock door")]
    [Tooltip("Drag an inventory game object from the scene here. If the player has this object in their inventory, they can open this door")]
    [SerializeField] private InventoryObject key;
    [Header("Text to show when key is removed. Leave this blank to not remove key from inventory.")]
    [SerializeField] private string itemConsumeText;
    [Header("SFX for Door")]
    [SerializeField] private AudioClip openDoorSfx;
    [SerializeField] private AudioClip doorCloseSfx;
    [SerializeField] private float doorCloseSfxVolume = 1f;
    [SerializeField] private AudioClip lockedDoorSfx;
    [Header("If door should close, what trigger should open it?")]
    [Tooltip("Leave empty to leave door open")]
    [SerializeField] private PlayerUnityTrigger closeTrigger;
    public static event System.Action<InventoryObject> OnKeyDestroy;

    public override string DisplayText
    {
        get
        {
            string textToReturn;
            if (isLocked)
                textToReturn = hasKey ? displayText : lockedText;
            else
                textToReturn = base.DisplayText;
            return textToReturn;
        }
    }

    private Animator doorAnim;
    private int doorOpenAnimParameter = Animator.StringToHash("DoorOpen");
    private bool isLocked = false;
    private bool hasKey => PlayerInventory.InventoryObjects.Contains(key);

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
        InitializeIsLocked();
    }

    private void InitializeIsLocked()
    {
        if (key != null) isLocked = true;
        else isLocked = false;
    }

    private void CloseTrigger_OnTrigger()
    {        
        if (doorAnim.GetBool(doorOpenAnimParameter))
        {
            doorAnim.SetBool(doorOpenAnimParameter, false);
            objAudioSource.PlayOneShot(doorCloseSfx, doorCloseSfxVolume);
        }
    }

    public override void Interact()
    {
        if (!isLocked || hasKey)
        {
            if (!this.hasBeenUsed || this.isReuseable)
            {
                OpenDoor();                
            }            
        }
        else
        {
            TutorialText.Instance.PlayTutorialText(Tutorials.LockedDoor);
            this.useText = string.Empty;
            objAudioSource.clip = lockedDoorSfx;            
        }
        base.Interact();
    }

    private void OpenDoor()
    {
        if (key != null)
        {
            this.useText = unlockText;
        }
        doorAnim.SetBool(doorOpenAnimParameter, true);
        objAudioSource.clip = openDoorSfx;
        if (itemConsumeText != string.Empty)
        {
            this.useText = itemConsumeText;
            OnKeyDestroy?.Invoke(key);
            PlayerInventory.InventoryObjects.Remove(key);            
        }        
    }
}
