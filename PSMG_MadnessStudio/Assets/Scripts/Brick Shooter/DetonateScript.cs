using UnityEngine;
using System.Collections;

public class DetonateScript : MonoBehaviour {

    Vector3 location = new Vector3(-6, 0, 0);

	void Start () {
        Invoke("Detonate", 3);
	}
	
	void Detonate () 
    {
        Collider[] colliders = Physics.OverlapSphere(location, 10);
    
        foreach(Collider col in colliders){
            if(col.rigidbody == null){
                continue;
            }
            col.rigidbody.AddExplosionForce(10, location, 10, 0, ForceMode.Impulse);
        }
	}
}
