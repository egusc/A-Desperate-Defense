using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path =  new List<Waypoint>();
    [SerializeField] float waitTime = 1f;

    private void Start() {
        StartCoroutine(FollowPath());
    }
    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            this.transform.position = new Vector3(waypoint.transform.position.x,transform.position.y, waypoint.transform.position.z);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
