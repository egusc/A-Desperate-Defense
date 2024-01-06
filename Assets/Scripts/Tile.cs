using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] bool isPlaceable;

     public bool IsPlaceable{ get {return isPlaceable; } }

    [SerializeField] Tower turret;

    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();

    private void Awake() 
    {
        gridManager = FindObjectOfType<GridManager>();
    }

   private void Start() 
   {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
            
            if(!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        } 
   }

    private void OnMouseDown() {
        if(isPlaceable)
        {
            bool isPlaced = turret.CreateTower(turret, transform.position);
            isPlaceable = !isPlaced;
        }   
    }
}
