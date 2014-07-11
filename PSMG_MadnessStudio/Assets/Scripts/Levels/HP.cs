using UnityEngine;
using System.Collections;

public class HP : MonoBehaviour {
    
    public float HitPoints;
    public GameObject explosion;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddDamage(10);
        }
    }

    public void AddDamage(float dp)
    {
        HitPoints -= dp;
        if (HitPoints <= 0)
        {
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.localRotation);
            Destroy(gameObject);
        }
    }
}
