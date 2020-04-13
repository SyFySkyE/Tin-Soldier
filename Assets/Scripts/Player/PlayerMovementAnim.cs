using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAnim : MonoBehaviour
{
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Strafe();

    }

    private void Walk()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            playerAnim.SetBool("Walking", true);
        }
        else
        {
            playerAnim.SetBool("Walking", false);
        }
        playerAnim.SetFloat("WalkForward", Input.GetAxis("Vertical"));
    }

    private void Strafe()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            playerAnim.SetBool("StrafeRight", true);
            playerAnim.SetBool("StrafeLeft", false);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            playerAnim.SetBool("StrafeLeft", true);
            playerAnim.SetBool("StrafeRight", false);
        }
        else
        {
            playerAnim.SetBool("StrafeLeft", false);
            playerAnim.SetBool("StrafeRight", false);
        }
    }
}
