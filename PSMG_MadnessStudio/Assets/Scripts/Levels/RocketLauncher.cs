using UnityEngine;
using System.Collections;

public class RocketLauncher : MonoBehaviour {

    public delegate Vector3 InputEvent();
    public static event InputEvent MainInput;

    private float CoolDownRocket;
    private float CoolDownRemain;

    private GameObject RocketObject;
    public Transform RocketLauncherShotPos;

    void OnEnable()
    {
        KeyControls.RocketLaunch += ShootRocket;
    }

    void OnDisable()
    {
        KeyControls.RocketLaunch -= ShootRocket;
    }

	void Start () {
        CoolDownRemain = 0;
        CoolDownRocket = CoolDownDataStatic.RocketCoolDown;
        RocketObject = ModelDataStatic.RocketModel;
	}
	
	void Update () {
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
            }
        }
    }
}
