using UnityEngine;
using System.Collections;

public class Rabbit_TwinCannon : MonoBehaviour {

    public Transform UpperShotPos;
    public Transform LowerShotPos;

    private float CoolDown;
    private float coolDownRemain;
    private Rigidbody projectile;
    private GameObject flash;

    void Awake()
    {
        projectile = GameObject.Find("Data").GetComponent<ModelData>().CannonProjectile;
        flash = GameObject.Find("Data").GetComponent<ModelData>().CannonMuzzleFlash;
    }

    void Update()
    {

    }

    public void Shoot(Vector2 direction)
    {
        Debug.Log("Rabbit shot" + direction);
        //Instantiate(flash, UpperShotPos.position, Quaternion.identity);
    }
}
