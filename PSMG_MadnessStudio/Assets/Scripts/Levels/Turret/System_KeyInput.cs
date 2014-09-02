using UnityEngine;
using System.Collections;

public class System_KeyInput : MonoBehaviour {

    public delegate void SwitchEvent(KeyCode key);
    public static event SwitchEvent S_KeyInput;

    public delegate void ShootEvent();
    public static event ShootEvent ShootLeft;
    public static event ShootEvent ShootRight;

    private bool gazeActive;

	void Start () {
        gazeActive = GameObject.Find("Turret_System").GetComponent<System_Status>().GazeAndAIO;
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

        if (gazeActive)
        {
            //Shoot Keys
            if (Input.GetKey(KeyCode.J))
            {
                ShootLeft();
            }
            else if (Input.GetKey(KeyCode.K))
            {
                ShootRight();
            }
        }
        else
        {
            //Shoot with mouse
            if (Input.GetMouseButton(0))
            {
                ShootRight();
            }
            else if (Input.GetMouseButton(1))
            {
                ShootLeft();     
            }
        }
	}
}
