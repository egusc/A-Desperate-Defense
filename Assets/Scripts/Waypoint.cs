using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject turret;

    public bool IsPlaceable{ get {return isPlaceable; } }

    private void OnMouseDown() {
        if(isPlaceable)
        {
            Instantiate(turret, this.transform.position, Quaternion.identity);
            isPlaceable = false;
        }   
    }
}
