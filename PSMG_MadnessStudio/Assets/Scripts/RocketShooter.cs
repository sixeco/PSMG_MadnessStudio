using UnityEngine;
using System.Collections;

public class RocketShooter : MonoBehaviour {

    public GameObject rocket;
    public Transform rocketShotPos;

    public AudioClip rocketSound;

	void Update () {
        if (Input.GetButtonDown("Fire2")) 
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 200f)){
                Quaternion rotation = Quaternion.LookRotation((hit.point - (rocketShotPos.transform.position + rocketShotPos.transform.forward)).normalized);
                Instantiate(rocket, rocketShotPos.transform.position + rocketShotPos.transform.forward, rotation);
                audio.clip = rocketSound;
                audio.Play();
            }
        }
	}
}
