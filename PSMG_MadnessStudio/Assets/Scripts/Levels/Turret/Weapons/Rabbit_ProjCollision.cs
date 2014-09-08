using UnityEngine;
using System.Collections;

public class Rabbit_ProjCollision : MonoBehaviour {

    public GameObject Explosion;

    void OnTriggerEnter()
    {
        Detonate();
    }

    void Detonate()
    {
        Vector3 explosionPoint = transform.position;
        Instantiate(Explosion, explosionPoint, Quaternion.identity);

        ParticleSystem[] particles = this.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem p in particles)
        {
            p.enableEmission = false;
        }

        Collider[] colliders = Physics.OverlapSphere(explosionPoint, 10f);

        foreach (Collider c in colliders)
        {
            if (c.rigidbody == null)
            {
                continue;
            }

            //c.rigidbody.AddExplosionForce(explosionForce, explosionPoint, explosionRadius, explosionAnchor, ForceMode.Impulse);
            Destroy(gameObject);

            HP h = c.GetComponent<HP>();
            if (h != null)
            {
                //float distance = Vector3.Distance(explosionPoint, c.transform.position);
                //float damageRatio = 1f - (distance / explosionRadius);
                //h.AddDamage(objectDamage);
            }
        }

    }
}
