using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;

    public int AmmoAmount { get => ammoAmount; } //set => ammoAmount = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceAmmo(int ammoToReduce = 1)
    {
        ammoAmount -= ammoToReduce;
    }
}
