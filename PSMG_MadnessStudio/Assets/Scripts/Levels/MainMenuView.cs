using UnityEngine;
using System.Collections;
using iViewX;

public class MainMenuView : MonoBehaviour {

    public delegate void LoadingAction();
    public static event LoadingAction LoadLevel;

    public string LevelToLoad;
    public GameObject background;
    public GameObject LoadingText;
    public GameObject progressBar;

    private int LoadingProgress = 0;
	
	void Start () {
        background.SetActive(true);
        LoadingText.SetActive(false);
        progressBar.SetActive(false);
	}
	
	void Update () {
	
	}

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
        }
        #endregion
    }

    IEnumerator DisplayLoadingScreen(string level)
    {
        LoadingText.SetActive(true);
        progressBar.SetActive(true);

        progressBar.transform.localScale = new Vector3(LoadingProgress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);

        LoadingText.guiText.text = "Loading Progress " + LoadingProgress + "%";

        AsyncOperation async = Application.LoadLevelAsync(level);
        while (!async.isDone)
        {
            LoadingProgress = (int)(async.progress * 100);
            LoadingText.guiText.text = "Loading Progress " + LoadingProgress + "%";
            progressBar.transform.localScale = new Vector3(async.progress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);

            yield return null;
        }
    }
}
