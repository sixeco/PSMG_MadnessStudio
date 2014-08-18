using UnityEngine;
using System.Collections;
using iViewX;

public class System_ViewInput : MonoBehaviour {

    public delegate void MouseInputEvent(float xAxis, float yAxis);
    public delegate void GazeInputEvent(Vector2 vector);
    public static event MouseInputEvent Mouse;
    public static event GazeInputEvent Gaze;

    bool GazeAndMouse;
    bool GazeAndAOI;
    bool MouseOnly;

	void Start () {
        GazeAndMouse = this.GetComponent<System_Status>().GazeAndMouse;
        GazeAndAOI = this.GetComponent<System_Status>().GazeAndAIO;
        MouseOnly = this.GetComponent<System_Status>().MouseOnly;
	}
	
	void Update () {
        if (GazeAndMouse)
        {
            Mouse(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            Gaze((gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f);
        }
        else if (GazeAndAOI)
        {
            Gaze((gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f);
        }
        else if (MouseOnly)
        {
            Mouse(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }
	}
}
