using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Behavior for display text about interactive text
/// </summary>
public class LookedAtDisplayText : MonoBehaviour
{
    private IInteractable interactiveObjLookedAt;
    private TMPro.TextMeshProUGUI interactText;

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
