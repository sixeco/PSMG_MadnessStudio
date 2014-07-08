using UnityEngine;
using System.Collections;

public class GUIData : MonoBehaviour {
    
    public float AoiScaleFactor;
    public float MouseSensitivity;
    public float GazeSensitivity;

    void Awake()
    {
        GUIDataStatic.AOIScaleFactor = AoiScaleFactor;
        GUIDataStatic.MouseSensitivity = MouseSensitivity;
        GUIDataStatic.GazeSensitivity = GazeSensitivity;
    }
}
