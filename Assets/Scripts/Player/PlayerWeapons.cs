using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private Unarmed unarmedObj;

    private int weaponIndex;
    private AudioSource playerWeaponSwitchAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerWeaponSwitchAudioSource = GetComponent<AudioSource>();
        weaponIndex = 0;
        weapons = new List<Weapon>();
        weapons.Add(Instantiate(unarmedObj, this.transform));        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("ChangeWeapon") != 0)
        {
            if (Input.GetAxis("ChangeWeapon") > 0) // Connected to scroll wheel
            {
                IncrementWeaponIndex();
            }
            else if (Input.GetAxis("ChangeWeapon") < 0)
            {
                DecrementWeaponIndex();
            }
            weapons[weaponIndex].OnPickUp();
        }        

        if (weapons.Count > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                weapons[weaponIndex].Shoot();
            }
            else if (Input.GetButtonDown("Reload"))
            {
                weapons[weaponIndex].Reload();
            }
        }        
    }

    private void DecrementWeaponIndex()
    {
        if (weapons.Count > 1) // Do we have more than one weapon? Unarmed counts as a weapon
        {
            if (weaponIndex - 1 >= 0) // Will switch to a lower weapon as long as it's index 0 or above
            {
                weapons[weaponIndex].gameObject.SetActive(false);
                weaponIndex--;
                weapons[weaponIndex].gameObject.SetActive(true);
            }
            else // If Index will be nonzero, wrap to the largest value
            {
                weapons[weaponIndex].gameObject.SetActive(false);
                weaponIndex = weapons.Count - 1; // Count doesn't account for the fact computers start counting at zero
                weapons[weaponIndex].gameObject.SetActive(true);
            }
        }
    }

    private void IncrementWeaponIndex()
    {
        if (weapons.Count > 1) // Do we have more than one weapon?
        {
            if (weaponIndex + 1 < weapons.Count) // Are we at the top of the list ie max index?
            {
                weapons[weaponIndex].gameObject.SetActive(false);
                weaponIndex++;
                weapons[weaponIndex].gameObject.SetActive(true);
            }
            else // If we are, then we wrap back to the first index
            {
                weapons[weaponIndex].gameObject.SetActive(false);
                weaponIndex = 0;
                weapons[weaponIndex].gameObject.SetActive(true);
            }
        }
    }

    public void AddWeapon(Weapon newWeapon)
    {
        foreach (Weapon oldWeapon in weapons)
        {
            oldWeapon.gameObject.SetActive(false);
        }
        weapons.Add(newWeapon);
        weaponIndex = weapons.Count - 1; // Equip the weapon we just picked up
        newWeapon.OnPickUp();
    }
}
