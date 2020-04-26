using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerFlight : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider flightTimeSlider; // TODO Should this be taken care of by another class? That can take care of it dissppearing and whatnot when not in use

    [Header("Flight parameters")]
    [SerializeField] private float flightTime = 2f;
    [SerializeField] private float flightAccel = 3f;
    [SerializeField] private float maxFlightAccel = 10f;
    [SerializeField] private float flightAccelMultiplier = 1.5f;
    [SerializeField] private float flyUpFlightTimeDecrementMultiplier = 2f;
    [SerializeField] private float treadFightTimeDecrementMultiplier = 1.5f;
    [SerializeField] private float gravityLerpDecrementAmount = 0.1f;
    [SerializeField] private float flightTimeRechargeMultiplier = 0.7f;

    private FirstPersonController playerController;
    private CharacterController playerCharController;

    private bool isFlying;
    private bool isFloating;
    private float currentFlightTime;
    private float currentFlightAccel;

    // Start is called before the first frame update
    void Start()
    {
        isFloating = false;
        isFlying = false;
        currentFlightAccel = flightAccel;
        currentFlightTime = flightTime;
        playerController = GetComponentInChildren<FirstPersonController>();
        playerCharController = playerController.GetComponent<CharacterController>();
        flightTimeSlider.maxValue = flightTime;
    }   

    // Update is called once per frame
    void Update()
    {
        CheckForFlying();

        if (isFlying)
        {            
            if (Input.GetButton("Jump"))
            {
                isFloating = true;                
            }
            else
            {
                isFloating = false;                
            }
        }
    }

    private void FixedUpdate()
    {
        if (isFloating && isFlying)
        {
            if (currentFlightTime > 0)
            {
                currentFlightTime -= flyUpFlightTimeDecrementMultiplier * Time.fixedDeltaTime;
                playerCharController.Move(Vector3.up * currentFlightAccel * Time.deltaTime);
                currentFlightAccel = Mathf.Lerp(currentFlightAccel, maxFlightAccel, flightAccelMultiplier * Time.deltaTime);
                playerController.DecreaseGravity(gravityLerpDecrementAmount);
            }            
        }
        else
        {
            if (currentFlightTime < flightTime)
            {
                currentFlightTime += Time.fixedDeltaTime * flightTimeRechargeMultiplier;
            }            
            playerController.ResetGravity();
            currentFlightAccel = flightAccel;
        }
    }

    private void LateUpdate()
    {
        flightTimeSlider.value = currentFlightTime;
    }

    private void CheckForFlying()
    {
        if (Input.GetButtonDown("Jump") && playerController.IsJumping && currentFlightTime != 0)
        {
            isFlying = true;
        }
        else if (!playerController.IsJumping || currentFlightTime <= 0)
        {
            isFlying = false;
        }
    }

    public void SliderAnimation(float value)
    {
        Debug.Log(value);
    }
}
