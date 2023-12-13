using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class ScriptCoordinateLabeller : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockColor = Color.grey;

    TextMeshPro label;
    Vector2Int coordinate = new Vector2Int();
    Waypoint waypoint;

    private void Awake() {
        label = GetComponent<TextMeshPro>();    
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCurrentCoordinates();
        UpdateObjectName();
        label.enabled = false;
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

        ColorCoordinates();
        ToggleLabels();
    }

    void ColorCoordinates()
    {
        if(waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockColor;
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

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }
}
