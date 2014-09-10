//The CannonScript produces the projectiles 

using UnityEngine;
using System.Collections;

public class CannonScript : MonoBehaviour {


	public GameObject Target; //the GameObject that the cannon should face

	public GameObject Projectile; //This is the GameObject that the Cannon Fires
	public float ProjectileForce; //The Force that the projectile is shot at
	public float Scatter; //How randomly the shots are fired

	public float Rate; //the rate in which projectiles are shot
	public float LastShotTime = 0f; //this stores the time when each projectile is shot

	public float Speed; //the speed in which the cannon will rotate around the target
	

	void Update () 
	{
		if (Time.time - LastShotTime >= Rate)//determine if a shot should be fired
		{
			//Instantiate a new projectile
			GameObject ThisProjectile = Instantiate(Projectile,gameObject.transform.position,gameObject.transform.rotation) as GameObject;

			//add force to the projectile
			ThisProjectile.rigidbody.AddRelativeForce(Random.Range(Scatter * -1f, Scatter),Random.Range(Scatter * -1f, Scatter),ProjectileForce + Random.Range(Scatter * -1f, Scatter));

			//set the owner of the projectile...this will allow the shield to determine weather or not to let the projectile pass through
			if (gameObject.transform.parent == null)
			{
				ThisProjectile.GetComponent<OwnerScript>().Owner = gameObject;
			}
			else
			{
				ThisProjectile.GetComponent<OwnerScript>().Owner = gameObject.transform.parent.gameObject;
			}


			LastShotTime = Time.time; //set the time when the projectile was produced
		}
	
		//rotate the cannon to look at the target object
		Vector3 dir = Target.transform.position - transform.position;
		Quaternion Rotation = Quaternion.LookRotation(dir);
		gameObject.transform.rotation = Rotation;

		//rotate the cannon around the target
		transform.RotateAround(Target.transform.position,new Vector3(0f,1f,0f), Speed * Time.deltaTime);
	}
}
