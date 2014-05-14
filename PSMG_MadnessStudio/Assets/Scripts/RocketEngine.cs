using UnityEngine;
using System.Collections;

public class RocketEngine : MonoBehaviour {

    public float speed = 10.0f;

	void FixedUpdate () {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        //rigidbody.AddForce(transform.forward * speed);
	}
}
