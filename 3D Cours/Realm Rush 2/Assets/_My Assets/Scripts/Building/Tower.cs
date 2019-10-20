using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //in the edior that a 4 second delay between click the play button and the game playing.
    //TODO: Find why it is and if its only in the edior (make a build). 

    // Paramaters of each tower
    [SerializeField] float fireRange = 17;    
    [SerializeField] Transform objectToPan;
    [SerializeField] EnemySpawner enemySpawner;

    // State of each tower
    Transform targetEnemy = null;
    ParticleSystem bulletsParticle;

    public BuildSite myBuildSite;

    void Awake()
    {
        //Debug.Log("the Distance between " + name + " and " + targetEnemy.name +
          // " is: " + Vector3.Distance(targetEnemy.position, transform.position));
        bulletsParticle = GetComponentInChildren<ParticleSystem>();
        Shoot(false);
        
    }

    void Start()
    {
        if (!enemySpawner)
        {
            enemySpawner = FindObjectOfType<EnemySpawner>();
        }
        SetTargetEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
            SetTargetEnemy();
        }
    }

    #region SetEnemy
    //Link To the Cours version: https://github.com/CompleteUnityDeveloper2/5_Realm_Rush/blob/7e391f53d3ef6814078a2241df7637195868a61b/Assets/Scripts/Tower.cs

    void SetTargetEnemy()
    {
        var allEnemysInScene = enemySpawner.GetComponentsInChildren<EnemyDamage>();

        if (allEnemysInScene.Length == 0)
        {
            //Debug.LogWarning("NO ENEMYS IN THE SCENE!!!! given by " + name);
            return;
        }

        targetEnemy = allEnemysInScene[0].transform;

        foreach (EnemyDamage enemy in allEnemysInScene)
        {
            //Transform nextEnemy = enemy.transform;????
            SetClosestEnemy(targetEnemy, enemy.transform);           
        }
        //OR
        /*
        for (int index = 1; index < allEnemys.Length; index++)
        {
            //Transform nextEnemy = allEnemys[index].transform;????
            SetClosestEnemy(targetEnemy, allEnemys[index].transform);   
        }
        */
    }

    void SetClosestEnemy(Transform currentEnemy , Transform nextEnemy)
    {
        float distanceToPreviousEnemy = Vector3.Distance(currentEnemy.position, this.transform.position);
        float distanceToNextEnemy = Vector3.Distance(nextEnemy.position, this.transform.position);
        if (distanceToNextEnemy <= fireRange && distanceToNextEnemy < distanceToPreviousEnemy)
        {
            targetEnemy = nextEnemy;
        }               
    }

    #endregion

    void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.position, transform.position);
        if (distanceToEnemy <= fireRange)
        {
            Shoot(true);
        }
        else
        {
            targetEnemy = null;
            Shoot(false);
        }
    }

    void Shoot(bool isActive)
    {
        var emissionModule = bulletsParticle.emission;
        emissionModule.enabled = isActive;
        //The above code is better than "bulletsParticle.gameObject.SetActive();",
        //because it seems more natural during gamePlay.
    }
}
