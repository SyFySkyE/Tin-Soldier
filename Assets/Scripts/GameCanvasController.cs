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
        canvasAnim = GetComponent<Animator>();
        LevelTransition.OnLevelEnd += LevelTransition_OnLevelEnd;
        player = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        player.OnSprint += Player_OnSprint;
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

    private void OnDisable()
    {
        LevelTransition.OnLevelEnd -= LevelTransition_OnLevelEnd;
        InteractiveObject.OnUseText -= InteractiveObject_OnUseText;
    }
}
