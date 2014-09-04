using UnityEngine;
using System.Collections;

public class Woodpecker_MuzzleSpin : MonoBehaviour {

    private float RotationSpeed;
    public GameObject Muzzle;
    public bool Clockwise;

    void Start()
    {
        if (Clockwise)
        {
            RotationSpeed = GameObject.Find("Data").GetComponent<WeaponsData>().WoodpeckerSpinSpeed;
        }
        else
        {
            RotationSpeed = -GameObject.Find("Data").GetComponent<WeaponsData>().WoodpeckerSpinSpeed;
        }
    }

	void Update () {
        if (GameObject.Find("Data").GetComponent<WeaponsData>().Left == WeaponsData.SelectedWeapon.Woodpecker_Gatling || GameObject.Find("Data").GetComponent<WeaponsData>().Right == WeaponsData.SelectedWeapon.Woodpecker_Gatling)
        {
            Muzzle.transform.Rotate(RotationSpeed * Time.deltaTime, 0, 0);
        }
	}
}
