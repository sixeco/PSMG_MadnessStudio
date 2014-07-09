using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {

    void OnEnable()
    {
        TwinCannon.MainInput += GetMouseInput;
        RocketLauncher.MainInput += GetMouseInput;
    }

    void OnDisable()
    {
        TwinCannon.MainInput -= GetMouseInput;
        RocketLauncher.MainInput -= GetMouseInput;
    }

    void Update()
    {
        MousInputDataStatic.XAxis = Input.GetAxis("Mouse X");
        MousInputDataStatic.YAxis = Input.GetAxis("Mouse Y");
    }

    Vector3 GetMouseInput()
    {
        return Input.mousePosition;
    }
}
