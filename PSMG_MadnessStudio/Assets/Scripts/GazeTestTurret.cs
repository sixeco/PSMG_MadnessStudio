using UnityEngine;
using System.Collections;
using iViewX;

public class GazeTestTurret : MonoBehaviourWithGazeComponent {

    public float horizontalSpeed = 10.0f;
    float horizontalRotation = 0;

    public override void OnGazeEnter(RaycastHit hit)
    {

    }

    public override void OnGazeStay(RaycastHit hit)
    {
        horizontalRotation += horizontalSpeed;
        Camera.main.transform.localRotation = Quaternion.Euler(0, horizontalRotation, 0);
    }

    public override void OnGazeExit()
    {

    }
}
