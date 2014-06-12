using UnityEngine;
using System.Collections;

public class DetonatesOnHit : MonoBehaviour {

    public GameObject explosionPrefab;

    public float checkRadius = 100;
    public float explosionForce = 5;
    public float explosionRadius = 5;
    public float explosionAnchor = 1;

    //public float damage = 200f; //Damage at center of explosion
    //public float explosionRadius = 3f;

    public Vector3 detonationPoint;

    void OnCollisionEnter()
    {
        
    }

    void OnTriggerEnter()
    {
        Detonate();
    }

    //Für den Fall dass die Rakete sich zu weit fortbewegt zw 2 Frames
    /*void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray, speed * Time.deltaTime)){
            Detonate();
        }
    }*/

    void Detonate()
    {
        Vector3 explosionPoint = transform.position + detonationPoint;

        
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, explosionPoint, Quaternion.identity);
        }

        
        Collider[] colliders = Physics.OverlapSphere(explosionPoint, checkRadius);

        foreach (Collider c in colliders)
        {
            if (c.rigidbody == null)
            {
                continue;
            }

            c.rigidbody.AddExplosionForce(explosionForce, explosionPoint, explosionRadius, explosionAnchor, ForceMode.Impulse);
            Destroy(gameObject);

            /*
            HasHealth h = c.GetComponent<HasHealth>();
            if(h != null){
                float distance = Vector3.Distance(explosionPoint, c.transform.position);
                float damageRatio = 1f - (distance / explosionRadius);
                h.RecieveDamage(damage * damageRatio);
            }*/
        }
        
    }

    
}
