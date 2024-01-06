using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Tile> path =  new List<Tile>();
    [SerializeField] [Range(0f,5f)] float moveSpeed = 1f;
    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnEnable() {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath()
    {
        path.Clear();

        //Parent object containing paths
        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        //Iterate through paths
        foreach(Transform child in parent.transform)
        {
            Tile waypoint = child.GetComponent<Tile>();
            if(waypoint)
            {
                path.Add(waypoint);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach (Tile waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = new Vector3(waypoint.transform.position.x, transform.position.y, waypoint.transform.position.z);
            float travelPercent = 0f;       //Percentage of distance the enemy has travelled at a certain point
            transform.LookAt(endPosition);
            while (travelPercent < 1f)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                travelPercent += Time.deltaTime * moveSpeed;
                yield return new WaitForEndOfFrame();
            }

        }
        FinishPath();
    }

    private void FinishPath()
    {
        gameObject.SetActive(false);
        enemy.DeductGold();
    }
}
