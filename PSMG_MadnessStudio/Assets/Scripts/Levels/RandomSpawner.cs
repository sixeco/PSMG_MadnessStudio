using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour {

    public GameObject[] asteroids;
    public float IntervalMax;
    public float IntervalMin;
    public float SpawnFieldRange;
    public float minSpeed;
    public float maxSpeed;

    private float remain; 

    void Start()
    {
        remain = Random.Range(IntervalMin, IntervalMax);
    }

    void Update(){
        if (remain <= 0)
        {
            int index = Random.Range(0, asteroids.Length - 1);
            Vector3 randomVector = new Vector3(transform.position.x, Random.Range(transform.position.y - SpawnFieldRange, transform.position.y + SpawnFieldRange), Random.Range(transform.position.z - SpawnFieldRange, transform.position.z + SpawnFieldRange));
            if (asteroids[index] != null)
            {
                Instantiate(asteroids[index], randomVector, Quaternion.identity);
            }
            remain = Random.Range(IntervalMin, IntervalMax);
        }
        else
        {
            remain -= Time.deltaTime;
        }
    }
}
