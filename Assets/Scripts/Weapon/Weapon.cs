using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : InteractiveObject
{
    [Header("Where the gun will be located and parented to")]
    [SerializeField] protected Transform playerHand;

    [Header("Gun Parameters")]
    [SerializeField] protected int bulletsPerClip = 8;
    [SerializeField] protected int damage = 1;

    private int bulletsLeft;
    protected Animator weaponAnim;

    protected override void Awake()
    {
        bulletsLeft = bulletsPerClip;
        base.Awake();
    }

    private void OnEnable()
    {
        if (bulletsLeft <= 0)
        {
            Reload();
        }
    }
    
    public void OnPickUp()
    {
        weaponAnim.SetTrigger("Pickup");
    }

    public virtual void Shoot()
    {
        if (bulletsLeft > 0)
        {
            Debug.Log("Bang");
            //weaponAnim.SetTrigger("Shoot");
            bulletsLeft--;
        }
        else
        {
            Reload();
        }        
    }

    public virtual void Reload()
    {
        Debug.Log("Reloading...");
    }

    public void ReloadBullets() // To be called by animator
    {
        bulletsLeft = bulletsPerClip;
    }
}
