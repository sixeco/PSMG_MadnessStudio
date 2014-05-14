using UnityEngine;
using System.Collections;

public class OpenSafe : MonoBehaviour {

    public GameObject safe;

	// Use this for initialization
	void Start () {
        safe = GameObject.FindGameObjectWithTag("Safe");
	}
	
	// Update is called once per frame
	void Update () {

        int combination = safe.GetComponent<SafeBehaviour>().GetCombination();
        safe.GetComponent<SafeBehaviour>().OpenSafe(combination);
        int money = safe.GetComponent<SafeBehaviour>().GetMoney();

        Debug.Log("Beute: " + money);
	}
}
