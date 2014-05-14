using UnityEngine;
using System.Collections;

public class cam_movement : MonoBehaviour {

    public float moveSpeed = 10.0f;

	void Update () {

        float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(new Vector3(h, v, 0));
	}
}
