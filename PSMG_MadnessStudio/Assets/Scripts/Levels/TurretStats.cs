using UnityEngine;
using System.Collections;

public class TurretStats : MonoBehaviour {

    public bool isGazeInputActive = false;
    public bool isAOIcontrolActive = false;
    public bool isAOIvisible = false;

    public GameObject dataObject;

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
    }

    private bool GetBoolData(string key)
    {
        switch (key)
        {
            case "isGazeInputActive":
                return isGazeInputActive;
            case "isAOIcontrolActive":
                return isAOIcontrolActive;
            case "isAOIvisible":
                return isAOIvisible;
            default:
                return false;
        }
    }
}
