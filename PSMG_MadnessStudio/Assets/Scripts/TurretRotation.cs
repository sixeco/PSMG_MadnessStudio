using UnityEngine;
using System.Collections;

public class TurretRotation : MonoBehaviour {

    public float RotationSpeed = 3.0f;

	void Update () {
	    if(Input.GetKey(KeyCode.Y))
        {
            transform.Rotate(new Vector3(0, -1, 0) * RotationSpeed, Space.World);
        }
        else if(Input.GetKey(KeyCode.X))
        {
            transform.Rotate(new Vector3(0, 1, 0) * RotationSpeed, Space.World);
        }
	}
}
