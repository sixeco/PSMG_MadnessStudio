using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {

    public GUIText GuiText;

    float secondsStart;
    public float remainingSeconds;

    void Start()
    {
        secondsStart = GameObject.Find("Data").GetComponent<GameData>().TrialTimeSecond;
        remainingSeconds = secondsStart;
    }

    void Update()
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
