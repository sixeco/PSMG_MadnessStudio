using UnityEngine;
using System.Collections;

public class AsteroidHP : MonoBehaviour {

    private int hitPoints;
    private GameObject explosion;

    void Start()
    {
        hitPoints = GameObject.Find("Data").GetComponent<DamageData>().AsteroidHealth;
        explosion = GameObject.Find("Data").GetComponent<ModelData>().AIExplosion;
    }

    void Update()
    {
        if (hitPoints <= 0)
        {   
            HighScore.Score += 10 * HighScore.Multiplier;
            HighScore.Multiplier++;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void AddDamage(int amount)
    {
        hitPoints -= amount;
    }
}
