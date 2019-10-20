using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const string topQuadName = "Top Quad";
    const int gridSize = 10;

    // public ok here as is a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    public Vector2Int GridPosVec2Int 
    { 
        get 
        {
            return new Vector2Int(
              Mathf.RoundToInt(transform.position.x / gridSize),
              Mathf.RoundToInt(transform.position.z / gridSize));
        }        
    }

    public Vector2Int GridCoordinateVec2Int
    {
        get
        {
            return GridPosVec2Int * gridSize;
        }
    }

    public Vector3Int GridPosVec3Int
    {
        get
        {
            return new Vector3Int(
              Mathf.RoundToInt(transform.position.x / gridSize),
              0,
              Mathf.RoundToInt(transform.position.z / gridSize));
        }
    }

    public Vector3Int GridCoordinateVec3Int
    {
        get
        {
            return GridPosVec3Int * gridSize;
        }
    }

    public int GetGridSizeValue()
    {
        return gridSize;
    }

    // consider setting own color in Update()
    public void SetTopColor(Color otherColor)
    {
        MeshRenderer topMeshRenderer = transform.Find(topQuadName).GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = otherColor;
    }

    //I Use the Neutral Blocks as Build Site because it more easy
    //if I change my mind I need to add a "BuildSite" sctipt and change all The "waypoint.isPlaceable" references in the cod,
    //and add a BoxCollider that her m_Size: {x: 10, y: 10, z: 10} & her m_Center: {x: 0, y: -5, z: 0}
    /*
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            if (isPlaceable)
            {
                Debug.Log(gameObject.name + " tower placement");
            }
            else
            {
                Debug.Log("Can't place here");
            }
        }
    }
    */

}
