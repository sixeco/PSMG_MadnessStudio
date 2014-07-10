using UnityEngine;
using System.Collections;
using iViewX;

public class TwinCannon : MonoBehaviour {

    public delegate Vector3 InputEvent();
    public static event InputEvent MainInput;

    public Transform UpperShotPos;
    public Transform LowerShotPos;

    private bool shotMode;
    private bool turn;

    private float LaserCoolDown;
    private float RocketCoolDown;
    private float CannonCoolDown;
    private float CoolDownRemain;

    private Rigidbody CannonProjectile;
    private GameObject spark;

    private float laserForce;

    private float shotForce;

    private float RayCheckRange = 100.0f;

    void OnEnable()
    {
        KeyControls.CannonShot += Shot;
        KeyControls.ChangeShotMode += ChangeMode;
    }

    void OnDisable()
    {
        KeyControls.CannonShot -= Shot;
        KeyControls.ChangeShotMode -= ChangeMode;
    }

	void Start () {
        CoolDownRemain = 0;
        shotMode = true;

        spark = ModelDataStatic.LaserSpark;
        CannonProjectile = ModelDataStatic.CannonProjectile;

        CannonCoolDown = CoolDownDataStatic.CannonCoolDown;
        LaserCoolDown = CoolDownDataStatic.LaserCoolDown;
        shotForce = DamageDataStatic.CannonForce;
	}
	
	void Update () {
        CoolDownRemain -= Time.deltaTime;
        print(CoolDownRemain);
	}

    void Shot()
    {
        if (CoolDownRemain <= 0)
        {
            Ray ray = this.camera.ScreenPointToRay(MainInput());
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, RayCheckRange))
            {
                if (shotMode)
                {
                    if (turn)
                    {
                        Rigidbody upperShot = Instantiate(CannonProjectile, UpperShotPos.position, UpperShotPos.rotation) as Rigidbody;
                        Vector3 UpperShotVector = hitInfo.point - upperShot.transform.position;
                        upperShot.AddForce(UpperShotVector * shotForce, ForceMode.Acceleration);
                        turn = !turn;
                    }
                    else
                    {
                        Rigidbody lowerShot = Instantiate(CannonProjectile, LowerShotPos.position, LowerShotPos.rotation) as Rigidbody;
                        Vector3 LowerShotVector = hitInfo.point - lowerShot.transform.position;
                        lowerShot.AddForce(LowerShotVector * shotForce, ForceMode.Acceleration);
                        turn = !turn;
                    }

                    CoolDownRemain = CannonCoolDown;
                }
            }
        }
    }

    void ChangeMode()
    {
        shotMode = !shotMode;
    }
}
