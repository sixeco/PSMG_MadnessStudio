using UnityEngine;
using System.Collections;

public class GravityGun : MonoBehaviour {

    float catchRange = 100.0f;
    float holdDistance = 8.0f;
    float minForce = 1000;
    float maxForce = 10000;
    float forceChargePerSec = 3000;
    LayerMask layerMask = -1;

    enum GravityGunState { Free, Catch, Occupied, Charge, Release };
    private GravityGunState gravityGunState = 0;
    private Rigidbody rigid = null;
    private float currentForce;

    void Start()
    {
        WeaponsData data = GameObject.Find("Data").GetComponent<WeaponsData>();
        catchRange = data.CatchRange;
        holdDistance = data.HoldDistance;
        minForce = data.MinimumForce;
        maxForce = data.MaximumForce;
        forceChargePerSec = data.ForceChargePerSec;
        currentForce = minForce;
    }

    void FixedUpdate()
    {
        if (gravityGunState == GravityGunState.Free)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, catchRange, layerMask))
                {
                    if (hit.rigidbody)
                    {
                        rigid = hit.rigidbody;
                        gravityGunState = GravityGunState.Catch;
                    }
                }
            }
        }
        else if (gravityGunState == GravityGunState.Catch)
        {
            rigid.MovePosition(transform.position + transform.forward * holdDistance);
            if (!Input.GetKey(KeyCode.Space))
            {
                gravityGunState = GravityGunState.Occupied;
            }
        }
        else if (gravityGunState == GravityGunState.Occupied)
        {
            rigid.MovePosition(transform.position + transform.forward * holdDistance);
            if (Input.GetKey(KeyCode.Space))
            {
                gravityGunState = GravityGunState.Charge;
            }
        }
        else if (gravityGunState == GravityGunState.Charge)
        {
            rigid.MovePosition(transform.position + transform.forward * holdDistance);
            if (currentForce < maxForce)
            {
                currentForce += forceChargePerSec * Time.deltaTime;
            }
            else
            {
                currentForce = maxForce;
            }
            if (!Input.GetKey(KeyCode.Space))
            {
                gravityGunState = GravityGunState.Release;
            }
        }
        else if (gravityGunState == GravityGunState.Release)
        {
            rigid.AddForce(transform.forward * currentForce);
            currentForce = minForce;
            gravityGunState = GravityGunState.Free;
        }

    }
}
