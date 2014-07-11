using UnityEngine;
using System.Collections;

public class AIRotate : MonoBehaviour {

    public float RotationSpeed = 10.0f;
    public bool CounterClockWise = false;
    private Vector3 rotation;

	void Start () {
        rotation = new Vector3(0, 0, 0);
	}
	
	void Update () {
        if (CounterClockWise)
        {
            rotation.y -= RotationSpeed * Time.deltaTime;
        }
        else
        {
            rotation.y += RotationSpeed * Time.deltaTime;
        }
        gameObject.transform.localRotation = Quaternion.Euler(rotation);
	}
}
