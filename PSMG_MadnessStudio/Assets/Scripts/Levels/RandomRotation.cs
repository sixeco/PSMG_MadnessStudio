using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {


    float max = 3;
    float min = 1;
    Vector3 rotation;

    void Start()
    {
        rotation = new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
    }

    void Update()
    {
        transform.Rotate(rotation);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Start();
        }
    }
}
