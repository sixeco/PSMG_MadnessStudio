using UnityEngine;
using System.Collections;

public class HasHealth : MonoBehaviour {

    public float hitPoint = 100.0f;

    public void RecieveDamage(float amt)
    {
        Debug.Log("Recieve Damage: " + amt);
        hitPoint -= amt;
        if (hitPoint <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
