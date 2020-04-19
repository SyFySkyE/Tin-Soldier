using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [Header("The object name that will appear in the inventory menu UI")]
    [SerializeField] protected string objectText = nameof(InventoryObject);
    public string ObjectText => this.objectText;
    [Header("Whether this item will disable when interaction")]
    [SerializeField] private bool willRemove;

    private Renderer objRenderer;
    private Collider objCollider;

    [Header("Inventory UI parameters")]
    [TextArea(4, 8)]
    [Tooltip("Text that will diplay when this object is viewed in inventory")]
    [SerializeField] private string description;
    public string Description => this.description;
    [Tooltip("Image that will represent item in inventory")]
    [SerializeField] private Sprite icon;
    public Sprite Icon => this.icon;

    /// <summary>
    /// Add inv object ot PlayerInventory
    /// Remove from scene
    /// </summary>

    protected override void Awake()
    {
        objCollider = GetComponent<Collider>();
        objRenderer = GetComponent<Renderer>();
        base.Awake();
    }

    public InventoryObject()
    {        
        this.displayText = $"Take {this.objectText}";
    }

    public override void Interact()
    {
        base.Interact();
        PlayerInventory.InventoryObjects.Add(this);
        InventoryMenu.Instance.AddItemToMenu(this);
        if (willRemove)
        {
            objRenderer.enabled = false;
            objCollider.enabled = false;            
        }        
    }
}
