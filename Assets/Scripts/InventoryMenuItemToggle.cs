using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItemToggle : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image iconImage;
    private InventoryObject associatedInventoryObject;
    public static event System.Action<InventoryObject> InventoryMenuItemSelected;
    public InventoryObject AssociatedInventoryObject
    {
        get
        {
            return this.associatedInventoryObject;
        }
        set
        {
            associatedInventoryObject = value;
            iconImage.sprite = associatedInventoryObject.Icon;            
        }
    }

    public void InventoryMenuItemWasToggled(bool isActive) // To be used only by OnValueChanged
    {
        if (isActive)
        {
            InventoryMenuItemSelected?.Invoke(AssociatedInventoryObject);
        }
    }

    private void Awake()
    {
        Toggle toggle = GetComponent<Toggle>();
        ToggleGroup toggleGroup = GetComponentInParent<ToggleGroup>();
        toggle.group = toggleGroup;
        Door.OnKeyDestroy += Door_OnKeyDestroy;
    }

    private void Door_OnKeyDestroy(InventoryObject obj)
    {
        if (this.AssociatedInventoryObject == obj)
        {
            Destroy(this.gameObject);
        }
    }
}
