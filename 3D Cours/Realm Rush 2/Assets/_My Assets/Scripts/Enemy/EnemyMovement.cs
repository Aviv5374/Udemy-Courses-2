using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = 0.5f;
    [SerializeField] ParticleSystem goalVFX;
    
    //List<Waypoint> myPath = new List<Waypoint>();??????
   
    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Waypoint> myPath = pathfinder.Path;
        //in the edior that a 4 second delay between click the play button and the game playing.
        //TODO: Find why it is and if its only in the edior (make a build).  
        //TODO: Find What is more performance friendly
        StartCoroutine(FollowPath(myPath));//OR StartCoroutine(FollowPath(pathfinder.Path;));
    }
    
    void PrintAllWaypoints(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            Debug.Log(waypoint.name);
        }
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        //Debug.Log("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            this.transform.position = waypoint.transform.position;           
            yield return new WaitForSeconds(movementPeriod);            
        }
        //Debug.Log("Ending patrol");
        SendMessage("OnEnemyDeath", goalVFX);       
    }

}
