using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

    public string LevelToLoad;

    public GameObject OnLoadBackground;
    public GameObject OnLoadText;
    public GameObject ProgressBar;

    private int loadProgress = 0;

	void Start () {
        OnLoadBackground.SetActive(false);
        OnLoadText.SetActive(false);
        ProgressBar.SetActive(false);
	}
	
	void Update () {
	    
	}

    IEnumerator DisplayLoadingScreen(string level)
    {
        OnLoadBackground.SetActive(true);
        OnLoadText.SetActive(true);
        ProgressBar.SetActive(true);

        ProgressBar.transform.localScale = new Vector3(loadProgress, ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);

        OnLoadText.guiText.text = "Loading Progress " + loadProgress + "%";

        AsyncOperation async = Application.LoadLevelAsync(level);
        while (!async.isDone)
        {
            loadProgress = (int)(async.progress * 100);
            OnLoadText.guiText.text = "Loading Progress " + loadProgress + "%";
            ProgressBar.transform.localScale = new Vector3(async.progress, ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);

            yield return null;
        }
    }
}
