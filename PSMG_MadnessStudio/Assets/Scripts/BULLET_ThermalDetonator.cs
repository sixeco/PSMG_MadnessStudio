using UnityEngine;
using System.Collections;

public class BULLET_ThermalDetonator : MonoBehaviour {

    float lifeSpan = 3.0f;
    public GameObject fireEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lifeSpan -= Time.deltaTime;

        if (lifeSpan <= 0)
        {
            Explode();
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.tag = "Untagged";
            Instantiate(fireEffect, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        Destroy(gameObject);
    }
}
