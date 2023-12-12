using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class ScriptCoordinateLabeller : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinate = new Vector2Int();

    private void Awake() {
        label = GetComponent<TextMeshPro>();    
        DisplayCurrentCoordinates();
        UpdateObjectName();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)
        {
            //Do thing while application not running
            DisplayCurrentCoordinates();
            UpdateObjectName();
        }
    }

    void DisplayCurrentCoordinates()
    {
        coordinate.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinate.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = String.Format("({0},{1})", coordinate.x, coordinate.y);
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinate.ToString();
    }
}
