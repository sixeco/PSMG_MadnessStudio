using UnityEngine;
using System.Collections;

public class Tiger_RocketLauncher : MonoBehaviour {

<<<<<<< HEAD
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
=======
    public delegate Vector3 InputEvent();
    public static event InputEvent MainInput;

    private float CoolDownRocket;
    private float CoolDownRemain;

    private GameObject RocketObject;
    public Transform RocketLauncherShotPos;

    public AudioClip rocketSound;

    void Start()
    {
        CoolDownRemain = 0;
        CoolDownRocket = GameObject.Find("Data").GetComponent<CoolDownValues>().RocketMain;
        RocketObject = GameObject.Find("Data").GetComponent<ModelData>().RocketModel;
    }

    void Update()
    {
        CoolDownRemain -= Time.deltaTime;
    }

    void ShootRocket()
    {
        if (CoolDownRemain <= 0)
        {
            CoolDownRemain = CoolDownRocket;
            Ray ray = this.camera.ScreenPointToRay(MainInput());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 200f))
            {
                Quaternion rotation = Quaternion.LookRotation((hit.point - (RocketLauncherShotPos.transform.position + RocketLauncherShotPos.transform.forward)).normalized);
                Instantiate(RocketObject, RocketLauncherShotPos.transform.position + RocketLauncherShotPos.transform.forward, rotation);
                audio.clip = rocketSound;
                audio.Play();
            }
        }
    }
>>>>>>> origin/Gameplay
}
