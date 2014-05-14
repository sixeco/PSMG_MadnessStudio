using UnityEngine;
using System.Collections;

public class PokeScript : MonoBehaviour {

    public float force;

    void OnMouseDown()
    {
        rigidbody.AddForce(new Vector3(0, 0, force), ForceMode.Impulse);
    }
}
