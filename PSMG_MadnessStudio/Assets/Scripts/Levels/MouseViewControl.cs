using UnityEngine;
using System.Collections;

public class MouseViewControl : MonoBehaviour {

    public float mouseSensitivity = 3.0f;
    public float upDownRange = 70.0f;
    public float leftRightRange = 70.0f;
    float verticalRotation = 0.0f;
    float horizontalRotation = 0.0f;

    Texture crosshairTexture;

	void Start () {
        //crosshairTexture = this.transform.parent.gameObject.transform.parent.GetComponent<;
        Screen.lockCursor = true;
	}
	
	void Update () {
        horizontalRotation += Input.GetAxis("Mouse X") * mouseSensitivity;
        //horizontalRotation = Mathf.Clamp(horizontalRotation, -leftRightRange, leftRightRange);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);

        this.transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
	}

    void OnGUI()
    {
        GUI.DrawTexture(new Rect((Screen.width/2 - crosshairTexture.width/2), (Screen.height/2 - crosshairTexture.height/2), crosshairTexture.width, crosshairTexture.height), crosshairTexture);
    }
}
