using UnityEngine;
using System.Collections;

public class WeaponsData : MonoBehaviour {

    public enum SelectedWeapon { Rabbit_TwinCannon, Tiger_RocketLauncher, Cobra_Railgun, Woodpecker_Gatling };

    public SelectedWeapon Left;
    public SelectedWeapon Right;

    public float WoodpeckerSpinSpeed;
    public float WoodpeckerProjectileSpeed;
    public float TigerRocketSpeed;
    public float CobraProjectileSpeed;
    public float RabbitProkectileSpeed;

    public bool GraviyGun;
    public float CatchRange;
    public float HoldDistance;
    public float MinimumForce;
    public float MaximumForce;
    public float ForceChargePerSec;
}
