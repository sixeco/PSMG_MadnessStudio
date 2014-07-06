using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {

    void Update()
    {
        MousInputDataStatic.XAxis = Input.GetAxis("Mouse X");
        MousInputDataStatic.YAxis = Input.GetAxis("Mouse Y");
    }
}
