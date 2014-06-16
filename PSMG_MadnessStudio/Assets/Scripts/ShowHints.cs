using UnityEngine;
using System.Collections;

public class ShowHints : MonoBehaviour {

    public GUIStyle style;

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, Screen.width * 0.3f, Screen.height * 0.3f), "Hints: ", style);
        GUI.Label(new Rect(0, 12, Screen.width * 0.3f, Screen.height * 0.3f), "Move the cursor to the border of the screen to move camera", style);
        GUI.Label(new Rect(0, 24, Screen.width * 0.3f, Screen.height * 0.3f), "Use 'ASDF' to switch turrets.", style);
        GUI.Label(new Rect(0, 36, Screen.width * 0.3f, Screen.height * 0.3f), "Press/Hold the left mousebutton to shoot the Twincannons", style);
        GUI.Label(new Rect(0, 48, Screen.width * 0.3f, Screen.height * 0.3f), "Press the right mousebutton to shoot the Rocketlauncher", style);
        GUI.Label(new Rect(0, 60, Screen.width * 0.3f, Screen.height * 0.3f), "Use 'J' to switch Twincannon shotmode", style);
        GUI.Label(new Rect(0, 72, Screen.width * 0.3f, Screen.height * 0.3f), "Use the spacebar to reset the scene", style);
    }
}
