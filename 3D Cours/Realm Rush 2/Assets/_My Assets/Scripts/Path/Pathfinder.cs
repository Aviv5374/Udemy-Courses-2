using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;

    bool isRunning = true;
    bool isFoundEnd = false;
    Waypoint currentSearchCenter;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> waypointsQueue = new Queue<Waypoint>();
    List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directionsVec2 =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    Vector3Int[] directionsVec3 =
    {
        Vector3Int.FloorToInt(Vector3.forward),
        Vector3Int.right,
        Vector3Int.FloorToInt(Vector3.back),
        Vector3Int.left
    };

    public List<Waypoint> Path {
        get 
        {
            if (path.Count <= 0)
            {
                CreatePath();
            }
            return path; 
        } 
    
        // set{ path = value; }
    
    }

    void Awake()
    {
        //in the edior that a 4 second delay between click the play button and the game playing.
        //TODO: Find why it is and if its only in the edior (make a build). 
        LoadBlocks();
        //ColorStartAndEnd();//Apart from debugging, this line or/and method has another purpose??
        BreadthFirstSearch();       
    }

    void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GridPosVec2Int;
            bool isGridPosOverlappingWithExistentingKey = grid.ContainsKey(gridPos);
            //if (!isGridPosOverlappingWithExistentingKey)
            //{
            //    grid.Add(gridPos, waypoint);
            //}

            #region Debug Code

            if (isGridPosOverlappingWithExistentingKey)
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            }
            else
            {                
                grid.Add(gridPos, waypoint);
            }
            
            #endregion

        }
        Debug.Log("Loaded " + grid.Count + " blocks");
    }

    void ColorStartAndEnd()
    {
        // todo consdier moving out
        startWaypoint.SetTopColor(Color.white);
        endWaypoint.SetTopColor(Color.black);
    }

    #region Breadth Search Methodes

    void BreadthFirstSearch()
    {
        waypointsQueue.Enqueue(startWaypoint);

        while (waypointsQueue.Count > 0 && !isFoundEnd)
        {
            currentSearchCenter = waypointsQueue.Dequeue();
            currentSearchCenter.isExplored = true;
            //Debug.Log("Searching from: " + currentSearchCenter);

            isFoundEnd = currentSearchCenter == endWaypoint;
            if (isFoundEnd) { break; }
            //Or 
            //HaltIfEndFound()

            //In All Cases
            ExploreNeighbours();
        }       
    }

    void HaltIfEndFound()//?????????
    {
        isFoundEnd = currentSearchCenter == endWaypoint;

        if (isFoundEnd)
        {
            // Debug.Log("Searching from end node, therefore stopping"); // todo remove log
            isRunning = false;//??????            
        }
    }

    void ExploreNeighbours()
    {
        if (isFoundEnd) { return; }

        foreach (Vector2Int exploredDirection in directionsVec2)
        {
            Vector2Int neighbourGridPos = currentSearchCenter.GridPosVec2Int + exploredDirection;
            if (grid.ContainsKey(neighbourGridPos))
            {
                QueueNewNeighbours(neighbourGridPos);
            }
        }
    }

    void QueueNewNeighbours(Vector2Int neighbourGridPos)
    {
        Waypoint neighbour = grid[neighbourGridPos];
        if (!neighbour.isExplored && !waypointsQueue.Contains(neighbour))
        {
            // neighbour.SetTopColor(Color.magenta);
            waypointsQueue.Enqueue(neighbour);
            //Debug.Log("Queueing " + neighbour);
            neighbour.exploredFrom = currentSearchCenter;
        }
    }

    #endregion

    void CreatePath()
    {
        SetAsPath(endWaypoint);
        Waypoint previous = endWaypoint.exploredFrom;

        while (previous != startWaypoint)
        {
            SetAsPath(previous);
            previous = previous.exploredFrom;
        }

        SetAsPath(startWaypoint);
        path.Reverse();
    }

    void SetAsPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceable = false;
    }
}
