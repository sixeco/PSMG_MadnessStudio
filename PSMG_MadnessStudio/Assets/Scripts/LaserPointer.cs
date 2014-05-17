using UnityEngine;
using System.Collections;

public class LaserPointer : MonoBehaviour {

    public LineRenderer lineRenderer;
    public Transform bulletSpawn;
    public GameObject laserEndpoint;
    public int range = 30;

	void Update () 
    {
        lineRenderer.SetPosition(0, transform.position);
        RaycastHit hit;
        if(Physics.Raycast(bulletSpawn.position, bulletSpawn.forward, out hit, range))
        {
            lineRenderer.SetPosition(1, hit.point);
            if(laserEndpoint)
            {
                laserEndpoint.SetActive(true);
                laserEndpoint.transform.position = hit.point + hit.normal * 0.01f;
                laserEndpoint.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            }
        }
        else
        {
            lineRenderer.SetPosition(1, transform.position + transform.forward * range);
            if(laserEndpoint){
                laserEndpoint.SetActive(false);
            }
        }
	}
}
