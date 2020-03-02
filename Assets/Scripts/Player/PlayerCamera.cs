using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls Camera behavior and state
/// </summary>

public enum CameraState { Normal, Sprint }

public class PlayerCamera : MonoBehaviour
{
    [Header("FOV When player is sprinting")]
    [Range(0, 179)][SerializeField] private float initialFOV = 60;
    [Range(0, 179)][SerializeField] private float sprintFOV = 75;

    [Header("Speed of FOV lerp. How fast it changes during sprint in.")]
    [Range(0, 1)] [SerializeField] private float sprintInLerpSpeed = 0.1f;
    [Header("Speed of FOV lerp. How fast it changes during sprint out.")]
    [Range(0, 1)] [SerializeField] private float sprintOutLerpSpeed = 0.01f;

    private Animator playerAnim;
    private CameraState currentState = CameraState.Normal;
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpController;
    private Camera playerCam;

    private bool fpOnSprint = false;

    private void Start()
    {
        playerCam = GetComponentInChildren<Camera>();
        fpController = GetComponentInChildren<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        fpController.OnSprint += FpController_OnSprint;
        playerAnim = GetComponent<Animator>();
    }

    private void FpController_OnSprint(bool obj)
    {
        fpOnSprint = obj;
    }

    private void Update()
    {
        if (fpOnSprint && currentState == CameraState.Normal)
        {
            if (playerCam.fieldOfView <= sprintFOV)
            {
                playerCam.fieldOfView = Mathf.Lerp(playerCam.fieldOfView, sprintFOV, sprintInLerpSpeed);
            }
            else
            {
                currentState = CameraState.Sprint;
            }
        }
        else if (!fpOnSprint && currentState == CameraState.Sprint)
        {

        }
    }
}
