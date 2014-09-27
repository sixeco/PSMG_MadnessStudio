using UnityEngine;
using System.Collections;
using iViewX;

public class System_ViewInput : MonoBehaviour {

    public delegate void MouseInputEvent(float xAxis, float yAxis);
    public delegate void GazeInputEvent(Vector2 vector);
    public delegate void CursorEvent(Vector2 pos, string mode);

    public static event MouseInputEvent Mouse;
    public static event GazeInputEvent GazeOnly;

    public bool pauseActive;

    void Start()
    {
        pauseActive = false;
    }
	
	void Update () {
        if (pauseActive == false)
        {
            switch (GameObject.Find("Data").GetComponent<ControlOptions>().SelectedControls)
            {
                case ControlOptions.ControlType.GazeAndMouse:
                    Mouse(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                    break;
                case ControlOptions.ControlType.GazeAndAOI:
                    GazeOnly((gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f);
                    break;
                case ControlOptions.ControlType.MouseOnly:
                    Mouse(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                    break;
            }
        }
	}
}
