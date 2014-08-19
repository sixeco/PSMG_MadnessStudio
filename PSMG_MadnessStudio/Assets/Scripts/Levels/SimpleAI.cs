using UnityEngine;
using System.Collections;

public class SimpleAI : MonoBehaviour {

    public GameObject projectile;
    public GameObject Lab;
    public Transform ShotPosition;

    public float ShotForce;
    public float CoolDownRate;

    private float CoolDownRemain;

    void Start()
    {
        CoolDownRemain = CoolDownRate;
    }

	void Update () {
        CoolDownRemain -= Time.deltaTime;
        if (CoolDownRemain <= 0)
        {
            CoolDownRemain = Random.Range(CoolDownRate, CoolDownRate*2);
            Shoot();
        }
    }

    void Shoot()
    {
        Rigidbody shot = Instantiate(projectile, ShotPosition.position, ShotPosition.rotation) as Rigidbody;
    }
}
