using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path =  new List<Waypoint>();
    [SerializeField] [Range(0f,5f)] float moveSpeed = 1f;

    private void Start() {
        StartCoroutine(FollowPath());
    }
    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = new Vector3(waypoint.transform.position.x,transform.position.y, waypoint.transform.position.z);
            float travelPercent = 0f;       //Percentage of distance the enemy has travelled at a certain point
            transform.LookAt(endPosition);
            while(travelPercent < 1f)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                travelPercent += Time.deltaTime * moveSpeed;
                yield return new WaitForEndOfFrame();
            }
            
        }
    }
}
