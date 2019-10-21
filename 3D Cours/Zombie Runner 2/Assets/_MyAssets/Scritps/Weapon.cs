using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlashVFX;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        PlayVFX(muzzleFlashVFX);
        ProcessRaycast();
    }

    void PlayVFX(ParticleSystem vfx)//OR PlayMuzzleFlash(...)
    {
        vfx.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            ProcessHit(hit);
        }
        else
        {
            return;
        }
    }

    void ProcessHit(RaycastHit hit)
    {
        Debug.Log("I hit this thing: " + hit.transform.name);
        // TODO: add some hit effect for visual players
        EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
        if (target == null) return;
        target.TakeDamage(damage);
    }
}
