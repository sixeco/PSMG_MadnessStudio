using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

    public Camera camera01;
    public Camera camera02;

	void Start () {
        camera01.camera.enabled = true;
        camera02.camera.enabled = false;
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            camera01.camera.enabled = true;
            camera02.camera.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            camera01.camera.enabled = false;
            camera02.camera.enabled = true;
        }
	}
}
