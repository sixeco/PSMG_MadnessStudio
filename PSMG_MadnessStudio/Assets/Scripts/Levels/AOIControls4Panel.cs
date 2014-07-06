using UnityEngine;
using System.Collections;

public class AOIControls4Panel : MonoBehaviour {

    public delegate bool EnabledScript();
    public static event EnabledScript AOIScriptEnabled;

    public delegate float FloatDataEvent();
    public static event FloatDataEvent GetScaleFactor;

    public delegate Texture TextureObjectEvent();
    public static event TextureObjectEvent GetTexture;

    Rect scaleArea;
    Rect areaLeft;
    Rect areaRight;
    Rect areaTop;
    Rect areaBottom;
    private Texture Filler;

    private bool isGazeInputActive;
    private Vector2 mainInput;
    private bool areAOIsVisible;

    private float aoiScaleFactor;
    private float maxScale;

	void Start () {
        this.enabled = this.transform.parent.gameObject.transform.parent.GetComponent<TurretStats>().isAOIcontrolActive;
        areAOIsVisible = this.transform.parent.gameObject.transform.parent.GetComponent<TurretStats>().isAOIvisible;

        Filler = GetTexture();
        aoiScaleFactor = GetScaleFactor();
        
        maxScale = (Screen.height / 4) * 2;
        float scaleHeight = (Screen.height / 4) + (maxScale * aoiScaleFactor);
        float scaleWidth = scaleHeight * ((Screen.width * 1.05f) / Screen.height);
        scaleArea = new Rect(((Screen.width/2) - (scaleWidth/2)), ((Screen.height/2) - (scaleHeight/2)), scaleWidth, scaleHeight);

        areaLeft = new Rect(0, 0, ((Screen.width - scaleArea.width) / 2), Screen.height);
        areaRight = new Rect((Screen.width - ((Screen.width - scaleArea.width) / 2)), 0, ((Screen.width - scaleArea.width) / 2), Screen.height);

        areaTop = new Rect(0, 0, Screen.width, ((Screen.height - scaleArea.height) / 2));
        areaBottom = new Rect(0, (Screen.height - ((Screen.height - scaleArea.height) / 2)), Screen.width, ((Screen.height - scaleArea.height) / 2));
    }
	
	void Update () {
	    
	}

    void OnGUI()
    {
        if (areAOIsVisible)
        {
            //GUI.DrawTexture(scaleArea, Filler);
            GUI.DrawTexture(areaLeft, Filler);
            GUI.DrawTexture(areaRight, Filler);
            GUI.DrawTexture(areaTop, Filler);
            GUI.DrawTexture(areaBottom, Filler);
        }
    }
}
