using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerVoiceReceiver : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI subtitleText;
    private AudioSource playerAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
        UnityAudioTrigger.OnSoundActivate += UnityAudioTrigger_OnSoundActivate;
    }

    private void UnityAudioTrigger_OnSoundActivate(AudioClip obj) // TODO Should be able to get away with just sending an enum, not a whole audioclip
    {
        if (playerAudioSource != null)
        {
            playerAudioSource.clip = obj;
            playerAudioSource.Play();
        }        
    }
}
