using UnityEngine;
using System.Collections;

public class Rabbit_ProjCollision : MonoBehaviour {

    public GameObject Explosion;
    private int damage;

    void Start()
    {
        damage = GameObject.Find("Data").GetComponent<DamageData>().RabbitCannonDamage;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Asteroid"))
        {
            AsteroidHP h = collider.gameObject.GetComponent<AsteroidHP>();
            if (h != null)
            {
                h.AddDamage(damage);
            }
        }

        Vector3 explosionPoint = transform.position;
        Instantiate(Explosion, explosionPoint, Quaternion.identity);

        ParticleSystem[] particles = this.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem p in particles)
        {
            p.enableEmission = false;
        }

        Destroy(gameObject);
    }
}
