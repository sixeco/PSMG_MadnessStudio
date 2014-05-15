using UnityEngine;
using System.Collections;

public class MassExplosionScript : MonoBehaviour {

    public float radius = 100;
    public float force = 5;
    public float explosionRadius = 5;
    public float explosionAnchor = 1;

    public GameObject expPrefab;

	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, radius))
            {
                //rigidbody.AddExplosionForce(force, hit.point, explosionRadius, explosionAnchor, ForceMode.Impulse);
                Collider[] colliders = Physics.OverlapSphere(hit.point, radius);
                
                foreach(Collider c in colliders){
                    if (c.rigidbody == null)
                    {
                        continue;
                    }

                    //Create forward force
                    //c.rigidbody.AddForce(new Vector3(0, .3f, 1) * force, ForceMode.Impulse);

                    //Create Explosion force
                    c.rigidbody.AddExplosionForce(force, hit.point, explosionRadius, explosionAnchor, ForceMode.Impulse);

                    //GameObject explosion = Instantiate(expPrefab, hit.point, Quaternion.identity) as GameObject;
                }

            }
        }
	}
}
