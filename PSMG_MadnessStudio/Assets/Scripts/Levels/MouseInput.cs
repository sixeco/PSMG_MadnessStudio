using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {

    void OnEnable()
    {
        MouseViewControl.YInput += GetYInput;
        MouseViewControl.XInput += GetXInput;
    }

    void OnDisable()
    {
        MouseViewControl.YInput -= GetYInput;
        MouseViewControl.XInput -= GetXInput;
    }

    private float GetYInput()
    {
        return Input.GetAxis("Mouse Y");
    }

    private float GetXInput()
    {
        return Input.GetAxis("Mouse X");
    }
}
