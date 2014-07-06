using UnityEngine;
using System.Collections;

public class MouseViewControl : MonoBehaviour {

    public delegate float InputEvent();
    public static event InputEvent YInput;
    public static event InputEvent XInput;

    public delegate Texture AssetEvent();
    public static event AssetEvent CrossHairTexture;

    public float mouseSensitivity = 3.0f;
    public float upDownRange = 70.0f;
    public float leftRightRange = 70.0f;
    float verticalRotation = 0.0f;
    float horizontalRotation = 0.0f;

    Texture crosshairTexture;

	void Start () {
        this.enabled = !this.transform.parent.gameObject.transform.parent.GetComponent<TurretStats>().isGazeInputActive;
        crosshairTexture = CrossHairTexture();
        Screen.lockCursor = true;
	}
	
	void Update () {
        horizontalRotation += XInput() * mouseSensitivity;
        //horizontalRotation = Mathf.Clamp(horizontalRotation, -leftRightRange, leftRightRange);

        verticalRotation -= YInput() * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);

        this.transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
	}

    void OnGUI()
    {
        GUI.DrawTexture(new Rect((Screen.width/2 - crosshairTexture.width/2), (Screen.height/2 - crosshairTexture.height/2), crosshairTexture.width, crosshairTexture.height), crosshairTexture);
    }
}
