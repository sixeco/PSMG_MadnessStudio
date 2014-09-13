using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

    public GUIText ScoreText;
    public GUIText MultiplierText;

    public static int Score;
    public static int Multiplier;

    void Start()
    {
        Score = 0;
        Multiplier = 1;
    }

    void Update()
    {
        string temp = Score.ToString();
        switch (temp.Length)
        {
            case 8:
                ScoreText.text = temp;
                break;
            case 7:
                ScoreText.text = "0" + temp;
                break;
            case 6:
                ScoreText.text = "00" + temp;
                break;
            case 5:
                ScoreText.text = "000" + temp;
                break;
            case 4:
                ScoreText.text = "0000" + temp;
                break;
            case 3:
                ScoreText.text = "00000" + temp;
                break;
            case 2:
                ScoreText.text = "000000" + temp;
                break;
            case 1:
                ScoreText.text = "0000000" + temp;
                break;
            default:
                break;
        }

        MultiplierText.text = "x" + Multiplier;
    }
}
