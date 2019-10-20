using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    const string parentName = "Enemys";

    [Range(0.1f, 120f)] [SerializeField] float secondBetweenSpawning = 2.25f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] GameObject/*OR Transform*/ enemyParent;
    [SerializeField] AudioClip spawnedEnemySFX;
    [SerializeField] Text spawnEnemyCount;

    int enemyCounter = 0;
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {        
        //A BUG POTENTIAL!!!!
        if (!enemyParent)
        {
            Debug.LogError("CraeteTowerParent() in Start of: " + name);
            CraeteParent();
        }
        spawnEnemyCount.text = enemyCounter.ToString();
        myAudioSource = GetComponent<AudioSource>();
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    #region EnemyParent
    //TODO: Write the full logic

    void FindParent()
    {
        //TODO: Write this metod
        //????????
        //enemyParent = FindObjectOfType<enemyParent>();
        //if (!towerParent)
        //{
        //    CraeteTowerParent();
        //}
        //????????
    }

    void CraeteParent()
    {
        //TODO: Write this metod
        //????????
        //enemyParent = new GameObject(parentName);        
        //????????
    }

    void AddMeToParet()
    {
        //TODO: Write this metod
        //????????
        enemyParent.transform.parent = this.transform;
        //????????
    }

    #endregion

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(secondBetweenSpawning);
        }
    }

    void SpawnEnemies()
    {
        Instantiate(enemyPrefab, enemyParent.transform);
        myAudioSource.PlayOneShot(spawnedEnemySFX);
        CountEnemySpawns();
    }

    void CountEnemySpawns()
    {
        enemyCounter++;
        spawnEnemyCount.text = enemyCounter.ToString();
    }
}
