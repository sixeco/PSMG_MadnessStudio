using UnityEngine;
using System.Collections;

public class RestartScene : MonoBehaviour {

	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            Application.LoadLevel(Application.loadedLevelName);
        }	
	}
}
