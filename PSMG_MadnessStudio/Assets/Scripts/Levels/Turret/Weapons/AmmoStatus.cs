using UnityEngine;
using System.Collections;

public class AmmoStatus : MonoBehaviour {

    public int RabbitStock;
    public int TigerStock;
    public int CobraStock;
    public int WoodpeckerStock;

    public int RabbitMag;
    public int TigerMag;
    public int CobraMag;
    public int WoodpeckerMag;

    void Start()
    {
        AmmoData data = GameObject.Find("Data").GetComponent<AmmoData>();
        RabbitStock = data.RabbitStartAmmo;
        TigerStock = data.TigerStartAmmo;
        CobraStock = data.CobraStartAmmo;
        WoodpeckerStock = data.WoodpeckerStartAmmo;
    }
}
