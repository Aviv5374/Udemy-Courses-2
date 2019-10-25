using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    //TODO: make it work with a list, like Borderlands.
    //the player start with 1 weapon and when she level up more weapon slots are open.
    Weapon[] weapons;

    // Start is called before the first frame update
    void Start()
    {
        weapons = GetComponentsInChildren<Weapon>();
        ResetWeaponActivity();
        weapons[0].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        SwitchWeapon();
    }

    void SwitchWeapon()
    {
        //TODO: add the option to switch weapons whit Mouse ScrollWheel

        ProcessKeyInput();
    }

    void ProcessKeyInput()
    {
        for (int index = 0; index < weapons.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                ResetWeaponActivity();
                weapons[index].gameObject.SetActive(true);
            }
        }
    }

    private void ResetWeaponActivity()
    {
        for (int index = 0; index < weapons.Length; index++)
        {
            weapons[index].gameObject.SetActive(false);
        }
    }    
}
