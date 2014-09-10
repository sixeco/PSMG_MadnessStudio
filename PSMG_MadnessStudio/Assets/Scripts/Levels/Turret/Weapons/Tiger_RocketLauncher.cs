using UnityEngine;
using System.Collections;

public class Tiger_RocketLauncher : MonoBehaviour {

    private float CoolDown;
    private float CoolDownRemain;
    private GameObject RocketObject;
    private GameObject flash;

    public Transform RocketLauncherShotPos;
    public Camera camera;

    private float RayCheckRange;

    void Start()
    {
        CoolDownRemain = 0;
        GameObject data = GameObject.Find("Data");
        CoolDown = data.GetComponent<CoolDownValues>().RocketMain;
        RocketObject = data.GetComponent<ModelData>().RocketModel;
        flash = data.GetComponent<ModelData>().CannonMuzzleFlash;
        RayCheckRange = data.GetComponent<GUIData>().RayCheckRange;
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
            if (Physics.Raycast(ray, out hitInfo, RayCheckRange))
            {
                Quaternion rotation = Quaternion.LookRotation((hitInfo.point - (RocketLauncherShotPos.transform.position + RocketLauncherShotPos.transform.forward)).normalized);
                Instantiate(flash, RocketLauncherShotPos.position + RocketLauncherShotPos.up, rotation);
                Instantiate(RocketObject, RocketLauncherShotPos.transform.position, rotation);
            }
        }
    }
}
