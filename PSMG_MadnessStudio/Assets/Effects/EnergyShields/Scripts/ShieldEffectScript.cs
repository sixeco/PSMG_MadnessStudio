using UnityEngine;
using System.Collections;

public class ShieldEffectScript : MonoBehaviour 
{

	public Texture AnimatedTexture;
	public enum ShapeOptions{ SphereShape = 0, PlaneShape = 1 };
	public ShapeOptions ShapeOption = ShapeOptions.SphereShape;
    
	public Color StartColor;
	public Color EndColor;
    
	public float FramesPerSecond;
	public int XFrames;
	public int YFrames;
	public bool DestroyOnComplete = true;

	public enum PhysOptions{ ReflectProjectile = 0, AbsorbProjectile = 1 };
	public PhysOptions PhysOption = PhysOptions.AbsorbProjectile;

//	public DidBounceScript DBS;

	public GameObject GenericEffect_Sphere;
	public GameObject GenericEffect_Plane;

    private float damage;

    void Awake()
    {
        damage = GameObject.Find("Data").GetComponent<DamageData>().AsteroidDamage;
    }

	//Instantiate the effect and set some of it's variables
	public void ShowEffect(GameObject Target ,ShapeOptions input_ShapeOptions )
	{

		if (input_ShapeOptions == ShapeOptions.SphereShape)
		{

			Vector3 dir = Target.transform.position - transform.position;
			Quaternion Rotation = Quaternion.LookRotation(dir);
			
			GameObject ThisEffect = Instantiate(GenericEffect_Sphere,gameObject.transform.position,Rotation) as GameObject;
			
			ThisEffect.transform.localScale = gameObject.transform.lossyScale * 1.01f;
			
			ThisEffect.transform.parent = gameObject.transform;

			AnimateEffectScript AES = ThisEffect.transform.FindChild("Effect").gameObject.GetComponent<AnimateEffectScript>();

			AES.StartColor = StartColor;
			AES.EndColor = EndColor;
			AES.AnimatedTexture = AnimatedTexture;
			AES._fps = (int)FramesPerSecond;
			AES._uvTieX = XFrames;
			AES._uvTieY = YFrames;
			AES.DestroyOnComplete = DestroyOnComplete;


			if (AnimatedTexture.name.IndexOf("Particle") == 0)
			{
				ThisEffect.transform.rotation = Quaternion.Euler(ThisEffect.transform.rotation.eulerAngles.x,ThisEffect.transform.rotation.eulerAngles.y,Random.Range(0f,360f));
			}

		}
		else
		{
			GameObject ThisEffect = Instantiate(GenericEffect_Plane,Target.transform.position,gameObject.transform.rotation) as GameObject;
			
			ThisEffect.transform.localScale = gameObject.transform.lossyScale * 1.01f;
			
			ThisEffect.transform.parent = gameObject.transform;

			AnimateEffectScript AES = ThisEffect.transform.FindChild("Effect").gameObject.GetComponent<AnimateEffectScript>();
			
			AES.StartColor = StartColor;
			AES.EndColor = EndColor;
			AES.AnimatedTexture = AnimatedTexture;
			AES._fps = (int)FramesPerSecond;
			AES._uvTieX = XFrames;
			AES._uvTieY = YFrames;
			AES.DestroyOnComplete = DestroyOnComplete;


			if (AES.AnimatedTexture.name.IndexOf("Particle") == 0)
			{
				ThisEffect.transform.localRotation = Quaternion.Euler(0f,Random.Range(0f,180f),0f);
			}
		}

	}

	public void ShowEffect(Vector3 Target ,ShapeOptions input_ShapeOptions )//Overload
	{
		
		if (input_ShapeOptions == ShapeOptions.SphereShape)
		{
			
			Vector3 dir = Target - transform.position;
			Quaternion Rotation = Quaternion.LookRotation(dir);
			
			GameObject ThisEffect = Instantiate(GenericEffect_Sphere,gameObject.transform.position,Rotation) as GameObject;
			
			ThisEffect.transform.localScale = gameObject.transform.lossyScale * 1.01f;
			
			ThisEffect.transform.parent = gameObject.transform;
			
			AnimateEffectScript AES = ThisEffect.transform.FindChild("Effect").gameObject.GetComponent<AnimateEffectScript>();
			
			AES.StartColor = StartColor;
			AES.EndColor = EndColor;
			AES.AnimatedTexture = AnimatedTexture;
			AES._fps = (int)FramesPerSecond;
			AES._uvTieX = XFrames;
			AES._uvTieY = YFrames;
			AES.DestroyOnComplete = DestroyOnComplete;

			if (AnimatedTexture.name.IndexOf("Particle") == 0)
			{
				ThisEffect.transform.rotation = Quaternion.Euler(ThisEffect.transform.rotation.eulerAngles.x,ThisEffect.transform.rotation.eulerAngles.y,Random.Range(0f,360f));
			}
			
		}
		else
		{
			GameObject ThisEffect = Instantiate(GenericEffect_Plane,Target,gameObject.transform.rotation) as GameObject;
			
			ThisEffect.transform.localScale = gameObject.transform.lossyScale * 1.01f;
			
			ThisEffect.transform.parent = gameObject.transform;
			
			AnimateEffectScript AES = ThisEffect.transform.FindChild("Effect").gameObject.GetComponent<AnimateEffectScript>();
            
            AES.StartColor = StartColor;
            AES.EndColor = EndColor;
            AES.AnimatedTexture = AnimatedTexture;
            AES._fps = (int)FramesPerSecond;
            AES._uvTieX = XFrames;
            AES._uvTieY = YFrames;
            AES.DestroyOnComplete = DestroyOnComplete;


			if (AES.AnimatedTexture.name.IndexOf("Particle") == 0)
			{
				ThisEffect.transform.localRotation = Quaternion.Euler(0f,Random.Range(0f,180f),0f);
			}
		}
		
	}

	public void HitbyRayCast(Vector3 Pos)
	{
		ShowEffect(Pos,ShapeOption);
	}
	


	void OnCollisionEnter(Collision C) 
	{
		try
		{
			//make sure object is a projectile and is not owned by the same person who is in the shield
			if (C.gameObject.tag.Equals("Asteroid") || C.gameObject.tag.Equals("Projectile"))   
			{
                //&& C.gameObject.GetComponent<OwnerScript>().Owner != gameObject.transform.parent.gameObject
				ShowEffect(C.gameObject, ShapeOption);
				
				
				if (PhysOption == PhysOptions.ReflectProjectile )
				{
					
					//Decreasing HP of shield
					
				}
				else
				{
                    C.gameObject.GetComponent<AsteroidEngine>().Detonate();
				}

                HighScore.Multiplier /= 2;
                this.GetComponent<TortoiseLife>().HP -= damage;
				
			}
		}
		catch(MissingComponentException) //catch error when the object does not have an OwnerScript
		{
			
		}
	}



}
