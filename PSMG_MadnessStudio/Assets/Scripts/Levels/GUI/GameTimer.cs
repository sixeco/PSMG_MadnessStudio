using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {

    public GUIText GuiText;

    private float seconds;

    void Start()
    {
        seconds = GameObject.Find("Data").GetComponent<GameData>().TrialTimeSecond;
    }

    void Update()
    {
        float temp = seconds - Time.time;
        if ((int)temp % 60 < 10)
        {
            GuiText.text = ((int)temp / 60) + " : 0" + ((int)temp % 60);
        }
        else
        {
            GuiText.text = ((int)temp / 60) + " : " + ((int)temp % 60);
        }
    }
}
