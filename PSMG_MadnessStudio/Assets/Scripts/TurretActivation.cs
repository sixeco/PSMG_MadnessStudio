using UnityEngine;
using System.Collections;

public class TurretActivation : MonoBehaviour {

    public bool isActive;
    public bool AOIVisibility = false;
    public bool isGazeInputActive;

    void Start () {
        AOIVisibility = false;
        isGazeInputActive = this.transform.parent.gameObject.transform.parent.GetComponent<GeneralStats>().isGazeInputActive;
        if (isGazeInputActive)
        {
            this.GetComponent<ShowGazeSimple>().enabled = true;
            this.GetComponent<showShotCursor>().enabled = false;
        }
        else
        {
            this.GetComponent<ShowGazeSimple>().enabled = false;
            this.GetComponent<showShotCursor>().enabled = true;
        }
	}
	
	void Update () {
	    
	}
}
