using UnityEngine;
using System.Collections;

public class Woodpecker_Gatling : MonoBehaviour {

    void Update()
    {

    }

    public void Shoot(Vector2 direction)
    {
        Debug.Log("Woodpecker shot" + direction);
    }
}
