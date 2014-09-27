using UnityEngine;
using System.Collections;

public class ControlOptions : MonoBehaviour {

    public enum ControlType { GazeAndAOI, GazeAndMouse, MouseOnly };
    public ControlType SelectedControls;

    public enum AimCursorType { GUI, LaserPointer };
    public AimCursorType SelectedCursorType;

    public bool AOIVisible;

    void Start()
    {
        if (SelectedControls == ControlType.GazeAndAOI || SelectedControls == ControlType.GazeAndMouse)
        {
            GameObject.Find("GazeController").SetActive(true);
        }
        else
        {
            GameObject.Find("GazeController").SetActive(false);
        }
    }
}
