using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerFlight : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider flightTimeSlider; // TODO Should this be taken care of by another class? That can take care of it dissppearing and whatnot when not in use

    [SerializeField] private float initialFlightTime = 2f;
    [SerializeField] private float flyUpFlightTimeDecrementMultiplier = 2f;
    [SerializeField] private float treadFightTimeDecrementMultiplier = 1.5f;

    private FirstPersonController playerController;
    private CharacterController playerCharController;

    private bool isFlying;
    private float currentFlightTime;

    // Start is called before the first frame update
    void Start()
    {
        isFlying = false;
        currentFlightTime = initialFlightTime;
        playerController = GetComponentInChildren<FirstPersonController>();
        playerCharController = playerController.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForFlying();

        if (isFlying)
        {
            if (Input.GetButton("Jump"))
            {
                playerCharController.Move(Vector3.up * 2);
            }
        }
    }

    private void CheckForFlying()
    {
        if (Input.GetButtonDown("Jump") && playerController.IsJumping && currentFlightTime != 0)
        {
            isFlying = true;
        }
    }
}
