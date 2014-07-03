using UnityEngine;
using System.Collections;

public class AOIControls4Panel : MonoBehaviour {

    Rect scaleArea;
    Rect areaLeft;
    Rect areaRight;
    Rect areaTop;
    Rect areaBottom;
    private Texture Filler;

    private bool isGazeInputActive;
    private Vector2 mainInput;
    private bool areAOIsVisible;

	void Start () {
        this.enabled = this.transform.parent.gameObject.transform.parent.GetComponent<TurretStats>().isAOIcontrolActive;
        areAOIsVisible = this.transform.parent.gameObject.transform.parent.GetComponent<TurretStats>().isAOIvisible;
	}
	
	void Update () {
	
	}

    void OnGUI()
    {

    }
}
