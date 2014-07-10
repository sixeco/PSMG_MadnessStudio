using UnityEngine;
using System.Collections;
using iViewX;

public class MainMenuView : MonoBehaviour {

    public delegate void LoadingAction();
    public static event LoadingAction LoadLevel;
    public GameObject title;

    private int LoadingProgress = 0;
	
    void OnGUI()
    {
        #region Buttons
        if (GUI.Button(new Rect(Screen.width * 0.35f, Screen.height * 0.7f, Screen.width * 0.1f, Screen.height * 0.1f), "Start Calibration"))
        {
            GazeControlComponent.Instance.StartCalibration();
        }
        if (GUI.Button(new Rect(Screen.width * 0.45f, Screen.height * 0.7f, Screen.width * 0.1f, Screen.height * 0.1f), "Start Validation"))
        {
            GazeControlComponent.Instance.StartValidation();
        }
        if (GUI.Button(new Rect(Screen.width * 0.55f, Screen.height * 0.7f, Screen.width * 0.1f, Screen.height * 0.1f), "Start Simulation"))
        {
            LoadLevel();
            this.enabled = false;
            title.SetActive(false);
        }
        #endregion
    }
}
