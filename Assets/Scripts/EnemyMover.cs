using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    List<Node> path =  new List<Node>();
    [SerializeField] [Range(0f,5f)] float moveSpeed = 1f;
    Enemy enemy;
    GridManager gridManager;
    Pathfinder pathfinder;

    private void OnEnable() {
        ReturnToStart();
        RecalculatePath(true);
    }

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }



    void RecalculatePath(bool resetPath)
    {
        Vector2Int coordinates = new Vector2Int();

        if(resetPath)
        {
            coordinates = pathfinder.StartCoordinates;
        }
        else
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
        }
        StopAllCoroutines();
        path.Clear();
        path = pathfinder.GetNewPath(coordinates);
        StartCoroutine(FollowPath());
    }

    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathfinder.StartCoordinates);
    }

    IEnumerator FollowPath()
    {
        for(int i = 0; i < path.Count - 1; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i + 1].coordinates);
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
