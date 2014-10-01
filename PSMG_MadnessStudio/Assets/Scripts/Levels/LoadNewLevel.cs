using UnityEngine;
using System.Collections;

public class LoadNewLevel : MonoBehaviour {

    public string LevelToLoad;
    public GameObject LoadingText;
    public GameObject ProgressBar;

    private int loadProgress = 0;

    void OnEnable()
    {
        MainMenuView.LoadLevel += LoadLevel;
    }

    void OnDisable()
    {
        MainMenuView.LoadLevel -= LoadLevel;
    }

    void LoadLevel(int index)
    {
        StartCoroutine(DisplayLoadingScreen(index));
    }

    void Awake()
    {
        LoadingText.SetActive(false);
        ProgressBar.SetActive(false);
    }

    IEnumerator DisplayLoadingScreen(int index)
    {
        LoadingText.SetActive(true);
        ProgressBar.SetActive(true);

        ProgressBar.transform.localScale = new Vector3(loadProgress, ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);

        LoadingText.guiText.text = "Loading Progress " + loadProgress + "%";

        AsyncOperation async = Application.LoadLevelAsync(index);
        while (!async.isDone)
        {
            loadProgress = (int)(async.progress * 100);
            LoadingText.guiText.text = "Loading Progress " + loadProgress + "%";
            ProgressBar.transform.localScale = new Vector3(async.progress, ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);

            yield return null;
        }
    }

    void OnGUI()
    {
        LoadingText.guiText.fontSize = Mathf.Min(Screen.width, Screen.height) / 20;
    }
}
