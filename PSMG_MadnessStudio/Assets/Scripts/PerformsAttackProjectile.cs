using UnityEngine;
using System.Collections;

public class PerformsAttackProjectile : MonoBehaviour {

    public float coolDown = 1f;
    float coolDownRemain = 0;

    public GameObject projectilePrefab;
	// Use this for initialization
	void Start () {
        Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
        coolDownRemain -= Time.deltaTime;
        if (Input.GetMouseButton(1) && coolDownRemain <= 0)
        {
            coolDownRemain = coolDown;

            Instantiate(projectilePrefab, Camera.main.transform.position + Camera.main.transform.forward, Camera.main.transform.rotation);
        }	
	}
}
