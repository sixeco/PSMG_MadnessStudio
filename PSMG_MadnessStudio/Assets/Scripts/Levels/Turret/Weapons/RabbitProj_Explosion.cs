using UnityEngine;
using System.Collections;

public class RabbitProj_Explosion : MonoBehaviour {

    void Start()
    {
        ParticleSystem system = this.GetComponent<ParticleSystem>();
        float DestructionTime = system.duration;
        Destroy(gameObject, DestructionTime);
    }
}
