using UnityEngine;
using System.Collections;

public class TurretStats : MonoBehaviour {

    public bool isGazeInputActive = false;
    public bool isAOIcontrolActive = false;
    public bool isAOIvisible = false;
    public GameObject dataObject;

    void OnStart()
    {
        if (isGazeInputActive)
        {
            isAOIcontrolActive = true;
        }
        if (isAOIcontrolActive == false)
        {
            isGazeInputActive = false;
            isAOIvisible = false;
        }
    }
}
