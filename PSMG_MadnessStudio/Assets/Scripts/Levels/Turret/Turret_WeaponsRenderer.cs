using UnityEngine;
using System.Collections;

public class Turret_WeaponsRenderer : MonoBehaviour {

    public GameObject Left;
    public GameObject Right;

    void Start()
    {
        DisrenderAll();
        RenderLeftWeapon();
        RenderRightWeapon();
    }

    void DisrenderAll()
    {
        foreach (MeshRenderer child in Left.GetComponentsInChildren<MeshRenderer>())
        {
            child.GetComponent<MeshRenderer>().enabled = false;
        }
        foreach (MeshRenderer child in Right.GetComponentsInChildren<MeshRenderer>())
        {
            child.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void RenderLeftWeapon()
    {
        switch (GameObject.Find("Data").GetComponent<WeaponsData>().Left)
        {
            case WeaponsData.SelectedWeapon.Rabbit_TwinCannon:
                EnableWeapon("RabbitLeft");
                return;
            case WeaponsData.SelectedWeapon.Tiger_RocketLauncher:
                EnableWeapon("TigerLeft");
                return;
            case WeaponsData.SelectedWeapon.Cobra_Railgun:
                EnableWeapon("CobraLeft");
                return;
            case WeaponsData.SelectedWeapon.Woodpecker_Gatling:
                EnableWeapon("WoodpeckerLeft");
                return;
            default:
                return;
        }
    }

    void RenderRightWeapon()
    {
        switch (GameObject.Find("Data").GetComponent<WeaponsData>().Right)
        {
            case WeaponsData.SelectedWeapon.Rabbit_TwinCannon:
                EnableWeapon("RabbitRight");
                return;
            case WeaponsData.SelectedWeapon.Tiger_RocketLauncher:
                EnableWeapon("TigerRight");
                return;
            case WeaponsData.SelectedWeapon.Cobra_Railgun:
                EnableWeapon("CobraRight");
                return;
            case WeaponsData.SelectedWeapon.Woodpecker_Gatling:
                EnableWeapon("WoodpeckerRight");
                return;
            default:
                return;
        }
    }

    void EnableWeapon(string name)
    {
        foreach (Transform child in Left.GetComponentsInChildren<Transform>())
        {
            if (child.parent.name.Equals(name) && child.GetComponent<MeshRenderer>())
            {
                child.GetComponent<MeshRenderer>().enabled = true;
            }
        }
        foreach (Transform child in Right.GetComponentsInChildren<Transform>())
        {
            if (child.parent.name.Equals(name) && child.GetComponent<MeshRenderer>())
            {
                child.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
