using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Ammo ammo = other.GetComponent<Ammo>();
        if (ammo)
        {
            Debug.Log("Player did what players do");
            Destroy(gameObject);
        }
    }
}
