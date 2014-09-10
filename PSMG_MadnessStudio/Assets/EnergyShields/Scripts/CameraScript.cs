// This script controls the camera

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CameraScript : MonoBehaviour {

	public List<GameObject> View = new List<GameObject>(); //the GameObject that the camera should face

	public int ViewNum = 0;
	public float Speed = 1f; //the speed in which the cannon will rotate around the target
	

    void FixedUpdate()//Update () 
	{
		ViewNum = Mathf.Clamp(ViewNum,0,View.Count -1);

		gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,View[ViewNum].transform.position, 1f * Time.deltaTime);
		gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation,View[ViewNum].transform.rotation, 2f * Time.deltaTime);
		                  
	}
}
