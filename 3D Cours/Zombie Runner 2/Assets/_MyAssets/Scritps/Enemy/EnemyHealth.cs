using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 200;

    public float HitPoints { get => hitPoints; }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        BroadcastMessage("OnDamageTaken");
        if (hitPoints <= 0)
        {
            BroadcastMessage("OnDeath");
        }
    }
}
