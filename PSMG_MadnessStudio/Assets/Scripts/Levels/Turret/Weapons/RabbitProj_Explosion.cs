using UnityEngine;
using System.Collections;

public class RabbitProj_Explosion : MonoBehaviour {

    ParticleSystem system;

    private float DestructionTime;

    void Start()
    {
        system = this.GetComponent<ParticleSystem>();
        DestructionTime = system.duration;
        Destroy(gameObject, DestructionTime);
    }
}
