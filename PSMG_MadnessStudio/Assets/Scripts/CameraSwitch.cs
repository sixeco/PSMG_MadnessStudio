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
        if (Input.GetKeyDown(KeyCode.A))
        {
            setActivation(turrets[0], true);
            setActivation(turrets[1], false);
            setActivation(turrets[2], false);
            setActivation(turrets[3], false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            setActivation(turrets[0], false);
            setActivation(turrets[1], true);
            setActivation(turrets[2], false);
            setActivation(turrets[3], false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            setActivation(turrets[0], false);
            setActivation(turrets[1], false);
            setActivation(turrets[2], true);
            setActivation(turrets[3], false);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            setActivation(turrets[0], false);
            setActivation(turrets[1], false);
            setActivation(turrets[2], false);
            setActivation(turrets[3], true);
        }
	}

    private void setActivation(Camera turret, bool mode)
    {
        turret.GetComponent<Camera>().enabled = mode;
        turret.GetComponent<TurretActivation>().isActive = mode;
        turret.GetComponent<AudioListener>().enabled = mode;
    }
}
