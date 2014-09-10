using UnityEngine;
using System.Collections;

public class WeaponsData : MonoBehaviour {

    public enum SelectedWeapon { Rabbit_TwinCannon, Tiger_RocketLauncher, Cobra_Railgun, Woodpecker_Gatling };

    public SelectedWeapon Left;
    public SelectedWeapon Right;
    public bool Tortoise;

    public float WoodpeckerSpinSpeed;
    public float TigerRocketSpeed;
}
