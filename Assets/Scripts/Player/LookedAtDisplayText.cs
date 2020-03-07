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

    private void Start()
    {
        interactText = GetComponent<TMPro.TextMeshProUGUI>();
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
}
