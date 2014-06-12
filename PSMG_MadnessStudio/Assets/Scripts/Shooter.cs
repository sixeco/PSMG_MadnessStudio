using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    private bool isActive;

    private float coolDownLaser;
    private float coolDownGrenade;
    private float coolDownRemain;

    public Rigidbody projectile;
    public Rigidbody rocket;
    public Transform shotPosLeft;
    public Transform shotPosRight;

    bool shotMode;
    bool turn;

    public GameObject spark;

    public float laserForce = 10;

    public AudioClip[] smokeShotSounds;
    public AudioClip[] laserShotSounds;

    public float shotForce = 1000.0f;

    public float range = 100.0f;

    void Start()
    {
        coolDownRemain = 0;
        shotMode = true;
        turn = true;
        isActive = this.GetComponent<TurretActivation>().isActive;
        coolDownLaser = this.transform.parent.gameObject.transform.parent.GetComponent<GeneralCoolDowns>().laserCoolDown;
        coolDownGrenade = this.transform.parent.gameObject.transform.parent.GetComponent<GeneralCoolDowns>().coolDownGrenade;
    }

	void Update () {

        coolDownRemain -= Time.deltaTime;
        isActive = this.GetComponent<TurretActivation>().isActive;

        if (isActive)
        {
            if (Input.GetButton("Fire1") && coolDownRemain <= 0)
            {
                Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo, range))
                {
                    if (shotMode)
                    {
                        if (turn)
                        {
                            Rigidbody shotLeft = Instantiate(projectile, shotPosLeft.position, shotPosLeft.rotation) as Rigidbody;
                            Vector3 shotVectorLeft = hitInfo.point - shotLeft.transform.position;
                            shotLeft.AddForce(shotVectorLeft * shotForce, ForceMode.Acceleration);
                            turn = !turn;
                        }
                        else
                        {
                            Rigidbody shotRight = Instantiate(projectile, shotPosRight.position, shotPosRight.rotation) as Rigidbody;
                            Vector3 shotVectorRight = hitInfo.point - shotRight.transform.position;
                            shotRight.AddForce(shotVectorRight * shotForce, ForceMode.Acceleration);
                            turn = !turn;
                        }

                        coolDownRemain = coolDownGrenade;
                                                                 
                        int shotIndex = Random.Range(0, 3);
                        audio.clip = smokeShotSounds[shotIndex];              
                    }
                    else if (!shotMode)
                    {
                        coolDownRemain = coolDownLaser;
                        Vector3 hitPoint = hitInfo.point;
                        GameObject go = hitInfo.collider.gameObject;

                        if (go.rigidbody != null)
                        {
                            go.rigidbody.AddForceAtPosition((go.transform.position - hitPoint) * laserForce, hitPoint, ForceMode.Impulse);
                            GameObject temp = spark;
                            Instantiate(temp, hitPoint, go.rigidbody.rotation);
                        }
                        int shotIndex = Random.Range(0, 3);
                        audio.clip = laserShotSounds[shotIndex];
                    }
                    audio.Play();
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                shotMode = !shotMode;
            }
        }
	}
}
