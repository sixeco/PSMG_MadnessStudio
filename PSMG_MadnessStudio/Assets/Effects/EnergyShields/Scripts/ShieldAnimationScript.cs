using UnityEngine;
using System.Collections;

public class ShieldAnimationScript : MonoBehaviour {


	public Vector2 offset = new Vector2(0f,0f);

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		offset = new Vector2(offset.x + 0.001f,offset.y);

		GetComponent<Renderer>().material.SetTextureOffset ("_MainTex", offset);
	}
}
