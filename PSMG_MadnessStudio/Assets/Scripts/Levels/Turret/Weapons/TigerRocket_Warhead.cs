using UnityEngine;
using System.Collections;

public class TigerRocket_Warhead : MonoBehaviour {

    GameObject Explosion;

    float ExplosionRadius;

    bool sensorLockOn;
    bool targetLockOn;

    int damage;
    GameObject target;
    float rotationSpeed = 10f;
    float RayCheckRange;

    void Start()
    {
        sensorLockOn = false;
        targetLockOn = false;
        GameObject data = GameObject.Find("Data");
        Explosion = data.GetComponent<ModelData>().RocketExplosion;
        damage = data.GetComponent<DamageData>().TigerRocketDamage;
        ExplosionRadius = data.GetComponent<DamageData>().TigerExplosionRadius;
        RayCheckRange = data.GetComponent<GUIData>().RayCheckRange;
    }

    void Update()
    {
        if (target == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, RayCheckRange))
            {
                if (hit.collider.gameObject.tag.Equals("Asteroid"))
                {
                    this.GetComponent<SphereCollider>().enabled = false;
                    target = hit.collider.gameObject;
                    targetLockOn = true;
                }
            }
        }
        if ((targetLockOn || sensorLockOn) && target != null)
        {
            this.GetComponent<TigerRocket_Engine>().speed *= 1.01f;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), rotationSpeed * Time.deltaTime);
        }
        else if ((sensorLockOn || targetLockOn) && target == null)
        {
            StartCoroutine(Detonate());
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag.Equals("Asteroid"))
        {
            if (targetLockOn == false && sensorLockOn == false)
            {
                this.GetComponent<SphereCollider>().enabled = false;
                target = c.gameObject;
                sensorLockOn = true;
            }
            else if (targetLockOn || sensorLockOn)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);
                foreach (Collider col in colliders)
                {
                    AsteroidHP a = col.GetComponent<AsteroidHP>();
                    if (a != null)
                    {
                        a.AddDamage(damage);
                    }
                }
                Instantiate(Explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else if (c.gameObject.tag.Equals("Dome"))
        {
            StartCoroutine(Detonate());
        }
    }

    IEnumerator Detonate()
    {
        yield return new WaitForSeconds(1);
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
