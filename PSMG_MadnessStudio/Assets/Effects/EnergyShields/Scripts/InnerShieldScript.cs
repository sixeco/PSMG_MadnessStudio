using UnityEngine;
using System.Collections;

public class InnerShieldScript : MonoBehaviour {


	public ShieldEffectScript SES;


	void Start()
	{
		SES = transform.parent.gameObject.GetComponent<ShieldEffectScript>();
	}

	
	void OnTriggerEnter(Collider C)
	{
		try
		{
			//make sure object is a projectile and is not owned by the same person who is in the shield
			if (
				C.gameObject.tag == "Projectile" 
				&& C.gameObject.GetComponent<OwnerScript>().Owner != gameObject.transform.parent.gameObject
				)
			{
				
				SES.ShowEffect(C.gameObject,SES.ShapeOption);
				
				
				if (SES.PhysOption == ShieldEffectScript.PhysOptions.ReflectProjectile )
				{

					
				}
				else
				{
					Destroy(C.gameObject);
				}
				
			}
		}
		catch(MissingComponentException) //catch error when the object does not have an OwnerScript
		{
			
		}
	}
	
	
	void OnCollisionEnter(Collision C) 
	{
		try
		{
			//make sure object is a projectile and is not owned by the same person who is in the shield
			if (
				C.gameObject.tag == "Projectile" 
				&& C.gameObject.GetComponent<OwnerScript>().Owner != gameObject.transform.parent.gameObject
				)
			{
				
				SES.ShowEffect(C.gameObject,SES.ShapeOption);
				
				
				if (SES.PhysOption == ShieldEffectScript.PhysOptions.ReflectProjectile )
				{
					

					
				}
				else
				{
					Destroy(C.gameObject);
				}
				
			}
		}
		catch(MissingComponentException) //catch error when the object does not have an OwnerScript
		{
			
		}
	}
	

}
