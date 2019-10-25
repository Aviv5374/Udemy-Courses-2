using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    int currentWeaponIndex = 0;

    //TODO: make it work with a list, like Borderlands.
    //the player start with 1 weapon and when she level up more weapon slots are open.
    Weapon[] weapons;

    int CurrentWeaponIndex 
    { 
        get => currentWeaponIndex;
        set 
        {
            currentWeaponIndex = value;

            if (currentWeaponIndex > weapons.Length -1)
            {
                currentWeaponIndex = 0;
            }

            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = weapons.Length - 1;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        weapons = GetComponentsInChildren<Weapon>();
        SetWeaponActive(CurrentWeaponIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0 || IsKeyWasPessed())
        {
            SwitchWeapon();        
        }
    }

    bool IsKeyWasPessed()
    {
        for (int index = 0; index < weapons.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                return true;
            }
        }

        return false;
    }

    void SwitchWeapon()
    {        
        ProcessScrollWheel();
        ProcessKeyInput();
        SetWeaponActive(CurrentWeaponIndex);
    }

    void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            CurrentWeaponIndex++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            CurrentWeaponIndex--;
        }
    }

    void ProcessKeyInput()
    {
        for (int index = 0; index < weapons.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                CurrentWeaponIndex = index;               
            }
        }
    }

    void SetWeaponActive(int index)
    {
        ResetWeaponActivity();
        weapons[index].gameObject.SetActive(true);
    }

    void ResetWeaponActivity()
    {
        for (int index = 0; index < weapons.Length; index++)
        {
            weapons[index].gameObject.SetActive(false);
        }
    }    
}
