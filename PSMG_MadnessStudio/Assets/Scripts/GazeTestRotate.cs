using UnityEngine;
using System.Collections;
using iViewX;

public class GazeTestRotate : MonoBehaviourWithGazeComponent {

    public float rotationsPerMinute = 100.0f;

    public override void OnGazeEnter(RaycastHit hit)
    {
        
    }

    public override void OnGazeStay(RaycastHit hit)
    {
        transform.Rotate(0, 0, rotationsPerMinute * Time.deltaTime);
    }

    public override void OnGazeExit()
    {
        
    }
}
