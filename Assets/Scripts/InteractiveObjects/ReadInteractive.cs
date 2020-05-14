using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInteractive : InventoryObject, IReadable
{
    [Header("Read Canvas Object")]
    [SerializeField] private GameObject readCanvasObj;

    [Header("Which picture to show when read")]
    [SerializeField] private Sprite thisReadImage;

    public event System.Action<Sprite> OnImageRead;
    public event System.Action OnCancelRead;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void Interact()
    {
        if (PlayerCurrentState.CurrentPlayerState != PlayerState.Reading)
        {
            PlayerCurrentState.CurrentPlayerState = PlayerState.Reading;
            Read();
            base.Interact();            
        }
        else
        {
            PlayerCurrentState.CurrentPlayerState = PlayerState.None;
            OnCancelRead?.Invoke();
        }
        PauseController.Pause();
    }

    public void Read()
    {
        readCanvasObj.SetActive(true);
        OnImageRead(this.thisReadImage);
    }
}
