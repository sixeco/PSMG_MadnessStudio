using UnityEngine;
using System.Collections;

public class CoolDownValues : MonoBehaviour {

    public float Cannon;
    public float RocketMain;
    public float LaserMain;

    void Awake()
    {
        CoolDownDataStatic.CannonCoolDown = Cannon;
        CoolDownDataStatic.RocketCoolDown = RocketMain;
        CoolDownDataStatic.LaserCoolDown = LaserMain;
    }
}
