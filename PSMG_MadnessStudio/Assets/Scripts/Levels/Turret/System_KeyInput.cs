using UnityEngine;
using System.Collections;
using iViewX;

public class System_KeyInput : MonoBehaviour {

    public delegate void SwitchEvent(KeyCode key);
    public static event SwitchEvent S_KeyInput;

    public delegate void ShootEvent(Vector2 position);
    public static event ShootEvent ShootLeft;
    public static event ShootEvent ShootRight;

    public delegate void LookEvent();
    public static event LookEvent ResetCamera;

    private ControlOptions controls;

    public bool pauseActive;

    void Start()
    {
        controls = GameObject.Find("Data").GetComponent<ControlOptions>();
        pauseActive = false;
    }

	void Update () {

        if (pauseActive == false)
        {
            //Camera Switch Keys
            if (Input.GetKeyDown(KeyCode.F))
            {
                S_KeyInput(KeyCode.F);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                S_KeyInput(KeyCode.D);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                S_KeyInput(KeyCode.S);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                S_KeyInput(KeyCode.A);
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetMouseButton(0))
            {
                if (controls.SelectedControls == ControlOptions.ControlType.GazeAndAOI || controls.SelectedControls == ControlOptions.ControlType.GazeAndMouse)
                {
                    ShootLeft((gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f);
                }
                else
                {
                    ShootLeft(new Vector2(Screen.width / 2, Screen.height / 2));
                }
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetMouseButton(1))
            {
                if (controls.SelectedControls == ControlOptions.ControlType.GazeAndAOI || controls.SelectedControls == ControlOptions.ControlType.GazeAndMouse)
                {
                    ShootRight((gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f);
                }
                else
                {
                    ShootRight(new Vector2(Screen.width / 2, Screen.height / 2));
                }
            }
            if (Input.GetKey(KeyCode.Space))
            {
                ResetCamera();
            }
        }
	}
}
