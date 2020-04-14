using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : InteractiveObject
{
    [Header("Audio clips this NPC will say when interacted with")]
    [SerializeField] private List<AudioClip> voiceClips;

    public override void Interact()
    {
        if (!objAudioSource.isPlaying)
        {
            objAudioSource.clip = voiceClips[Random.Range(0, voiceClips.Count)];
        }        
        base.Interact();
        if (this.isReuseable)
        {
            StartCoroutine(ReactivateUsability(objAudioSource.clip.length));
        }        
    }

    private IEnumerator ReactivateUsability(float length)
    {
        this.isReuseable = false;
        yield return new WaitForSeconds(length);
        this.isReuseable = true;
    }
}
