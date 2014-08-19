using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

    public float duration;

	void Start () {
        Destroy(gameObject, duration);
	}
}
