using UnityEngine;
using System.Collections;

public class TortoiseLife : MonoBehaviour {

    public float HP;

    void Awake()
    {
        HP = GameObject.Find("Data").GetComponent<DamageData>().TortoiseHealth;
    }

    void Update()
    {
        if (HP < GameObject.Find("Data").GetComponent<DamageData>().TortoiseHealth)
        {
            HP += Time.deltaTime;
        }
    }
}
