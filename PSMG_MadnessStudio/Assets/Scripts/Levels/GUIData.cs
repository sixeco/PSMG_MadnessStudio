using UnityEngine;
using System.Collections;

public class GUIData : MonoBehaviour {
    
    public float AoiScaleFactor;

    void OnEnable()
    {
        AOIControls4Panel.GetScaleFactor += GetFactor; 
    }

    private float GetFactor()
    {
        return AoiScaleFactor;
    }
}
