using UnityEngine;
using System.Collections;

public class MouseOverObject : MonoBehaviour {

    public float rotationSpeed = 10.0f;

    void onMouseOver()
    {
        Camera.main.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
