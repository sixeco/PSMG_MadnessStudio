using UnityEngine;
using System.Collections;

public class TurretSwitch : MonoBehaviour {

    public Camera[] turrets;

    /*
	void Start () {
        setActivation(turrets[0], true);
        setActivation(turrets[1], false);
        setActivation(turrets[2], false);
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            setActivation(turrets[0], true);
            setActivation(turrets[1], false);
            setActivation(turrets[2], false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            setActivation(turrets[0], false);
            setActivation(turrets[1], true);
            setActivation(turrets[2], false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            setActivation(turrets[0], false);
            setActivation(turrets[1], false);
            setActivation(turrets[2], true);
        }
	}

    private void setActivation(Camera turret, bool mode)
    {
        turret.camera.enabled = mode;
        turret.GetComponent<GUILayer>().enabled = mode;
        turret.GetComponent<AudioListener>().enabled = mode;
        turret.GetComponent<IsTurretActive>().SetAcivation(mode);
    }*/
}
