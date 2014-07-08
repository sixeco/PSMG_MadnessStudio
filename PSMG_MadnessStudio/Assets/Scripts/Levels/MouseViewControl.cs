using UnityEngine;
using System.Collections;

public class MouseViewControl : MonoBehaviour {

    public float mouseSensitivity = 3.0f;
    public float upDownRange = 70.0f;
    public float leftRightRange = 70.0f;
    float verticalRotation = 0.0f;
    float horizontalRotation = 0.0f;

	void Start () {
        if (ActivationDataStatic.isGazeInputActive || ActivationDataStatic.isAOIcontrolActive)
        {
            this.enabled = false;
        }
        else
        {
            this.enabled = true;
        }
        mouseSensitivity = GUIDataStatic.MouseSensitivity;
	}
	
	void Update () {
        horizontalRotation += MousInputDataStatic.XAxis * mouseSensitivity;
        //horizontalRotation = Mathf.Clamp(horizontalRotation, -leftRightRange, leftRightRange);

        verticalRotation -= MousInputDataStatic.YAxis * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);

        this.transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
	}
}
