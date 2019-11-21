using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlashVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;

    WeaponZoom weaponZoom;
    bool canShoot = true;

    public WeaponZoom WeaponZoom
    {
        get
        {
            if (!weaponZoom)
            {
                weaponZoom = GetComponent<WeaponZoom>();
            }

            return weaponZoom;
        }
    }

    void Start()
    {
        //canShoot = true;????????
        //I think this is better
        //ammoSlot = GetComponent<Ammo>();       
    }

    // Update is called once per frame
    void Update()
    {
        DisplayAmmo();

        //Debug.Log("Update IN " + name);
        if (Input.GetButtonDown("Fire1") && canShoot && ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            StartCoroutine(Shoot());
        }
    }

    void OnDisable()//OR OnEnable()
    {
        //Resolves the problem that it's ignore the condition in Update(), because canShoot stay false, and does not fire.
        //Creates the problem when I switch weapons back it shoots straight a way, ignoring the time left between shots.
        //TODO: Find a better solution
        StopAllCoroutines();
        canShoot = true;
    }

    void DisplayAmmo()
    {
        ammoText.text = ammoSlot.GetCurrentAmmo(ammoType).ToString();
    }

    IEnumerator Shoot()
    {
        //Debug.Log("StartCoroutine(Shoot());");
        canShoot = false;
        ammoSlot.ReduceAmmo(ammoType);
        PlayVFX(muzzleFlashVFX);
        ProcessRaycast();
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
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
        //Debug.Log("I hit this thing: " + hit.transform.name);
        CreateHitImpact(hit);
        EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
        if (target == null || target.HitPoints <= 0) return;
        target.TakeDamage(damage);
    }

    void CreateHitImpact(RaycastHit hit)
    {
        var tempHitVFX = Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));       
        Destroy(tempHitVFX, 0.1f);
    }

    void OnPlayerDeath()
    {
        canShoot = false;
    }
}
