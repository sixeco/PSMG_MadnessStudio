using UnityEngine;
using System.Collections;

public class Turret_Activation : MonoBehaviour {

    public GameObject frontHead;
    public GameObject stand;

    public GameObject Left;
    public GameObject Right;

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
            DisableLeftWeapon();
            DisableRightWeapon();
        }
    }

    private void AssignLeftWeapon()
    {
        switch (GameObject.Find("Data").GetComponent<WeaponsData>().Left)
        {
            case WeaponsData.SelectedWeapon.Rabbit_TwinCannon:
                foreach (Transform child in Left.GetComponentsInChildren<Transform>())
                {
                    if (child.name.Equals("RabbitLeft"))
                    {
                        System_KeyInput.ShootLeft += child.GetComponent<Rabbit_TwinCannon>().Shoot;
                    }
                }
                return;
            case WeaponsData.SelectedWeapon.Tiger_RocketLauncher:
                foreach (Transform child in Left.GetComponentsInChildren<Transform>())
                {
                    if (child.name.Equals("TigerLeft"))
                    {
                        System_KeyInput.ShootLeft += child.GetComponent<Tiger_RocketLauncher>().Shoot;
                    }
                }
                return;
            case WeaponsData.SelectedWeapon.Cobra_Railgun:
                foreach (Transform child in Left.GetComponentsInChildren<Transform>())
                {
                    if (child.name.Equals("CobraLeft"))
                    {
                        System_KeyInput.ShootLeft += child.GetComponent<Cobra_Railgun>().Shoot;
                    }
                }
                return;
            case WeaponsData.SelectedWeapon.Woodpecker_Gatling:
                foreach (Transform child in Left.GetComponentsInChildren<Transform>())
                {
                    if (child.name.Equals("WoodpeckerLeft"))
                    {
                        System_KeyInput.ShootLeft += child.GetComponent<Woodpecker_Gatling>().Shoot;
                    }
                }
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
                foreach (Transform child in Right.GetComponentsInChildren<Transform>())
                {
                    if (child.name.Equals("RabbitRight"))
                    {
                        System_KeyInput.ShootRight += child.GetComponent<Rabbit_TwinCannon>().Shoot;
                    }
                }
                return;
            case WeaponsData.SelectedWeapon.Tiger_RocketLauncher:
                foreach (Transform child in Right.GetComponentsInChildren<Transform>())
                {
                    if (child.name.Equals("TigerRight"))
                    {
                        System_KeyInput.ShootRight += child.GetComponent<Tiger_RocketLauncher>().Shoot;
                    }
                }
                return;
            case WeaponsData.SelectedWeapon.Cobra_Railgun:
                foreach (Transform child in Right.GetComponentsInChildren<Transform>())
                {
                    if (child.name.Equals("CobraRight"))
                    {
                        System_KeyInput.ShootRight += child.GetComponent<Cobra_Railgun>().Shoot;
                    }
                }
                return;
            case WeaponsData.SelectedWeapon.Woodpecker_Gatling:
                foreach (Transform child in Right.GetComponentsInChildren<Transform>())
                {
                    if (child.name.Equals("WoodpeckerRight"))
                    {
                        System_KeyInput.ShootRight += child.GetComponent<Woodpecker_Gatling>().Shoot;
                    }
                }
                return;
            default:
                return;
        }
    }

    private void DisableLeftWeapon()
    {
        switch (GameObject.Find("Data").GetComponent<WeaponsData>().Left)
        {
            case WeaponsData.SelectedWeapon.Rabbit_TwinCannon:
                foreach (Transform child in Left.GetComponentsInChildren<Transform>())
                {
                    if (child.name.Equals("RabbitLeft"))
                    {
                        System_KeyInput.ShootLeft -= child.GetComponent<Rabbit_TwinCannon>().Shoot;
                    }
                }
                return;
            case WeaponsData.SelectedWeapon.Tiger_RocketLauncher:
                foreach (Transform child in Left.GetComponentsInChildren<Transform>())
                {
                    if (child.name.Equals("TigerLeft"))
                    {
                        System_KeyInput.ShootLeft -= child.GetComponent<Tiger_RocketLauncher>().Shoot;
                    }
                }
                return;
            case WeaponsData.SelectedWeapon.Cobra_Railgun:
                foreach (Transform child in Left.GetComponentsInChildren<Transform>())
                {
                    if (child.name.Equals("CobraLeft"))
                    {
                        System_KeyInput.ShootLeft -= child.GetComponent<Cobra_Railgun>().Shoot;
                    }
                }
                return;
            case WeaponsData.SelectedWeapon.Woodpecker_Gatling:
                foreach (Transform child in Left.GetComponentsInChildren<Transform>())
                {
                    if (child.name.Equals("WoodpeckerLeft"))
                    {
                        System_KeyInput.ShootLeft -= child.GetComponent<Woodpecker_Gatling>().Shoot;
                    }
                }
                return;
            default:
                return;
        }
    }

    private void DisableRightWeapon()
    {
        switch (GameObject.Find("Data").GetComponent<WeaponsData>().Right)
        {
            case WeaponsData.SelectedWeapon.Rabbit_TwinCannon:
                foreach (Transform child in Right.GetComponentsInChildren<Transform>())
                {
                    if (child.name.Equals("RabbitRight"))
                    {
                        System_KeyInput.ShootRight -= child.GetComponent<Rabbit_TwinCannon>().Shoot;
                    }
                }
                return;
            case WeaponsData.SelectedWeapon.Tiger_RocketLauncher:
                foreach (Transform child in Right.GetComponentsInChildren<Transform>())
                {
                    if (child.name.Equals("TigerRight"))
                    {
                        System_KeyInput.ShootRight -= child.GetComponent<Tiger_RocketLauncher>().Shoot;
                    }
                }
                return;
            case WeaponsData.SelectedWeapon.Cobra_Railgun:
                foreach (Transform child in Right.GetComponentsInChildren<Transform>())
                {
                    if (child.name.Equals("CobraRight"))
                    {
                        System_KeyInput.ShootRight -= child.GetComponent<Cobra_Railgun>().Shoot;
                    }
                }
                return;
            case WeaponsData.SelectedWeapon.Woodpecker_Gatling:
                foreach (Transform child in Right.GetComponentsInChildren<Transform>())
                {
                    if (child.name.Equals("WoodpeckerRight"))
                    {
                        System_KeyInput.ShootRight -= child.GetComponent<Woodpecker_Gatling>().Shoot;
                    }
                }
                return;
            default:
                return;
        }
    }
}
