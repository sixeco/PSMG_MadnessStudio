using UnityEngine;
using System.Collections;
using iViewX;

public class Turret_ViewControl : MonoBehaviour {

    Rect scaleArea;
    Rect areaLeft;
    Rect areaRight;
    Rect areaTop;
    Rect areaBottom;
    private Texture Filler;

    private Vector2 mainInput;
    private bool areAOIsVisible;

    private float aoiScaleFactor;
    private float maxScale;

    private float rotationSpeed;

    public float mouseSensitivity = 3.0f;
    public float upDownRange = 50.0f;
    public float leftRightRange = 80.0f;
    float verticalRotation = 0.0f;
    float horizontalRotation = 0.0f;

    void Awake()
    {
        
    }

    public void TurnCameraMouse(float xAxis, float yAxis)
    {
        Debug.Log("Turn Camera: " + xAxis + ", " + yAxis);

        horizontalRotation += xAxis * mouseSensitivity;
        horizontalRotation = Mathf.Clamp(horizontalRotation, -leftRightRange, leftRightRange);

        verticalRotation -= yAxis * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);

        gameObject.transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
    }

    public void TurnCameraGaze(Vector2 gazeVector)
    {

    }
}
