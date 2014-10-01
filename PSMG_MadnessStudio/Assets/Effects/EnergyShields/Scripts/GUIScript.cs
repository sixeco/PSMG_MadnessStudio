//This Script is the GUI for the EnergySheild Sphere Demo

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIScript : MonoBehaviour {


	public CameraScript CS;

	public ShieldEffectScript SES;
//	public DestoryShieldScript DSS;

	public float SR;
	public float SB;
	public float SG;
	public float SA;


	public float ER;
	public float EB;
	public float EG;
	public float EA;

	public string OPtxt = "Absorb";

	public string GTtxt = "Projectiles";
	public GameObject Cannon;
	public GameObject Gun;


	public int ATI = 0;
	public List<Texture> AnimationTextures = new List<Texture>();
	public List<string> ATNames = new List<string>();

	void Start()
	{
		SR = SES.StartColor.r;
		SG = SES.StartColor.g;
		SB = SES.StartColor.b;
		SA = SES.StartColor.a;
		ER = SES.EndColor.r;
		EG = SES.EndColor.g;
		EB = SES.EndColor.b;
		EA = SES.EndColor.a;

		ATI = 0;
	}

	void OnGUI()
	{
		GUI.Box ( new Rect (10,10,120,580), "Settings");

		GUI.Label(new Rect(20, 30, 100, 25),"Camera");

		if (GUI.Button(new Rect(20, 50, 50, 25), "<--"))
		{
			CS.ViewNum = CS.ViewNum - 1;

			if (CS.ViewNum == -1)
			{
				CS.ViewNum = 4;
			}
		}

		if (GUI.Button(new Rect(70, 50, 50, 25), "-->"))
		{
			CS.ViewNum = CS.ViewNum + 1;

			if (CS.ViewNum == 5)
			{
				CS.ViewNum = 0;
			}
		}

		GUI.Label(new Rect(20, 80, 110, 25),"Effect Options");
		GUI.Label(new Rect(20, 110, 110, 25),"StartColor(RGBA)");

		SR = GUI.HorizontalSlider(new Rect(20, 140, 100, 25), SR, 0.0F, 1F);
		SG = GUI.HorizontalSlider(new Rect(20, 160, 100, 25), SG, 0.0F, 1F);
		SB = GUI.HorizontalSlider(new Rect(20, 180, 100, 25), SB, 0.0F, 1F);
		SA = GUI.HorizontalSlider(new Rect(20, 200, 100, 25), SA, 0.0F, 1F);

		SES.StartColor = new Color(SR,SG,SB,SA);

		GUI.Label(new Rect(20, 230, 110, 25),"EndColor (RGBA)");
		
		ER = GUI.HorizontalSlider(new Rect(20, 260, 100, 25), ER, 0.0F, 1F);
		EG = GUI.HorizontalSlider(new Rect(20, 280, 100, 25), EG, 0.0F, 1F);
		EB = GUI.HorizontalSlider(new Rect(20, 300, 100, 25), EB, 0.0F, 1F);
		EA = GUI.HorizontalSlider(new Rect(20, 320, 100, 25), EA, 0.0F, 1F);
		
		SES.EndColor = new Color(ER,EG,EB,EA);

		if (GTtxt == "RayCast")
		{
			GUI.enabled = false;
		}

		if (GUI.Button(new Rect(20, 350, 100, 25), OPtxt))
		{
			if (OPtxt == "Absorb")
			{
				SES.PhysOption = ShieldEffectScript.PhysOptions.ReflectProjectile;
				OPtxt = "Reflect";
			}
			else
			{
				SES.PhysOption = ShieldEffectScript.PhysOptions.AbsorbProjectile;
				OPtxt = "Absorb";
			}
		}

		GUI.enabled = true;

		GUI.Label(new Rect(20, 400, 100, 25),"Effect");


		GUI.Label(new Rect(20, 430, 100, 25),ATNames[ATI]);

		if (GUI.Button(new Rect(20, 460, 50, 25), "<--"))
		{
			ATI = ATI - 1;
			
			if (ATI == -1)
			{
				ATI = AnimationTextures.Count -1;
			}

			SES.AnimatedTexture = AnimationTextures[ATI];
		}
		
		if (GUI.Button(new Rect(70, 460, 50, 25), "-->"))
		{
			ATI = ATI + 1;
			
			if (ATI == AnimationTextures.Count)
			{
				ATI = 0;
			}

			SES.AnimatedTexture = AnimationTextures[ATI];
		}

		GUI.Label(new Rect(20, 500, 100, 25),"ProjectileType");

		if (GUI.Button(new Rect(20, 530, 100, 25), GTtxt))
		{
			if (GTtxt == "Projectiles")
			{
				Cannon.SetActive(false);
				Gun.SetActive(true);
				GTtxt = "RayCast";
			}
			else
			{
				Cannon.SetActive(true);
				Gun.SetActive(false);
				GTtxt = "Projectiles";
			}
		}

//		if (GUI.Button(new Rect(850, 565, 100, 25), "DestoryShield"))
//		{
//			DSS.Play = true;
//		}

	}

}


	
