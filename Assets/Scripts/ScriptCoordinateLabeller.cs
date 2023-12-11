using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class ScriptCoordinateLabeller : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinate = new Vector2Int();

    private void Awake() {
        label = GetComponent<TextMeshPro>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)
        {
            //Do thing while application not running
            DisplayCurrentCoordinates();
        }
    }

    void DisplayCurrentCoordinates()
    {
        label.text = "(-,-)";
    }
}
