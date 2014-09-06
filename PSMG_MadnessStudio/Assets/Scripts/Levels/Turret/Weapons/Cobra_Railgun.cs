using UnityEngine;
using System.Collections;

public class Cobra_Railgun : MonoBehaviour {

    RaycastHit hitInfo;
    float range = 300.0f;
    LineRenderer line;
    
    public Camera Camera;
    public Transform shotPos;

    void Start()
    {
        line = this.GetComponent<LineRenderer>();
        line.SetVertexCount(2);
        line.renderer.material = GameObject.Find("Data").GetComponent<MaterialData>().CobraLineMaterial;
        line.SetWidth(0.3f, 0.25f);
    }

    void Update()
    {
        /* First try
        LineRenderer lineRenderer = this.GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        lineRenderer.SetVertexCount(2);
        RaycastHit hit;
        Physics.Raycast(this.transform.position, transform.forward, out hit);
        if (hit.collider)
        {
            lineRenderer.SetPosition(1, new Vector3(0, 0, hit.distance));
        }
        else
        {
            lineRenderer.SetPosition(1, new Vector3(0, 0, 5000));
        }*/


    }

    public void Shoot(Vector2 direction)
    {
        Ray ray = Camera.ScreenPointToRay(new Vector2(direction.x, Screen.height - direction.y));
        if (Physics.Raycast(ray, out hitInfo, range))
        {
            line.enabled = true;
            line.SetPosition(0, shotPos.position);
            line.SetPosition(1, hitInfo.point + hitInfo.normal);
        }
    }
}
