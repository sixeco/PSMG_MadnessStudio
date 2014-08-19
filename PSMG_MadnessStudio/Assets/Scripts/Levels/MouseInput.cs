using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {

    public float XAxis;
    public float YAxis;

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
        XAxis = Input.GetAxis("Mouse X");
        YAxis = Input.GetAxis("Mouse Y");
    }

    Vector3 GetMouseInput()
    {
        if (GameObject.Find("Turret Manager").GetComponent<TurretStats>().isAOIcontrolActive)
        {
            return Input.mousePosition;
        }
        else
        {
            return new Vector3(Screen.width / 2, Screen.height / 2, 0);
        }
    }
}
