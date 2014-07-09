using UnityEngine;
using System.Collections;

public class KeyControls : MonoBehaviour {

    public delegate void ShootAction();
    public static event ShootAction RocketLaunch;
    public static event ShootAction CannonShot;

	void Start () {
	
	}
    
	void Update () {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            CannonShot();
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            RocketLaunch();
        }
	}
}
