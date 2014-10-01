using UnityEngine;
using System.Collections;
using iViewX;

public class MainMenuView : MonoBehaviour {

    public delegate void LoadingAction(int index);
    public static event LoadingAction LoadLevel;
    public GameObject title;

    public Font generalFont;

    private int selGridInt = 0;
    private string[] selStrings = new string[] { "Grid 1", "Grid 2", "Grid 3", "Grid 4" };

    private Rect ArcadeButton;
    private Rect TimeTrialButton;
    private Rect SettingsButton;

    void Awake()
    {
        SettingsButton = new Rect(Screen.width / 2 + ((Screen.width * 0.1f) * 0.5f), Screen.height / 5 * 3, Screen.width * 0.1f, Screen.height * 0.1f);
        ArcadeButton = new Rect(Screen.width / 2 - ((Screen.width * 0.1f) * 1.5f), Screen.height / 5 * 3, Screen.width * 0.1f, Screen.height * 0.1f);
        TimeTrialButton = new Rect(Screen.width / 2 - ((Screen.width * 0.1f) * 0.5f), Screen.height / 5 * 3, Screen.width * 0.1f, Screen.height * 0.1f);
    }

    void OnGUI()
    {
        GUI.skin.box.font = generalFont;
        GUI.skin.button.font = generalFont;

        if (GUI.Button(SettingsButton, "Settings"))
        {
            this.GetComponent<Settings>().settingsActive = !this.GetComponent<Settings>().settingsActive;
        }
        if (GUI.Button(ArcadeButton, "Arcade"))
        {
            gameObject.SetActive(false);
            GameObject.Find("Data").GetComponent<GameData>().IsTimerActive = false;
            LoadLevel(Random.Range(1, Application.levelCount - 1));
        }
        if (GUI.Button(TimeTrialButton, "Time Trial"))
        {
            gameObject.SetActive(false);
            GameObject.Find("Data").GetComponent<GameData>().IsTimerActive = true;
            LoadLevel(Random.Range(1, Application.levelCount - 1));
        }
    }
}
