using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInteractive : InteractiveObject
{
    private CutscenePlay cutscene;

    private void Start()
    {
        cutscene = FindObjectOfType<CutscenePlay>();
    }
    public override void Interact()
    {
        cutscene.PlayScene();
        this.enabled = false;
    }
}
