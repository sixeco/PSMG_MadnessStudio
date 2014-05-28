using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

    public Texture cursor;

    public float mouseSensitivity = 3.0f;
    public float upDownRange = 70.0f;
    public float leftRightRange = 70.0f;
    float verticalRotation = 0.0f;
    float horizontalRotation = 0.0f;

    void Start()
    {
        Screen.lockCursor = true;
    }

	void Update () {

        horizontalRotation += Input.GetAxis("Mouse X") * mouseSensitivity;
        horizontalRotation = Mathf.Clamp(horizontalRotation, -leftRightRange, leftRightRange);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        
        //gameObject.transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
	}
}
