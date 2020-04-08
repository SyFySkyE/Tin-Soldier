using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasController : MonoBehaviour
{
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController player;
    private Animator canvasAnim;
    private int canvasDotSprintAnim = Animator.StringToHash("PlayerSprint");

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        player.OnSprint += Player_OnSprint;
        canvasAnim = GetComponent<Animator>();
    }

    private void Player_OnSprint(bool isSprinting)
    {
        canvasAnim.SetBool(canvasDotSprintAnim, isSprinting);
    }
}
