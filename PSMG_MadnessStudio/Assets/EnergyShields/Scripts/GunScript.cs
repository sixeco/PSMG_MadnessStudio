//The GunScript produces the RayCast 

using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {


	public GameObject Target;//the GameObject that the cannon should face

	public float Rate; //the rate in which projectiles are shot
	public float LastShotTime = 0f; //this stores the time when each projectile is shot
	
	public float Speed;//the speed in which the cannon will rotate around the target
	
	
	void Update () 
	{
		if (Time.time - LastShotTime >= Rate)//determine if a shot should be fired
		{
			RaycastHit hit;
			Vector3 fwd = transform.TransformDirection(Vector3.forward);

			if (Physics.Raycast(transform.position, fwd, out hit)) //determine if the raycast hit something
			{
				if (hit.collider.gameObject.tag == "Shield") //if the raycast hit the shield
				{
					GameObject Shield = hit.collider.gameObject;

					Shield.GetComponent<ShieldEffectScript>().HitbyRayCast(hit.point); //use the "HitByGun" method to produce effect


				}
			}	

			//Draw the raycast line for debugging
			Debug.DrawLine (transform.position, hit.point, Color.cyan);

			LastShotTime = Time.time; //set the time when the shot was produced
		}

		//rotate the gun to look at the target object
		Vector3 dir = Target.transform.position - transform.position;
		Quaternion Rotation = Quaternion.LookRotation(dir);
		gameObject.transform.rotation = Rotation;

		//rotate the cannon around the target
		transform.RotateAround(Target.transform.position,new Vector3(0f,1f,0f), Speed * Time.deltaTime);
//
	}
}
