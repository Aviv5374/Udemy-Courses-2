using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] int ammoAmount = 10;

    void OnTriggerEnter(Collider other)
    {
        Ammo playerAmmo = other.GetComponent<Ammo>();
        if (playerAmmo)
        {
            //Debug.Log("Player did what players do");
            playerAmmo.IncreaseAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        }
    }
}
