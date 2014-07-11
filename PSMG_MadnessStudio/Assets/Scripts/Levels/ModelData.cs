using UnityEngine;
using System.Collections;

public class ModelData : MonoBehaviour {

    public Rigidbody CannonProjectile;
    public GameObject RocketModel;
    public GameObject LaserSpark;
    public GameObject Lab;
    public GameObject AIExplosion;

    void Awake()
    {
        ModelDataStatic.CannonProjectile = CannonProjectile;
        ModelDataStatic.RocketModel = RocketModel;
        ModelDataStatic.LaserSpark = LaserSpark;
        ModelDataStatic.Lab = Lab;
        ModelDataStatic.AIExplosion = AIExplosion;
    }
}
