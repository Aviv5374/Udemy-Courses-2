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

    //public int GetCurrentAmmo()
    //{
    //    return ammoAmount;
    //}

    //public void ReduceAmmo(int ammoToReduce = 1)
    //{
    //    ammoAmount -= ammoToReduce;
    //}
}
