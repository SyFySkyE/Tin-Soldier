using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the player to interact (press Interact) when looking at IIinteractive 
/// </summary>
public class PlayerInteractWithInteractable : MonoBehaviour
{
    private IInteractable lookedAtInteractable;

    #region Event Subscriptions and Unsubscriptions
    private void OnEnable()
    {
        PlayerCheckInteract.LookedAtInteractableChanged += OnLookedAtInteractableChange;
    }

    private void OnDisable()
    {
        PlayerCheckInteract.LookedAtInteractableChanged -= OnLookedAtInteractableChange;
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && lookedAtInteractable != null)
        {
            lookedAtInteractable.Interact();
        }   
    }


    private void OnLookedAtInteractableChange(IInteractable newObjLookedAt)
    {
        lookedAtInteractable = newObjLookedAt;
    }
}
