using UnityEngine;
using System.Collections;

public class TortoiseSpawner : MonoBehaviour {

    public GameObject thing;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(thing, new Vector3(Random.Range(-10, 10), 30, Random.Range(-10, 10)), Quaternion.identity);
        }
    }
}
