using UnityEngine;
using System.Collections;

public class GeneralStats : MonoBehaviour {

    bool gazeInputActive;

	void Start () {
	
	}
	
	void Update () {
        gazeInputActive = this.gameObject.transform.parent.gameObject.transform.parent.GetComponent<StatsSwitch>().gazeInputActive;
	}
}
