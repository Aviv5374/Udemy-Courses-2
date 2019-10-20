using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    readonly string[] originalPrefabNames = { "Cube From Quads", "Friendly Waypoint" };
    
    TextMesh labelMesh;
    Waypoint waypoint;
    
    void Awake()
    {
        labelMesh = GetComponentInChildren<TextMesh>();
        waypoint = GetComponent<Waypoint>();
       
        VarabelsInitializeCheck();
    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLabelText();
    }

    void VarabelsInitializeCheck()
    {
        if (!labelMesh)
        {
            Debug.LogError("Didn't Find Label!!!!!");
        }

        if (!waypoint)
        {
            Debug.LogError("Didn't Find waypoint!!!!!");
        }
    }

    void SnapToGrid()
    {
        var CoordinateInGrid = waypoint.GridCoordinateVec3Int;
        transform.position = CoordinateInGrid;        
    }

    void UpdateLabelText()
    {        
        var PosInGrid = waypoint.GridPosVec2Int;
        string labelText = PosInGrid.x + "," + PosInGrid.y;        
        labelMesh.text = labelText;
        gameObject.name = labelText;       
    }



}
