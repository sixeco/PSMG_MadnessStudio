using UnityEngine;
using System.Collections;

public class GUIData : MonoBehaviour {
    
    public float AoiScaleFactor;
    public float MouseSensitivity;

    void Start()
    {
        GUIDataStatic.AOIScaleFactor = AoiScaleFactor;
        GUIDataStatic.MouseSensitivity = MouseSensitivity;
    }
}
