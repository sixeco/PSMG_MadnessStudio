using UnityEngine;
using System.Collections;

public class System_KeyInput : MonoBehaviour {

    public delegate void KeyEvent(KeyCode key);
    public static event KeyEvent S_KeyInput;
    public static event KeyEvent ShootInput;

	void Start () {
	    
	}

	void Update () {
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
	}
}
