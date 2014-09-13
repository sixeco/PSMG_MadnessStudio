﻿using UnityEngine;
using System.Collections;
using iViewX;

public class System_KeyInput : MonoBehaviour {

    public delegate void SwitchEvent(KeyCode key);
    public static event SwitchEvent S_KeyInput;

    public delegate void ShootEvent(Vector2 position);
    public static event ShootEvent ShootLeft;
    public static event ShootEvent ShootRight;

    private System_Status status;

    void Start()
    {
        status = GameObject.Find("Turret_System").GetComponent<System_Status>();
    }

	void Update () {

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

        if (Input.GetKey(KeyCode.J) || Input.GetMouseButton(0))
        {
            if (status.SelectedControls == System_Status.ControlType.GazeAndAOI || status.SelectedControls == System_Status.ControlType.GazeAndMouse)
            {
                ShootLeft((gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f);
            }
            else
            {
                ShootLeft(new Vector2(Screen.width/2, Screen.height/2));
            }
        }
        if (Input.GetKey(KeyCode.K) || Input.GetMouseButton(1))
        {
            if (status.SelectedControls == System_Status.ControlType.GazeAndAOI || status.SelectedControls == System_Status.ControlType.GazeAndMouse)
            {
                ShootRight((gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f);
            }
            else
            {
                ShootRight(new Vector2(Screen.width / 2, Screen.height / 2));
            }
        }
	}
}
