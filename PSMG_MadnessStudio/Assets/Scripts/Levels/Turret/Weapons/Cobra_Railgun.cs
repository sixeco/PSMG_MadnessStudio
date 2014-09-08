using UnityEngine;
using System.Collections;

public class Cobra_Railgun : MonoBehaviour {
    
    public Camera Camera;
    public Transform shotPos;

    private GameObject Strike;

    void Start()
    {
        Strike = GameObject.Find("Data").GetComponent<ModelData>().LaserSpark;
    }

    public void Shoot(Vector2 direction)
    {
        Ray ray = Camera.ScreenPointToRay(new Vector2(direction.x, Screen.height * direction.y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 300f))
        {
            Instantiate(Strike, hit.point, Quaternion.identity);
        }
    }
}
