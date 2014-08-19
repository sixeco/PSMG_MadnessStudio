using UnityEngine;
using System.Collections;

public class KeyControls : MonoBehaviour {

    public delegate void ShootAction();
    public static event ShootAction RocketLaunch;
    public static event ShootAction CannonShot;
    public static event ShootAction ChangeShotMode;
    
	void Update () {
        if (!GameObject.Find("Turret Manager").GetComponent<TurretStats>().isGazeInputActive)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                CannonShot();
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {
                RocketLaunch();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.J))
            {
                RocketLaunch();
            } 
            if (Input.GetKey(KeyCode.K))
            {
                CannonShot();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeShotMode();
        }
	}
}
