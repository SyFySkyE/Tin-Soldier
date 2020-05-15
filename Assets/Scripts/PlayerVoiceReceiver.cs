using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerVoiceReceiver : MonoBehaviour
{
    private AudioSource playerAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
        UnityAudioTrigger.OnSoundActivate += UnityAudioTrigger_OnSoundActivate;
    }

    private void UnityAudioTrigger_OnSoundActivate(AudioClip obj)
    {
        playerAudioSource.clip = obj;
        playerAudioSource.Play();
    }
}
