using UnityEngine;
using System.Collections;

public class Turret_Activation : MonoBehaviour {

    public GameObject frontHead;
    public GameObject stand;

    public void setActivation(bool mode)
    {
        if (mode)
        {
            System_ViewInput.Mouse += this.GetComponent<Turret_ViewControl>().TurnCameraMouse;
            System_ViewInput.GazeOnly += this.GetComponent<Turret_ViewControl>().TurnCameraGaze;
            frontHead.GetComponent<MeshRenderer>().enabled = false;
            stand.GetComponent<MeshRenderer>().enabled = false;
            stand.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            System_ViewInput.Mouse -= this.GetComponent<Turret_ViewControl>().TurnCameraMouse;
            System_ViewInput.GazeOnly -= this.GetComponent<Turret_ViewControl>().TurnCameraGaze;
            frontHead.GetComponent<MeshRenderer>().enabled = true;
            stand.GetComponent<MeshRenderer>().enabled = false;
            stand.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
