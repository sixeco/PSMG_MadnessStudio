using UnityEngine;
using System.Collections;

public class Cobra_ProjEngine : MonoBehaviour {

    float speed;
    float LifeTime = 1;
    float createdTime;

	void Start () {
        speed = GameObject.Find("Data").GetComponent<WeaponsData>().CobraProjectileSpeed;
        createdTime = Time.time;
	}
	
	void FixedUpdate () {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        if (Time.time - createdTime > LifeTime)
        {
            Destroy(gameObject);
        }
	}
}
