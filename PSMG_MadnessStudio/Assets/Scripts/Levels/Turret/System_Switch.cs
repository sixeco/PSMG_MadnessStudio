using UnityEngine;
using System.Collections;

public class System_Switch : MonoBehaviour {

    public Camera[] turrets;

    void Awake()
    {
        System_KeyInput.S_KeyInput += setActivation;
    }

    void Start()
    {
        ReActivate(turrets, 0);
    }

    public void setActivation(KeyCode key)
    {
        if (key == KeyCode.F)
        {
            ReActivate(turrets, 0);
        }
        else if (key == KeyCode.D)
        {
            ReActivate(turrets, 1);
        }
        else if (key == KeyCode.S)
        {
            ReActivate(turrets, 2);
        }
        else if (key == KeyCode.A)
        {
            ReActivate(turrets, 3);
        }
    }

    private void ReActivate(Camera[] turrets, int activeIndex)
    {
        if ((activeIndex + 1) > turrets.Length) return;
        for (int i = 0; i < turrets.Length; i++)
        {
            turrets[i].GetComponent<Turret_Activation>().setActivation(false);
            turrets[i].GetComponent<Camera>().enabled = false;
            turrets[i].GetComponent<AudioListener>().enabled = false;
            turrets[i].GetComponent<GUILayer>().enabled = false;
        }

        turrets[activeIndex].GetComponent<Turret_Activation>().setActivation(true);
        turrets[activeIndex].GetComponent<Camera>().enabled = true;
        turrets[activeIndex].GetComponent<AudioListener>().enabled = true;
        turrets[activeIndex].GetComponent<GUILayer>().enabled = true;
    }
}
