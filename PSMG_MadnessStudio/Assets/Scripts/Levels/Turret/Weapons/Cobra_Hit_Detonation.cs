using UnityEngine;
using System.Collections;

public class Cobra_Hit_Detonation : MonoBehaviour {

    void Start()
    {
        ParticleSystem system = this.GetComponent<ParticleSystem>();
        float time = system.duration;
        Destroy(gameObject, time);
    }
}
