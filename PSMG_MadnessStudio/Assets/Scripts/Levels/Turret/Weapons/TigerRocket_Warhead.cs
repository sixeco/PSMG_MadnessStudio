using UnityEngine;
using System.Collections;

public class TigerRocket_Warhead : MonoBehaviour {

    GameObject Explosion;

    public float checkRadius = 100;
    public float explosionForce = 5;
    public float explosionRadius = 5;
    public float explosionAnchor = 1;

    //public float damage = 200f; //Damage at center of explosion
    //public float explosionRadius = 3f;

    void Start()
    {
        Explosion = GameObject.Find("Data").GetComponent<ModelData>().RocketExplosion;
    }

    void OnTriggerEnter()
    {
        Detonate();
    }

    void Detonate()
    {
        Vector3 explosionPoint = transform.position;

        Instantiate(Explosion, explosionPoint, Quaternion.identity);
        Destroy(gameObject);

        /*
        Collider[] colliders = Physics.OverlapSphere(explosionPoint, checkRadius);

        foreach (Collider c in colliders)
        {
            if (c.rigidbody == null)
            {
                continue;
            }

            c.rigidbody.AddExplosionForce(explosionForce, explosionPoint, explosionRadius, explosionAnchor, ForceMode.Impulse);
            Destroy(gameObject);

            HP h = c.GetComponent<HP>();
            if (h != null)
            {
                //float distance = Vector3.Distance(explosionPoint, c.transform.position);
                //float damageRatio = 1f - (distance / explosionRadius);
                h.AddDamage(objectDamage);
            }
        }*/
    }
}
