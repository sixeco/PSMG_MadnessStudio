//this script plays the animation 

using UnityEngine;
using System.Collections;

public class AnimateEffectScript : MonoBehaviour
{	
	//store the color and the material using these variables
//	public Material EffectMaterial;
	public Texture AnimatedTexture;
	public Color StartColor;
	public Color EndColor;

	//play and repeat variables
	public bool Play = false;
	public bool Repeat = false;

	//current frame number
	public int CurrentFrame = 1;

	//total number of frames
	public int FrameCount;

	//the X and Y location of the fames
	private float iX=0;
	private float iY=1;

	//the number of frames in each Rows (X), and Columns (Y)
	public int _uvTieX = 1;
	public int _uvTieY = 1;

	//number of FPS
	public int _fps = 60;

	//the size of the texture
	private Vector2 _size;
	private Renderer _myRenderer;
	private int _lastIndex = -1;

	//determines if the object should be destroyed, (the EffectScript looks at this variable to determine when the effect should be destroyed)
	public bool DestroyOnComplete = false;
	public bool Destory = false;

	//set the basic variables
	void Start ()
	{
		_size = new Vector2 (1.0f / _uvTieX ,
		                     1.0f / _uvTieY);
		
		_myRenderer = GetComponent<Renderer>();
		
		if(_myRenderer == null) 
		{	
			enabled = false;
		}


		gameObject.GetComponent<MeshRenderer>().enabled = false;
		_myRenderer.material.SetTexture("_MainTex",AnimatedTexture);
		_myRenderer.material.SetColor("_TintColor",StartColor);
		_myRenderer.material.SetTextureScale ("_MainTex", _size);

		_myRenderer.material.SetTextureOffset ("_MainTex", new Vector2(0f,0f));

		FrameCount = _uvTieX * _uvTieY;

		Play = true;


	}
	
	
	//update the frame, and set the new color
	void Update()
	{
//		_myRenderer.material.SetTexture("Particle Texture",AnimatedTexture);

		_myRenderer.material.SetColor("_TintColor", Color.Lerp (_myRenderer.material.GetColor("_TintColor"),EndColor, 7f * Time.deltaTime));

		if (Play ==  true)
		{
			if (CurrentFrame > 1)
			{
				gameObject.GetComponent<MeshRenderer>().enabled = true;
			}

			int index = (int)(Time.timeSinceLevelLoad * _fps) % (_uvTieX * _uvTieY);

			if(index != _lastIndex)
			{
				Vector2 offset = new Vector2(iX*_size.x,
				                             1-(_size.y*iY));
				iX++;
				if(iX / _uvTieX == 1)
				{
					if(_uvTieY!=1) 
					{
						iY++;
						iX=0;
					}
					if(iY / _uvTieY == 1)
					{
						iY=1;
					}
				}
				
				_myRenderer.material.SetTextureOffset ("_MainTex", offset);
				CurrentFrame = CurrentFrame + 1;
				
				_lastIndex = index;
			}
		}
		else
		{
			gameObject.GetComponent<MeshRenderer>().enabled = false;
		}


		if (CurrentFrame == FrameCount -3)
		{
			if (DestroyOnComplete == true)
			{
				Destory = true;
				Play = false;
				gameObject.GetComponent<MeshRenderer>().enabled = false;
			}
			else
			{
				Repeat = true;
			}

		}

	}
}