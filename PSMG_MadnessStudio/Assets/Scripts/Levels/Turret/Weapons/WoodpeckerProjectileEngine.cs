using UnityEngine;
using System.Collections;

public class WoodpeckerProjectileEngine : MonoBehaviour {

    float speed;
    float lifeTime = 1;
    float createdTime;

    void Start()
    {
        speed = GameObject.Find("Data").GetComponent<WeaponsData>().WoodpeckerProjectileSpeed;
        createdTime = Time.time;
    }

    void FixedUpdate()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        if (Time.time - createdTime > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
