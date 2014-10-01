using UnityEngine;
using System.Collections;

public class TurretSystemLoader : MonoBehaviour {

    public static TurretSystemLoader control;

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }
}
