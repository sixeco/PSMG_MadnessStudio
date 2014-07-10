using UnityEngine;
using System.Collections;

public class DamageData : MonoBehaviour {

    public float LaserDamage;
    public float RocketDamage;
    public float CannonDamage;

    public float LaserForce;
    public float CannonForce;

    void Awake()
    {
        DamageDataStatic.LaserDamage = LaserDamage;
        DamageDataStatic.RocketDamage = RocketDamage;
        DamageDataStatic.CannonDamage = CannonDamage;

        DamageDataStatic.LaserForce = LaserForce;
        DamageDataStatic.CannonForce = CannonForce;
    }
}
