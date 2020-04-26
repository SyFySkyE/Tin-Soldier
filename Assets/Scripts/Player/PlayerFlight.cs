using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    [Header("Slider Anim Parameters")]
    [SerializeField] private float valueBeforeFadeOut = 2.9f;
    [SerializeField] private float valueBeforeLow = 1f;

    private FirstPersonController playerFPController;
    private CharacterController playerCharController;
    private Animator sliderAnim;

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
        sliderAnim = flightTimeSlider.GetComponent<Animator>();
        playerFPController = GetComponentInChildren<FirstPersonController>();
        playerCharController = playerFPController.GetComponent<CharacterController>();
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
                sliderAnim.SetTrigger("OnFadeIn");
                sliderAnim.SetBool("OnUse", true);
                currentFlightTime -= flyUpFlightTimeDecrementMultiplier * Time.fixedDeltaTime;
                playerCharController.Move(Vector3.up * currentFlightAccel * Time.deltaTime);
                currentFlightAccel = Mathf.Lerp(currentFlightAccel, maxFlightAccel, flightAccelMultiplier * Time.deltaTime);
                playerFPController.DecreaseGravity(gravityLerpDecrementAmount);
            }            
        }
        else
        {
            sliderAnim.SetBool("OnUse", false);
            if (currentFlightTime < flightTime)
            {
                currentFlightTime += Time.fixedDeltaTime * flightTimeRechargeMultiplier;
            }            
            playerFPController.ResetGravity();
            currentFlightAccel = flightAccel;
        }
    }

    private void LateUpdate()
    {
        flightTimeSlider.value = currentFlightTime;
        if (flightTimeSlider.value >= flightTimeSlider.maxValue)
        {
            sliderAnim.SetTrigger("OnFadeOut");
        }
        if (flightTimeSlider.value <= valueBeforeLow) 
        {
            sliderAnim.SetBool("OnLow", true);
        }
        else
        {
            sliderAnim.SetBool("OnLow", false);
        }
    }

    private void CheckForFlying()
    {
        if (Input.GetButtonDown("Jump") && playerFPController.IsJumping && currentFlightTime != 0)
        {
            isFlying = true;
        }
        else if (!playerFPController.IsJumping || currentFlightTime <= 0)
        {
            isFlying = false;
        }
    }
}
