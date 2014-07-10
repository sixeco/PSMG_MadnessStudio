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
        if (ActivationDataStatic.isAOIcontrolActive)
        {
            return Input.mousePosition;
        }
        else
        {
            return new Vector3(Screen.width / 2, Screen.height / 2, 0);
        }
    }
}
