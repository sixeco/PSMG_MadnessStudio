using UnityEngine;
using System.Collections;

public class RotatePlanet : MonoBehaviour {

    public Vector3 rotationDirection;
    public float rotationSpeed;

	void Start () {
	    
	}
	
	void Update () {
        gameObject.transform.Rotate(rotationDirection * rotationSpeed);
	}
}
