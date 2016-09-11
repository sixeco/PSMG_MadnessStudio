using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

    public float force;
    public float radius;

	void Update () 
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                GetComponent<Rigidbody>().AddExplosionForce(force, hit.point, radius, 1, ForceMode.Impulse);
            }
        }
	}
}
