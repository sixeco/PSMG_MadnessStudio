using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public Rigidbody projectile;
    public Transform shotPosLeft;
    public Transform shotPosRight;

    public AudioClip[] shotSounds;

    public float shotForce = 1000.0f;
    public float mouseSensitivity = 3.0f;

    float verticalRotation = 0.0f;
    float horizontalRotation = 0.0f;
    public float upDownRange = 70.0f;
    public float leftRightRange = 70.0f;

    public float coolDown = 0.2f;
    public float coolDownRemain = 0;

    public float range = 100.0f;

    void Start()
    {
        Screen.lockCursor = true;
    }

	void Update () {

        //Rotation
        
        horizontalRotation += Input.GetAxis("Mouse X") * mouseSensitivity;
        horizontalRotation = Mathf.Clamp(horizontalRotation, -leftRightRange, leftRightRange);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        gameObject.transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
       
        if(Input.GetButtonDown("Fire1")){
            coolDownRemain = coolDown;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo;

            if(Physics.Raycast(ray, out hitInfo, range)){
                
                Rigidbody shotLeft = Instantiate(projectile, shotPosLeft.position, shotPosLeft.rotation) as Rigidbody;
                Rigidbody shotRight = Instantiate(projectile, shotPosRight.position, shotPosRight.rotation) as Rigidbody;
                Vector3 shotVectorLeft = hitInfo.point - shotLeft.transform.position;
                Vector3 shotVectorRight = hitInfo.point - shotRight.transform.position;
                shotLeft.AddForce(shotPosLeft.transform.forward * shotForce);
                shotRight.AddForce(shotPosRight.transform.forward * shotForce);

                int shotIndex = Random.Range(0, 3);
                audio.clip = shotSounds[shotIndex];
                audio.Play();
            }
        }
	}
}
