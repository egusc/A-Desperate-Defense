using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] Tower turret;

    public bool IsPlaceable{ get {return isPlaceable; } }

    private void OnMouseDown() {
        if(isPlaceable)
        {
            bool isPlaced = turret.CreateTower(turret, transform.position);
            isPlaceable = !isPlaced;
        }   
    }
}
