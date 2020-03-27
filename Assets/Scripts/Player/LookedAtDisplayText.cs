using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Behavior for display text about interactive text
/// </summary>
[RequireComponent(typeof(TMPro.TextMeshProUGUI))]
public class LookedAtDisplayText : MonoBehaviour
{
    private IInteractable interactiveObjLookedAt;
    private TMPro.TextMeshProUGUI interactText;

    #region Event Subscriptions and Unsubscriptions
    private void OnEnable()
    {
        PlayerCheckInteract.LookedAtInteractableChanged += OnLookedAtInteractableChange;
        InteractiveObject.OnLookedAtStateChange += InteractiveObject_OnLookedAtStateChange;
    }

    private void InteractiveObject_OnLookedAtStateChange()
    {
        UpdateDisplayText();
    }

    private void OnDisable()
    {
        PlayerCheckInteract.LookedAtInteractableChanged -= OnLookedAtInteractableChange;
        InteractiveObject.OnLookedAtStateChange -= InteractiveObject_OnLookedAtStateChange;
    }
    #endregion

    private void Start()
    {
        interactText = GetComponent<TMPro.TextMeshProUGUI>();
        UpdateDisplayText();
    }

    private void UpdateDisplayText()
    {
        if (interactiveObjLookedAt != null)
        {
            interactText.text = interactiveObjLookedAt.DisplayText;
        }
        else
        {
            interactText.text = string.Empty;
        }
    }
    /// <summary>
    /// Event handler for PlayerCheckInteract.LookedAtObj changed
    /// </summary>
    /// <param name="newObjLookedAt"></param>
    private void OnLookedAtInteractableChange(IInteractable newObjLookedAt)
    {
        interactiveObjLookedAt = newObjLookedAt;
        UpdateDisplayText();
    }    
}
