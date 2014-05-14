using UnityEngine;
using System.Collections;

public class Pulse : MonoBehaviour {

    public float rotationSpeed = 10.0f;
    public float pulseSpeed = 0.5f;

    private float pulse = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rotationV = new Vector3(0, rotationSpeed, 0);
        gameObject.transform.Rotate(rotationV);
        Vector3 pulseV = new Vector3(Mathf.Sin(pulse), Mathf.Sin(pulse), Mathf.Sin(pulse));
        gameObject.transform.localScale = (pulseV);
        pulse += pulseSpeed;
        if(pulse == 100.0f){
            pulse = 0;
        }
	}
}
