using UnityEngine;
using System.Collections;

public class PokeScript : MonoBehaviour {

    public float force;

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            //rigidbody.AddForce(new Vector3(0, 0, force), ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForceAtPosition((transform.position - hit.point) * force, hit.point, ForceMode.Impulse);
        }
    }
}
