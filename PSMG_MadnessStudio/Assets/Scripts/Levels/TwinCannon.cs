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

    public AudioClip[] smokeShotSounds;
    public AudioClip[] laserShotSounds;

    private float RayCheckRange = 300.0f;

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

        ModelData modelData = GameObject.Find("Data").GetComponent<ModelData>();
        CoolDownValues cools = GameObject.Find("Data").GetComponent<CoolDownValues>();
        DamageData DD = GameObject.Find("Data").GetComponent<DamageData>();

        spark = modelData.LaserSpark;
        CannonProjectile = modelData.CannonProjectile;

        CannonCoolDown = cools.Cannon;
        LaserCoolDown = cools.LaserMain;
        shotForce = DD.CannonForce;
        laserForce = DD.LaserForce;
	}
	
	void Update () {
        CoolDownRemain -= Time.deltaTime;
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
                    int shotIndex = Random.Range(0, 3);
                    audio.clip = smokeShotSounds[shotIndex]; 
                }
                else
                {
                    CoolDownRemain = LaserCoolDown;
                    Vector3 hitPoint = hitInfo.point;
                    GameObject LaserCollision = hitInfo.collider.gameObject;
                    if (LaserCollision.collider != null)
                    {
                        GameObject temp = spark;
                        if (LaserCollision.rigidbody != null)
                        {
                            LaserCollision.rigidbody.AddForceAtPosition((LaserCollision.transform.position - hitPoint) * laserForce, hitPoint, ForceMode.Impulse);
                            Instantiate(temp, hitPoint, LaserCollision.rigidbody.rotation);
                        }
                        else
                        {
                            Instantiate(temp, hitPoint, LaserCollision.gameObject.transform.localRotation);
                        }
                    }
                    int shotIndex = Random.Range(0, 3);
                    audio.clip = laserShotSounds[shotIndex];
                }
                audio.Play();
            }
        }
    }

    void ChangeMode()
    {
        shotMode = !shotMode;
    }
}
