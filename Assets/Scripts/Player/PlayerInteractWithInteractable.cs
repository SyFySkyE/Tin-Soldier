using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the player to interact (press Interact) when looking at IIinteractive 
/// </summary>
public class PlayerInteractWithInteractable : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI interactText;

    private PlayerCheckInteract checkInteract;

    private void Start()
    {
        checkInteract = GetComponent<PlayerCheckInteract>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkInteract.InteractiveObjInSight != null)
        {
            interactText.enabled = true;
            if (Input.GetButtonDown("Interact"))
            {
                checkInteract.InteractiveObjInSight.Interact();
            }
        }
        else
        {
            interactText.enabled = false;
        }
    }
}
