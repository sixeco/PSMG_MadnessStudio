using UnityEngine;
using System.Collections;

public class TigerRocket_Engine : MonoBehaviour {

    public float speed;

    void Start()
    {
        speed = GameObject.Find("Data").GetComponent<WeaponsData>().TigerRocketSpeed;
    }

    void FixedUpdate()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }
}
