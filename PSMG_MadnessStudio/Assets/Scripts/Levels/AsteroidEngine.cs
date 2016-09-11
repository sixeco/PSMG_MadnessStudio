using UnityEngine;
using System.Collections;

public class AsteroidEngine : MonoBehaviour {

    float speed;
    Vector3 direction;
    Vector3 rotation;
    GameObject explosion;

    void Start()
    {
        float min = GameObject.Find("AsteroidSpawner").GetComponent<RandomSpawner>().minSpeed;
        float max = GameObject.Find("AsteroidSpawner").GetComponent<RandomSpawner>().maxSpeed;
        speed = Random.Range(min, max);
        direction = -transform.position;
        direction.z += Random.Range(-20, 20);
        direction.y += Random.Range(-20, 20);
        rotation = new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
        explosion = GameObject.Find("Data").GetComponent<ModelData>().AIExplosion;
        gameObject.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Acceleration);
        gameObject.GetComponent<Rigidbody>().AddTorque(rotation * speed, ForceMode.Acceleration);
        transform.localScale = Vector3.Lerp(Vector3.zero, transform.localScale, 0.8f);
    }

    public void Detonate()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.name.Equals("Dome"))
        {
            Destroy(gameObject);
        }
    }
}
