using UnityEngine;
using System.Collections;

public class Woodpecker_MuzzleSpin : MonoBehaviour {

    public float RotationSpeed;

	void Update () {
        if (GameObject.Find("Data").GetComponent<WeaponsData>().Left == WeaponsData.SelectedWeapon.Woodpecker_Gatling || GameObject.Find("Data").GetComponent<WeaponsData>().Right == WeaponsData.SelectedWeapon.Woodpecker_Gatling)
        {
            GameObject.Find("Data").GetComponent<WeaponsData>();
        }
	}
}
