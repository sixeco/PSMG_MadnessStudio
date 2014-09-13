using UnityEngine;
using System.Collections;

public class GameEnding : MonoBehaviour {

    GameObject gui;
    GameObject shield;

    void Start()
    {
        gui = GameObject.Find("GUI");
        shield = GameObject.Find("Tortoise");
    }

    void Update()
    {
        if (gui.GetComponent<GameTimer>().remainingSeconds <= 0 || shield.GetComponent<TortoiseLife>().HP <= 0)
        {
            this.GetComponent<PauseGame>().gameOver = true;
        }
    }
}
