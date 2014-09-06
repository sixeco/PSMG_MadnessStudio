using UnityEngine;
using System.Collections;

public class Tiger_RocketLauncher : MonoBehaviour {

    private float CoolDown;
    private float CoolDownRemain;
    private GameObject RocketObject;
    private GameObject flash;

    public Transform RocketLauncherShotPos;
    public Camera camera;

    void Start()
    {
        CoolDownRemain = 0;
        CoolDown = GameObject.Find("Data").GetComponent<CoolDownValues>().RocketMain;
        RocketObject = GameObject.Find("Data").GetComponent<ModelData>().RocketModel;
        flash = GameObject.Find("Data").GetComponent<ModelData>().CannonMuzzleFlash;
    }

    void Update()
    {
        CoolDownRemain -= Time.deltaTime;
    }

    public void Shoot(Vector2 direction)
    {
        if (CoolDownRemain <= 0)
        {
            CoolDownRemain = CoolDown;
            Ray ray = camera.ScreenPointToRay(new Vector3(direction.x, Screen.height - direction.y, 0));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 300f))
            {
                Quaternion rotation = Quaternion.LookRotation((hitInfo.point - (RocketLauncherShotPos.transform.position + RocketLauncherShotPos.transform.forward)).normalized);
                Instantiate(flash, RocketLauncherShotPos.position + RocketLauncherShotPos.up, Quaternion.identity);
                Instantiate(RocketObject, RocketLauncherShotPos.transform.position, rotation);
            }
        }
    }
}
