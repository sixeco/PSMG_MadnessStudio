using UnityEngine;
using System.Collections;

public class Tiger_RocketLauncher : MonoBehaviour {

    private float CoolDownRocket;
    private float CoolDownRemain;

    private GameObject RocketObject;
    public Transform RocketLauncherShotPos;

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

    public void Shoot(Vector2 direction)
    {
        Debug.Log("Tiger shot" + direction);
    }
}
