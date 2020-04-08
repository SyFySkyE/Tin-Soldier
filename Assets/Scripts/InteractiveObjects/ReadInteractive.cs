using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipInteriorReadImage { PhiIncident, PhiUpgrade, CyrrConquerring }

public class ReadInteractive : InteractiveObject, IReadable
{
    [Header("Read Canvas Object")]
    [SerializeField] private GameObject readCanvasObj;

    [Header("Which picture to show when read")]
    [SerializeField] private Sprite thisReadImage;

    public event System.Action<Sprite> OnImageRead;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void Interact()
    {
        Read();        
        base.Interact();
    }

    public void Read()
    {
        readCanvasObj.SetActive(true);
        OnImageRead(this.thisReadImage);
    }
}
