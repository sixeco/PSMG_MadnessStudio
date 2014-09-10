using UnityEngine;
using System.Collections;

public class EffectShellScript : MonoBehaviour {



	// Update is called once per frame
	void Update () 
	{
		if (transform.FindChild("Effect").gameObject.GetComponent<AnimateEffectScript>().Destory == true)
		{
			Destroy(gameObject);
		}
	}
}
