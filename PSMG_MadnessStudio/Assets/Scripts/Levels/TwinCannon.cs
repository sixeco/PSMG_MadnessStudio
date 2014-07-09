using UnityEngine;
using System.Collections;
using iViewX;

public class TwinCannon : MonoBehaviour {

    public delegate Vector3 InputEvent();
    public static event InputEvent MainInput;

    public Transform cannonShotPos;
    public Transform laserShotPos;

    private bool shotMode;

    private float LaserCoolDown;
    private float RocketCoolDown;
    private float CannonCoolDown;
    private float CoolDownRemain;

    private GameObject spark;

    private float laserForce;

    private float shotForce;

	void Start () {
        CoolDownRemain = 0;
        shotMode = true;
        CannonCoolDown = CoolDownDataStatic.CannonCoolDown;
        LaserCoolDown = CoolDownDataStatic.LaserCoolDown;
	}
	
	void Update () {
        CoolDownRemain -= Time.deltaTime;
        if (Input.GetButton("Fire1") && CoolDownRemain <= 0)
        {
            //Ray ray = Camera.main.ScreenPointToRay(MainInput());
        }
	}
}
