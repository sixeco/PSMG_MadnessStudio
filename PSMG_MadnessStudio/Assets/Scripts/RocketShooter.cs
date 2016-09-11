using UnityEngine;
using System.Collections;

public class RocketShooter : MonoBehaviour {

    private bool isActive;

    private float coolDownRocket;
    private float coolDownRemain;

    public GameObject rocket;
    public Transform rocketShotPos;

    public AudioClip rocketSound;

    void Start()
    {
        coolDownRemain = 0;
        coolDownRocket = this.transform.parent.gameObject.transform.parent.GetComponent<GeneralCoolDowns>().rocketCoolDown; 
        isActive = this.GetComponent<TurretActivation>().isActive;
    }

	void Update () {

        coolDownRemain -= Time.deltaTime;
        isActive = this.GetComponent<TurretActivation>().isActive;

        if (isActive)
        {
            if (Input.GetKey(KeyCode.Mouse1) && coolDownRemain <= 0)
            {
                coolDownRemain = coolDownRocket;
                //Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 200f))
                {
                    Quaternion rotation = Quaternion.LookRotation((hit.point - (rocketShotPos.transform.position + rocketShotPos.transform.forward)).normalized);
                    Instantiate(rocket, rocketShotPos.transform.position + rocketShotPos.transform.forward, rotation);
                    GetComponent<AudioSource>().clip = rocketSound;
                    GetComponent<AudioSource>().Play();
                }
            }
        }
	}
}
