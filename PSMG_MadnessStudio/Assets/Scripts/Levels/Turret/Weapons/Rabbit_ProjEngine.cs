using UnityEngine;
using System.Collections;

public class Rabbit_ProjEngine : MonoBehaviour {

    float speed;
    float LifeTime = 1;
    float CreatedTime;

    void Start()
    {
        speed = GameObject.Find("Data").GetComponent<WeaponsData>().RabbitProkectileSpeed;
        CreatedTime = Time.time;
    }

    void FixedUpdate()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        if (Time.time - CreatedTime > LifeTime)
        {
            Destroy(gameObject);
        }
    }
}
