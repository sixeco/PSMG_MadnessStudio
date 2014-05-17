using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public Rigidbody projectile;
    public Rigidbody rocket;
    public Transform shotPosLeft;
    public Transform shotPosRight;
    public Transform rocketShot;

    public bool shotMode;

    public GameObject debrisPrefab;

    public float laserForce = 10;

    public AudioClip[] smokeShotSounds;
    public AudioClip[] laserShotSounds;

    public float shotForce = 1000.0f;
    public float mouseSensitivity = 3.0f;

    float verticalRotation = 0.0f;
    float horizontalRotation = 0.0f;
    public float upDownRange = 70.0f;
    public float leftRightRange = 70.0f;

    public float range = 100.0f;

    void Start()
    {
        Screen.lockCursor = true;
        shotMode = false;
    }

	void Update () {

        //Rotation
        
        horizontalRotation += Input.GetAxis("Mouse X") * mouseSensitivity;
        horizontalRotation = Mathf.Clamp(horizontalRotation, -leftRightRange, leftRightRange);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        gameObject.transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
       
        if(Input.GetButtonDown("Fire1")){
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo;

            if(Physics.Raycast(ray, out hitInfo, range)){

                if (!shotMode)
                {
                    Rigidbody shotLeft = Instantiate(projectile, shotPosLeft.position, shotPosLeft.rotation) as Rigidbody;
                    Rigidbody shotRight = Instantiate(projectile, shotPosRight.position, shotPosRight.rotation) as Rigidbody;
                    Vector3 shotVectorLeft = hitInfo.point - shotLeft.transform.position;
                    Vector3 shotVectorRight = hitInfo.point - shotRight.transform.position;
                    shotLeft.AddForce(shotVectorLeft * shotForce, ForceMode.Acceleration);
                    shotRight.AddForce(shotVectorRight * shotForce, ForceMode.Acceleration);
                    int shotIndex = Random.Range(0, 3);
                    audio.clip = smokeShotSounds[shotIndex];
                    audio.Play();
                }else if(shotMode)
                {
                    Vector3 hitPoint = hitInfo.point;
                    GameObject go = hitInfo.collider.gameObject;
                    //Instantiate(debrisPrefab, hitPoint, Quaternion.identity);
                    if (go.rigidbody != null)
                    {
                        go.rigidbody.AddForceAtPosition((go.transform.position - hitPoint) * laserForce, hitPoint, ForceMode.Impulse);
                    }
                    int shotIndex = Random.Range(0, 3);
                    audio.clip = laserShotSounds[shotIndex];
                    audio.Play();
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            shotMode = !shotMode;
        }
	}
}
