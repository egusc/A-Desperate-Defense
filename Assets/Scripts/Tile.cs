using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] bool isPlaceable;

     public bool IsPlaceable{ get {return isPlaceable; } }

    [SerializeField] Tower turret;

    GridManager gridManager;
    Pathfinder pathfinder;
    Vector2Int coordinates = new Vector2Int();

    private void Awake() 
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

   private void Start() 
   {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
            
            if(coordinates == pathfinder.StartCoordinates || coordinates == pathfinder.DestinationCoordinates)
            {
                isPlaceable = false;
            }

            if(!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        } 
   }

    private void OnMouseDown() {
        if(gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            bool isSuccessful = turret.CreateTower(turret, transform.position);
            
            if(isSuccessful)
            {
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyReceivers();
            }
            
        }   
    }
}
