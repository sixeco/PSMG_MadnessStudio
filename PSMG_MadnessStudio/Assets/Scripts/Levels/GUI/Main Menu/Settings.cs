using UnityEngine;
using System.Collections;
using iViewX;

public class Settings : MonoBehaviour {

    public bool settingsActive;
    private Font settingsFont;

    private int controlsSelectionIndex = 0;
    private string[] controls = new string[] {"Mouse only", "Gaze and Mouse", "Gaze only"};
    private Rect ControlsSelectionRect;

    private ControlOptions options;

    private Rect CalibrationRect;

    void Start()
    {
        settingsActive = false;
        settingsFont = this.GetComponent<MainMenuView>().generalFont;
        options = GameObject.Find("Data").GetComponent<ControlOptions>();
        ControlsSelectionRect = new Rect(Screen.width / 2 - ((Screen.width * 0.1f) * 1.5f), Screen.height / 10 * 8, Screen.width * 0.3f, Screen.height * 0.05f);
        CalibrationRect = new Rect(Screen.width / 2 - Screen.width * 0.1f, Screen.height / 10 * 8 + Screen.height * 0.07f, Screen.width * 0.2f, Screen.height * 0.05f);
    }

    void Update()
    {
        switch (controlsSelectionIndex)
        {
            case 0:
                options.SelectedControls = ControlOptions.ControlType.MouseOnly;
                break;
            case 1:
                options.SelectedControls = ControlOptions.ControlType.GazeAndMouse;
                break;
            case 2:
                options.SelectedControls = ControlOptions.ControlType.GazeAndAOI;
                break;
            default:
                options.SelectedControls = ControlOptions.ControlType.MouseOnly;
                break;
        }
    }

    void OnGUI()
    {
        GUI.skin.box.font = settingsFont;
        GUI.skin.button.font = settingsFont;
        GUI.skin.textArea.fontSize = Mathf.Min(Screen.width, Screen.height) / 10;

        

        if (settingsActive)
        {
            GUI.Box(new Rect(Screen.width / 2 - Screen.width / 3 / 2, Screen.height / 8 * 6, Screen.width / 3, Screen.height / 20), "Select control type");
            if (GUI.Button(CalibrationRect, "Calibrate Eye-Tracker"))
            {
                GazeControlComponent.Instance.StartCalibration();
            }
            controlsSelectionIndex = GUI.SelectionGrid(ControlsSelectionRect, controlsSelectionIndex, controls, 3); 
        }
    }
}
