using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityAudioTrigger : PlayerUnityTrigger
{
    [SerializeField] private bool playAgain = false;
    [SerializeField] private AudioClip clipToSend;

    public static event System.Action<AudioClip> OnSoundActivate;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnSoundActivate?.Invoke(clipToSend);
            if (!playAgain)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
