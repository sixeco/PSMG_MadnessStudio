using UnityEngine;
using System.Collections;

public class System_KeyInput : MonoBehaviour {

    public delegate void SwitchEvent(KeyCode key);
    public static event SwitchEvent S_KeyInput;

    public delegate void ShootEvent();
    public static event ShootEvent ShootLeft;
    public static event ShootEvent ShootRight;

	void Start () {
	    
	}

	void Update () {

        //Camera Switch Keys
        if (Input.GetKeyDown(KeyCode.F))
        {
            S_KeyInput(KeyCode.F);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            S_KeyInput(KeyCode.D);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            S_KeyInput(KeyCode.S);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            S_KeyInput(KeyCode.A);
        }

        //Shoot Keys
        else if (Input.GetKeyDown(KeyCode.J))
        {
            ShootLeft();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            ShootRight();
        }
	}
}
