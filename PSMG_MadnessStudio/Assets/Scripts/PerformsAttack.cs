using UnityEngine;
using System.Collections;

public class PerformsAttack : MonoBehaviour {

    public float coolDown = 0.2f;
    float coolDownRemain = 0;

    public float range = 100.0f;

    public float damage = 50.0f;

    public GameObject debrisPrefab;

	// Use this for initialization
	void Start () {
        Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
        coolDownRemain -= Time.deltaTime;
        if (Input.GetMouseButton(0) && coolDownRemain <= 0)
        {
            coolDownRemain = coolDown;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, range))
            {
                Vector3 hitPoint = hitInfo.point;
                GameObject go = hitInfo.collider.gameObject;
                Debug.Log("Hit object: " + go.name);
                Debug.Log("Hit Point: " + hitPoint);

                HasHealth h = go.GetComponent<HasHealth>();
                
                if(h != null){
                    h.RecieveDamage(damage);
                }

                if(debrisPrefab != null){
                    Instantiate(debrisPrefab, hitPoint, Quaternion.identity);
                }
            }
        }	
	}
}
