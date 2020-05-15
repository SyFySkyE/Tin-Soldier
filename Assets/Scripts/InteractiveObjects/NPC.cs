using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class NPC : InteractiveObject
{
    [Header("Audio clips this NPC will say when interacted with")]
    [SerializeField] private List<AudioClip> voiceClips;

    [SerializeField] private GameObject[] objectsToEnable; // TODO this is not good, NPC should not be responsible for this!

    [SerializeField] private PlayableDirector timeline;

    public override void Interact()
    {
        if (!objAudioSource.isPlaying)
        {
            objAudioSource.clip = voiceClips[Random.Range(0, voiceClips.Count)];
            timeline.Play();
            foreach (GameObject go in objectsToEnable)
            {
                go.SetActive(true);
            }
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
