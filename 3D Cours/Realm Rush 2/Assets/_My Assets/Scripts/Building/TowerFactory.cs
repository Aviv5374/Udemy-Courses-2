using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    const string towerParentName = "Towers";

    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] GameObject/*OR Transform*/ towerParent;

    BuildSite[] buildSites;
    Queue<Tower> towers = new Queue<Tower>(); 

    void Start()
    {
        //A BUG POTENTIAL!!!!
        if (!towerParent)
        {
            Debug.LogError("CraeteTowerParent() in Start of: " + name);
            CraeteTowerParent();
        }

        buildSites = GetComponentsInChildren<BuildSite>();
    }

    #region TowerParent
    //TODO: Write the full logic

    void FindTowerParent()
    {
        //TODO: Write this metod
        //????????
        //towerParent = FindObjectOfType<towerParent>();
        //if (!towerParent)
        //{
        //    CraeteTowerParent();
        //}
        //????????
    }

    void CraeteTowerParent()
    {
        //TODO: Write this metod
        //????????
        //towerParent = new GameObject(towerParentName);
        //towerParent.AddComponent<TowerFactory>();
        //????????
    }

    void AddMeToParet()
    {
        //TODO: Write this metod
        //????????
        towerParent.transform.parent = this.transform;
        //????????
    }

    #endregion

    public void AddTower(BuildSite buildSite)
    {
        if (towers.Count < towerLimit)
        {
            InstantiateNewTower(buildSite);
        }
        else
        {
            MoveExistingTower(buildSite);
        }
    }

    void InstantiateNewTower(BuildSite buildSite)
    {
        buildSite.isPlaceable = false;
        var newTower = Instantiate(towerPrefab, buildSite.TowerPlacement, Quaternion.identity, towerParent.transform);
        newTower.myBuildSite = buildSite;
        towers.Enqueue(newTower);
        
    }

    void MoveExistingTower(BuildSite newBuildSite)
    {        
        var oldTower = towers.Dequeue();

        oldTower.myBuildSite.isPlaceable = true;
        newBuildSite.isPlaceable = false;

        oldTower.myBuildSite = newBuildSite;
        oldTower.transform.position = newBuildSite.TowerPlacement;

        towers.Enqueue(oldTower);
    }
   
}
