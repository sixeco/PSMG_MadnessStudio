using UnityEngine;
using System.Collections;

public class System_Status : MonoBehaviour {

    public bool GazeAndAIO;
    public bool GazeAndMouse;
    public bool MouseOnly;
    public bool AOIVisible;

    public string currentStatus;

    void Awake()
    {
        if (GazeAndAIO)
        {
            GazeAndMouse = false;
            MouseOnly = false;
        }
        else if (GazeAndMouse)
        {
            GazeAndAIO = false;
            MouseOnly = false;
        }
        else if (MouseOnly)
        {
            GazeAndAIO = false;
            GazeAndMouse = false;
            //AOIVisible = false;
        }
    }
}
