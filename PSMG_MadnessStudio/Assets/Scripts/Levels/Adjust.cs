using UnityEngine;
using System.Collections;

public class Adjust : MonoBehaviour {

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 100, 100, 30), "Health Up"))
        {
            GameControl.control.health += 10;
        }
        if (GUI.Button(new Rect(10, 100, 100, 30), "Health Down")) 
        {
            GameControl.control.health -= 10;
        }
        if (GUI.Button(new Rect(10, 100, 100, 30), "Exp Up")) 
        {
            GameControl.control.exp += 10;
        }
        if (GUI.Button(new Rect(10, 100, 100, 30), "Exp Down")) 
        {
            GameControl.control.exp -= 10;
        }
    }
}
