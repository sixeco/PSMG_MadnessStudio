using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

    public string levelToLoad;

    public GameObject background;
    public GameObject text;
    public GameObject progressBar;

    private int loadProgress = 0;

	void Start () {
        background.SetActive(true);
        text.SetActive(false);
        progressBar.SetActive(false);
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.L))
        {
            //Application.LoadLevel(levelToLoad);
            StartCoroutine(DisplayLoadingScreen(levelToLoad));
        }
	}

    IEnumerator DisplayLoadingScreen(string level)
    {
        background.SetActive(true);
        text.SetActive(true);
        progressBar.SetActive(true);

        progressBar.transform.localScale = new Vector3(loadProgress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);

        text.GetComponent<GUIText>().text = "Loading Progress " + loadProgress + "%";

        AsyncOperation async = Application.LoadLevelAsync(level);
        while (!async.isDone)
        {
            loadProgress = (int)(async.progress * 100);
            text.GetComponent<GUIText>().text = "Loading Progress " + loadProgress + "%";
            progressBar.transform.localScale = new Vector3(async.progress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);

            yield return null;
        }
        
    }
}
