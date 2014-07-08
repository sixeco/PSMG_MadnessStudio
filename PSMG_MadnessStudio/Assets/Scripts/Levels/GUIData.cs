using UnityEngine;
using System.Collections;

public class GUIData : MonoBehaviour {
    
    public float AoiScaleFactor;
    public float MouseSensitivity;

    void Awake()
    {
        GUIDataStatic.AOIScaleFactor = AoiScaleFactor;
        GUIDataStatic.MouseSensitivity = MouseSensitivity;
    }
}
