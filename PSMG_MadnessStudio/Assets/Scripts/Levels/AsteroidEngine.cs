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
        rotation = new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
        explosion = GameObject.Find("Data").GetComponent<ModelData>().AIExplosion;
        gameObject.rigidbody.AddForce(direction * speed, ForceMode.Acceleration);
        gameObject.rigidbody.AddTorque(rotation * speed, ForceMode.Acceleration);
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
