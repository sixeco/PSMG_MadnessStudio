using UnityEngine;
using System.Collections;

public class MouseViewControl : MonoBehaviour {

    public float mouseSensitivity = 3.0f;
    public float upDownRange = 70.0f;
    public float leftRightRange = 70.0f;
    float verticalRotation = 0.0f;
    float horizontalRotation = 0.0f;

    GUIData guiData;

	void Start () {
        TurretStats stats = GameObject.Find("Turret Manager").GetComponent<TurretStats>();
        //guiData = GameObject.Find("Data").GetComponent<GUIData>().
        if (stats.isGazeInputActive || stats.isAOIcontrolActive)
        {
            this.enabled = false;
        }
        else
        {
            this.enabled = true;
        }
        mouseSensitivity = GameObject.Find("Data").GetComponent<GUIData>().MouseSensitivity;
	}
	
	void Update () {
        //horizontalRotation += MousInputDataStatic.XAxis * mouseSensitivity;
        //horizontalRotation = Mathf.Clamp(horizontalRotation, -leftRightRange, leftRightRange);

        //verticalRotation -= MousInputDataStatic.YAxis * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);

        this.transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
	}
}
