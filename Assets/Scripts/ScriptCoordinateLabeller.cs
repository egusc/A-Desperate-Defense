using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class ScriptCoordinateLabeller : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockColor = Color.grey;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f,0f,0.5f);


    TextMeshPro label;
    Vector2Int coordinate = new Vector2Int();
    GridManager gridManager;


    private void Awake() {
        gridManager = FindObjectOfType<GridManager>();

        label = GetComponent<TextMeshPro>();    
        DisplayCurrentCoordinates();
        UpdateObjectName();
        label.enabled = true;
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

        SetLabelColor();
        ToggleLabels();
    }

    void SetLabelColor()
    {
        if(gridManager == null) {return;}

        Node node = gridManager.GetNode(coordinate);

        if(node == null) {return;}

        if(!node.isWalkable)
        {
            label.color = blockColor;
        }

        else if (node.isPath)
        {
            label.color = pathColor;
        }
        else if(node.isExplored)
        {
            label.color = exploredColor;
        }
        else{
            label.color = defaultColor;
        }
    }

    void DisplayCurrentCoordinates()
    {
        if(gridManager == null) {return;}
        coordinate.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        coordinate.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);
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
