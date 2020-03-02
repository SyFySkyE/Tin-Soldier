using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator playerAnim;
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpController;

    private void Start()
    {
        fpController = GetComponentInChildren<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        fpController.OnSprint += FpController_OnSprint;
        playerAnim = GetComponent<Animator>();
    }

    private void FpController_OnSprint(bool obj)
    {
        playerAnim.SetBool("Run", obj);
    }
}
