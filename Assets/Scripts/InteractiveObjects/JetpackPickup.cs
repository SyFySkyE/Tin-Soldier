using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackPickup : InventoryObject
{
    private PlayerCamera player;

    protected override void Awake()
    {
        player = FindObjectOfType<PlayerCamera>();
        base.Awake();
    }

    public override void Interact()
    {
        player.GetComponent<PlayerFlight>().enabled = true;
        base.Interact();
        AudioSource.PlayClipAtPoint(objAudioSource.clip, transform.position);
        Destroy(this.gameObject);
    }
}
