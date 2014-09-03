using UnityEngine;
using System.Collections;

public class Turret_Activation : MonoBehaviour {

    public GameObject frontHead;
    public GameObject stand;

    void Update()
    {

    }

    public void setActivation(bool mode)
    {
        if (mode)
        {
            System_ViewInput.Mouse += this.GetComponent<Turret_ViewControl>().TurnCameraMouse;
            System_ViewInput.GazeOnly += this.GetComponent<Turret_ViewControl>().TurnCameraGaze;
            frontHead.GetComponent<MeshRenderer>().enabled = false;
            stand.GetComponent<MeshRenderer>().enabled = false;
            stand.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            DisableAllWeapons();
            AssignLeftWeapon();
            AssignRightWeapon();
        }
        else
        {
            System_ViewInput.Mouse -= this.GetComponent<Turret_ViewControl>().TurnCameraMouse;
            System_ViewInput.GazeOnly -= this.GetComponent<Turret_ViewControl>().TurnCameraGaze;
            frontHead.GetComponent<MeshRenderer>().enabled = true;
            stand.GetComponent<MeshRenderer>().enabled = true;
            stand.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            DisableAllWeapons();
        }
    }

    private void AssignLeftWeapon()
    {
        /*
        Debug.Log(gameObject.GetComponentsInChildren<Transform>());
        foreach(Transform child in gameObject.GetComponentsInChildren<Transform>()){
            Debug.Log(child);
        }*/
        switch (GameObject.Find("Data").GetComponent<WeaponsData>().Left)
        {
            case WeaponsData.SelectedWeapon.Rabbit_TwinCannon:
                //System_KeyInput.ShootLeft += 
                return;
            case WeaponsData.SelectedWeapon.Tiger_RocketLauncher:
                return;
            case WeaponsData.SelectedWeapon.Cobra_Railgun:
                return;
            case WeaponsData.SelectedWeapon.Woodpecker_Gatling:
                return;
            default:
                return;
        }
    }

    private void AssignRightWeapon()
    {
        switch (GameObject.Find("Data").GetComponent<WeaponsData>().Right)
        {
            case WeaponsData.SelectedWeapon.Rabbit_TwinCannon:
                return;
            case WeaponsData.SelectedWeapon.Tiger_RocketLauncher:
                return;
            case WeaponsData.SelectedWeapon.Cobra_Railgun:
                return;
            case WeaponsData.SelectedWeapon.Woodpecker_Gatling:
                return;
            default:
                return;
        }
    }

    private void DisableAllWeapons()
    {

    }
}
