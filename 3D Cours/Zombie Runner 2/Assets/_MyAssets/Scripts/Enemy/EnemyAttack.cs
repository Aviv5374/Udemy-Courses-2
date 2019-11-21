using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 40f;

    PlayerHealth target;
    DisplayDamage damageTarget;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        damageTarget = FindObjectOfType<DisplayDamage>();
    }

    public void AttackHitEvent()
    {
        if (!target || !damageTarget)
        {
            Debug.LogWarning("Didn't Find Player's Scripts!!!!!");
            return;
        }

        target.TakeDamage(damage);
        damageTarget.ShowDamageImpact();
    }

    void OnDamageTaken()
    {
        Debug.Log("OnDamageTaken in EnemyAttack of " + name);
    }

}
