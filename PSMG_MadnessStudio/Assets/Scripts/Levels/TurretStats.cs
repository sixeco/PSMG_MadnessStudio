using UnityEngine;
using System.Collections;

public class TurretStats : MonoBehaviour {

    public bool isGazeInputActive = false;
    public bool isAOIcontrolActive = false;
    public bool isAOIvisible = false;

    void Start()
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
        ActivationDataStatic.isGazeInputActive = isGazeInputActive;
        ActivationDataStatic.isAOIcontrolActive = isAOIcontrolActive;
        ActivationDataStatic.isAOIvisible = isAOIvisible;
    }
}
