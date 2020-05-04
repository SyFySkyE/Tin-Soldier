using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SkipCutsene : MonoBehaviour
{
    private PlayableDirector timeline;

    // Start is called before the first frame update
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // If we click, then go to the last frame of the scene
            timeline.time = timeline.duration;
    }
}
