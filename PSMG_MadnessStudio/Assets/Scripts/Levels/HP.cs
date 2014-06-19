using UnityEngine;
using System.Collections;

public class HP : MonoBehaviour {
    
    public float HitPoints;
    public GameObject explosion;

    public void AddDamage(float dp)
    {
        Debug.Log("AddDamage happened: " + HitPoints);
        HitPoints -= dp;
        if (HitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
