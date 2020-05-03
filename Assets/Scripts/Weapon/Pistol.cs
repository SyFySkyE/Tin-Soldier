using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private AudioClip reloadSfx;

    protected override void Awake()
    {
        this.weaponAnim = GetComponent<Animator>();
        base.Awake();
    }

    public override void Interact()
    {        
        this.transform.SetParent(playerHand);
        this.transform.localRotation = Quaternion.Euler(Vector3.zero);
        this.transform.localPosition = Vector3.zero;
        playerHand.GetComponent<PlayerWeapons>().AddWeapon(this);
        base.Interact();
    }
}
