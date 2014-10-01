using UnityEngine;
using System.Collections;
using iViewX;

public class PauseGame : MonoBehaviour {

    public string MainMenuSceneName;
    public Font PauseMenuFont;
    public bool gameOver;
    public bool pauseEnabled;

    GameObject turretSysten;

    void Start()
    {
        turretSysten = GameObject.Find("Turret_System");
        gameOver = false;
        pauseEnabled = false;
        Time.timeScale = 1;
        AudioListener.volume = 1;
        Screen.showCursor = false;
    }

    void Update()
    {
        //check if pause button (escape key) is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //check if game is already paused		
            if (pauseEnabled == true)
            {
                //unpause the game
                turretSysten.GetComponent<System_ViewInput>().pauseActive = false;
                turretSysten.GetComponent<System_KeyInput>().pauseActive = false;
                pauseEnabled = false;
                Time.timeScale = 1;
                AudioListener.volume = 1;
                Screen.showCursor = false;
            }

            //else if game isn't paused, then pause it
            else if (pauseEnabled == false)
            {
                turretSysten.GetComponent<System_ViewInput>().pauseActive = true;
                turretSysten.GetComponent<System_KeyInput>().pauseActive = true;
                pauseEnabled = true;
                AudioListener.volume = 0;
                Time.timeScale = 0;
                Screen.showCursor = true;
                Screen.lockCursor = false;
            }
        }
        else if (gameOver)
        {
            turretSysten.GetComponent<System_ViewInput>().pauseActive = true;
            turretSysten.GetComponent<System_KeyInput>().pauseActive = true;
            pauseEnabled = true;
            AudioListener.volume = 0;
            Time.timeScale = 0;
            Screen.showCursor = true;
        }
    }

    private bool showCalibrationDropdown = false;

    void OnGUI()
    {
        GUI.skin.box.font = PauseMenuFont;
        GUI.skin.button.font = PauseMenuFont;

        if (pauseEnabled || gameOver)
        {

            //Make a background box
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250, 200), "Pause Menu");

            //Make Main Menu button
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 250, 50), "Main Menu"))
            {
                Destroy(GameObject.Find("Turret_System"));
                Application.LoadLevel(MainMenuSceneName);
            }

            //Make Change Graphics Quality button
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 250, 50), "Gaze Options"))
            {

                if (showCalibrationDropdown == false)
                {
                    showCalibrationDropdown = true;
                }
                else
                {
                    showCalibrationDropdown = false;
                }
            }

            //Create the Graphics settings buttons, these won't show automatically, they will be called when
            //the user clicks on the "Change Graphics Quality" Button, and then dissapear when they click
            //on it again....
            if (showCalibrationDropdown == true)
            {
                if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2, 250, 50), "Re-Calibrate"))
                {
                    GazeControlComponent.Instance.StartCalibration();
                }
                if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 + 50, 250, 50), "Re-Validate"))
                {
                    GazeControlComponent.Instance.StartValidation();
                }
                if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 + 100, 250, 50), "Back"))
                {
                    showCalibrationDropdown = false;
                }
            }

            //Restart Level
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 250, 50), "Restart"))
            {
                turretSysten.GetComponent<System_ViewInput>().pauseActive = false;
                turretSysten.GetComponent<System_KeyInput>().pauseActive = false;
                Application.LoadLevel("Level_0");
            }

            //Make quit game button
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 250, 50), "Quit Game"))
            {
                Application.Quit();
            }
        }
    }
}
