using UnityEngine;
using System.Collections;

public class WeaponsData : MonoBehaviour {

    public enum SelectedWeapon { Rabbit_TwinCannon, Tiger_RocketLauncher, Woodpecker_Gatling, Cobra_Railgun};

    public SelectedWeapon Left;
    public SelectedWeapon Right;
    public bool Tortoise;
}
