using UnityEngine;
using System.Collections;

public class Cobra_Railgun : MonoBehaviour {
    
    public Camera Camera;
    public Transform shotPos;

    private GameObject Strike;
    private GameObject Flash;
    private float RayCheckRange;
    private float CoolDown;
    private float CoolDownRemain;

    void Start()
    {
        GameObject data = GameObject.Find("Data");
        Strike = data.GetComponent<ModelData>().LaserSpark;
        Flash = data.GetComponent<ModelData>().CannonMuzzleFlash;
        RayCheckRange = data.GetComponent<GUIData>().RayCheckRange;
        CoolDown = data.GetComponent<CoolDownValues>().LaserMain;
        CoolDownRemain = 0;
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
            Ray ray = Camera.ScreenPointToRay(new Vector2(direction.x, Screen.height - direction.y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, RayCheckRange))
            {
                Instantiate(Flash, shotPos.position, Quaternion.identity);
                Instantiate(Strike, hit.point, Quaternion.identity);
            }
        }
    }
}
