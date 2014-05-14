using UnityEngine;
using System.Collections;

public class DetonatesOnHit : MonoBehaviour {

    public GameObject explosionPrefab;

    public float damage = 200f; //Damage at center of explosion
    public float explosionRadius = 3f;

    public Vector3 detonationPoint;

    void OnCollisionEnter()
    {
        Debug.Log("OnCollisionEnter");
    }

    void OnTriggerEnter()
    {
        Debug.Log("OnTriggerEnter");
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
        Destroy(gameObject);

        Collider[] colliders = Physics.OverlapSphere(explosionPoint, explosionRadius);

        foreach (Collider c in colliders)
        {
            HasHealth h = c.GetComponent<HasHealth>();
            if(h != null){
                float distance = Vector3.Distance(explosionPoint, c.transform.position);
                float damageRatio = 1f - (distance / explosionRadius);
                h.RecieveDamage(damage * damageRatio);
            }
        }
    }
}
