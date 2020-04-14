using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenePlay : MonoBehaviour
{
    private UnityEngine.Playables.PlayableDirector cutscene;

    // Start is called before the first frame update
    void Start()
    {
        cutscene = GetComponent<UnityEngine.Playables.PlayableDirector>();
    }

    public void PlayScene()
    {
        cutscene.Play();
    }
}
