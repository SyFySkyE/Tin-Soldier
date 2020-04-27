using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasController : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI useText;

    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController player;
    private Animator canvasAnim;
    private int canvasDotSprintAnim = Animator.StringToHash("PlayerSprint");

    // Start is called before the first frame update
    void Start()
    {
        LevelTransition.OnLevelEnd += LevelTransition_OnLevelEnd;
        player = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        player.OnSprint += Player_OnSprint;
        canvasAnim = GetComponent<Animator>();
        InteractiveObject.OnUseText += InteractiveObject_OnUseText;
        canvasAnim.SetTrigger("Start");
    }

    private void LevelTransition_OnLevelEnd()
    {
        canvasAnim.SetTrigger("OnLevelEnd");
    }

    private void InteractiveObject_OnUseText(string textToDisplay)
    {
        useText.text = textToDisplay;
        canvasAnim.SetTrigger("Use");
    }

    private void Player_OnSprint(bool isSprinting)
    {
        canvasAnim.SetBool(canvasDotSprintAnim, isSprinting);
    }
}
