using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {

    public GUIText GuiText;

    float secondsStart;
    public float remainingSeconds;
    bool active;

    void Start()
    {
        secondsStart = GameObject.Find("Data").GetComponent<GameData>().TrialTimeSecond;
        remainingSeconds = secondsStart;
        active = GameObject.Find("Data").GetComponent<GameData>().IsTimerActive;
        if (active)
        {
            GuiText.gameObject.SetActive(true);
        }
        else
        {
            GuiText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (active)
        {
            remainingSeconds = secondsStart - Time.time;
            if ((int)remainingSeconds % 60 < 10)
            {
                GuiText.text = ((int)remainingSeconds / 60) + " : 0" + ((int)remainingSeconds % 60);
            }
            else
            {
                GuiText.text = ((int)remainingSeconds / 60) + " : " + ((int)remainingSeconds % 60);
            }
        }
    }
}
