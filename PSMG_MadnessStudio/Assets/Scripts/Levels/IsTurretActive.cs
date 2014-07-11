using UnityEngine;
using System.Collections;

public class IsTurretActive : MonoBehaviour {

    public void SetAcivation(bool mode)
    {
        if (mode == false)
        {
            MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }
        }
        else
        {
            if (ActivationDataStatic.isGazeInputActive)
            {
                this.GetComponent<MouseViewControl>().enabled = false;
                this.GetComponent<DrawMouseCursor>().enabled = false;
                this.GetComponent<AOIControls4Panel>().enabled = true;
                this.GetComponent<DrawGazeCursor>().enabled = true;
            }
            else
            {
                this.GetComponent<MouseViewControl>().enabled = true;
                
            }
            this.GetComponent<KeyControls>().enabled = true;
            this.GetComponent<TwinCannon>().enabled = true;
            this.GetComponent<RocketLauncher>().enabled = true;
        }
    }
}
