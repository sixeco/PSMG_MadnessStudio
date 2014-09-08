using UnityEngine;
using System.Collections;
using iViewX;

public class System_ViewInput : MonoBehaviour {

    public delegate void MouseInputEvent(float xAxis, float yAxis);
    public delegate void GazeInputEvent(Vector2 vector);
    public delegate void CursorEvent(Vector2 pos, string mode);

    public static event MouseInputEvent Mouse;
    public static event GazeInputEvent GazeOnly;
    public static event CursorEvent DrawCursor;
	
	void Update () {

        switch (GameObject.Find("Turret_System").GetComponent<System_Status>().SelectedControls)
        {
            case System_Status.ControlType.GazeAndMouse:
                Mouse(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                break;
            case System_Status.ControlType.GazeAndAOI:
                GazeOnly((gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f);
                break;
            case System_Status.ControlType.MouseOnly:
                Mouse(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                break;
        }
	}
}
