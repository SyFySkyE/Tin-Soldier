using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unarmed : Weapon
{
    private PlayerCheckInteract playerInteract;

    protected override void Awake()
    {
        playerInteract = GetComponentInParent<PlayerCheckInteract>();        
    }

    private void Start()
    {
        isGun = false;
    }

    public override void Shoot()
    {
        // Interact
    }

    protected override void OnEnable()
    {
        playerInteract.enabled = true;
        base.OnEnable();
    }

    private void OnDisable()
    {
        playerInteract.enabled = false;
    }
}
