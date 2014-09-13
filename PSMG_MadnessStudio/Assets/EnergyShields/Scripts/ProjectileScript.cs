//this script destroy the projectile after one minute
//this will make sure the program does not overload with objects

using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

	public float LifeTime = 60;
	public float CreatedTime;


	void Start () 
	{
		CreatedTime = Time.time;
	}

	void Update () 
	{
		if (Time.time-CreatedTime > LifeTime)
		{
			Destroy(gameObject);
		}
	}
}
