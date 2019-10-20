using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSite : MonoBehaviour
{    
    [SerializeField] TowerFactory towerFactory;    

    Vector3 towerPlacement;

    public bool isPlaceable = true;

    public Vector3 TowerPlacement
    {
        get { return towerPlacement; }
    }

    void Start()
    {       
        towerPlacement = new Vector3(this.transform.position.x, 0, this.transform.position.z);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            if (isPlaceable)
            {
                //Debug.Log(gameObject.name + " tower placement");
                towerFactory.AddTower(this);
            }
            else
            {
                Debug.Log("Can't place here");
            }
        }
    }
        
}
