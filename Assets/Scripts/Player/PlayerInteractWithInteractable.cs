using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the player to interact (press Interact) when looking at IIinteractive 
/// </summary>
public class PlayerInteractWithInteractable : MonoBehaviour
{
    private PlayerCheckInteract checkInteract;

    private void Start()
    {
        checkInteract = GetComponent<PlayerCheckInteract>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && checkInteract.InteractiveObjInSight != null)
        {
            checkInteract.InteractiveObjInSight.Interact();
        }
    }
}
