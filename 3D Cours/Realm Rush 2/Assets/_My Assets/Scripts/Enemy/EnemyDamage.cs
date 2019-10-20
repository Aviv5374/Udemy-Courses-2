using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] int hitDamage = 2;
    [SerializeField] ParticleSystem hitVFX;
    [SerializeField] ParticleSystem deathVFX;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip deathSFX;

    Vector3 mainCameraPos;

    // Start is called before the first frame update
    void Start()
    {
        //in the edior that a 4 second delay between click the play button and the game playing.
        //TODO: Find why it is and if its only in the edior (make a build).
        mainCameraPos = Camera.main.transform.position;
    }

    void OnParticleCollision(GameObject other)
    {
        Processhit();
        if (hitPoints <= 0)
        {
            //Debug.Log(name + " is Dead!!");
            AudioSource.PlayClipAtPoint(deathSFX, mainCameraPos);
            OnEnemyDeath(deathVFX);

        }
    }

    void Processhit()
    {
        hitPoints -= hitDamage;
        hitVFX.Play();
        AudioSource.PlayClipAtPoint(hitSFX, mainCameraPos);
        //Debug.Log(name + " hitPoints is: " + hitPoints);        
    }

    void OnEnemyDeath(ParticleSystem VFX)
    {
        InstantiateAndPlayVFX(VFX);
        Destroy(gameObject);
    }

    void InstantiateAndPlayVFX(ParticleSystem VFX)
    {
        var tempVFX = Instantiate(VFX, this.transform.position, Quaternion.identity);
        tempVFX.Play();
        Destroy(tempVFX.gameObject, tempVFX.main.duration);
    }
}
