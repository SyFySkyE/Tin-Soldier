using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerAirShipCatch : PlayerCatch
{
    [SerializeField] private Animator canvasAnim;
    private float secondsBeforeFade = 1f;
    private FirstPersonController playerController;
    private CharacterController playerCharController;
    private int currentTouchingHashCode;
    private bool isFading;
    
    protected override void Start()
    {
        isFading = false;
        currentTouchingHashCode = 0;
        playerCharController = GetComponent<CharacterController>();
        playerController = GetComponent<FirstPersonController>();
        base.Start();
    }

    protected override void Update()
    {
        if (this.transform.position.y <= yPosRespawnTrigger)
        {
            if (!isFading)
            {                
                canvasAnim.SetTrigger("OnLevelEnd");
                StartCoroutine(FadeInScreen());
                isFading = true;                
            }            
        }
    }

    private IEnumerator FadeInScreen()
    {
        yield return new WaitForSeconds(secondsBeforeFade);
        playerCharController.enabled = false;
        playerController.enabled = false;
        this.transform.position = spawnPos;
        canvasAnim.SetTrigger("Start");
        playerCharController.enabled = true;
        playerController.enabled = true;
        isFading = false;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (currentTouchingHashCode != hit.GetHashCode())
        {
            currentTouchingHashCode = hit.GetHashCode();
            if (hit.gameObject.CompareTag("AirShip"))
            {
                this.spawnPos = hit.gameObject.GetComponent<PlayerCheckpoint>().GetRespawnPoint();
            }
        }        
    }
}
