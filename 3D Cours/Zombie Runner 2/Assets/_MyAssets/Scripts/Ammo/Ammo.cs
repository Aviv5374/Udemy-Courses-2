using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount = 10;

        //public int AmmoAmount { get => ammoAmount; } //set => ammoAmount = value; }
    }

    AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void ReduceAmmo(AmmoType ammoType, int ammoToReduce = 1)
    {
        GetAmmoSlot(ammoType).ammoAmount -= ammoToReduce;
    }

    public void IncreaseAmmo(AmmoType ammoType, int ammoToIncrease)
    {
        GetAmmoSlot(ammoType).ammoAmount += ammoToIncrease;
    }

}
