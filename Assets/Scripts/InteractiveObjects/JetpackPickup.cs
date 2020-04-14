using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackPickup : InteractiveObject
{
    public override void Interact()
    {
        base.Interact();
        AudioSource.PlayClipAtPoint(objAudioSource.clip, transform.position);
        Destroy(this.gameObject);
    }
}
