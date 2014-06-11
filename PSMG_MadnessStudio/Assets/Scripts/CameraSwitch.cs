using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

    public Camera[] turrets;

	void Start () {

        setActivation(turrets[0], true);
        setActivation(turrets[1], false);
        setActivation(turrets[2], false);
        setActivation(turrets[3], false);

	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            setActivation(turrets[0], true);
            setActivation(turrets[1], false);
            setActivation(turrets[2], false);
            setActivation(turrets[3], false);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            setActivation(turrets[0], false);
            setActivation(turrets[1], true);
            setActivation(turrets[2], false);
            setActivation(turrets[3], false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            setActivation(turrets[0], false);
            setActivation(turrets[1], false);
            setActivation(turrets[2], true);
            setActivation(turrets[3], false);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            setActivation(turrets[0], false);
            setActivation(turrets[1], false);
            setActivation(turrets[2], false);
            setActivation(turrets[3], true);
        }
	}

    private void setActivation(Camera turret, bool mode)
    {
        turret.camera.enabled = mode;
        turret.GetComponent<TurretActivation>().isActive = mode;
        turret.GetComponent<AudioListener>().enabled = mode;
    }
}
