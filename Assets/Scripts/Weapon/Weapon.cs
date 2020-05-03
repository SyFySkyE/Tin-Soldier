using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public abstract class Weapon : InteractiveObject
{
    [Header("Where the gun will be located and parented to")]
    [SerializeField] protected Transform playerHand;

    [SerializeField] private AudioClip shootSfx;
    [SerializeField] private float shootSfxVolume = 0.5f;

    [Header("Gun Parameters")]
    [SerializeField] protected int bulletsPerClip = 8;
    [SerializeField] protected int damage = 1;

    protected bool isGun;
    private int bulletsLeft;
    protected Animator weaponAnim;
    private ParticleSystem muzzleFlash;

    public static event System.Action<bool> OnWeaponSwitch; // SO canvas knows which crosshairs to display

    protected override void Awake()
    {
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
        isGun = true;
        bulletsLeft = bulletsPerClip;
        base.Awake();
    }

    protected virtual void OnEnable()
    {
        if (bulletsLeft <= 0 && isGun)
        {
            Reload();
        }
        OnWeaponSwitch?.Invoke(isGun);
    }
    
    public void OnPickUp()
    {
        OnWeaponSwitch?.Invoke(isGun);
        if (weaponAnim != null)
        {
            weaponAnim.SetTrigger("Pickup");
        }        
    }

    public virtual void Shoot()
    {
        if (bulletsLeft > 0)
        {
            muzzleFlash.Play();
            weaponAnim.SetTrigger("Shoot");
            this.objAudioSource.PlayOneShot(shootSfx, shootSfxVolume);
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
