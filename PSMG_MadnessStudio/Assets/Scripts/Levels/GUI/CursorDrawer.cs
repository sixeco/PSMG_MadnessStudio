using UnityEngine;
using System.Collections;
using iViewX;

public class CursorDrawer : MonoBehaviour {

    Texture gazeTexture;
    Texture mouseTexture;

    Rect gazeRect;
    Rect mouseRect;

    bool GazeAndMouse;
    bool GazeAndAOI;
    bool MouseOnly;

    bool gazeActive = false;

    void Awake()
    {
        GazeAndMouse = GameObject.Find("Turret_System").GetComponent<System_Status>().GazeAndMouse;
        GazeAndAOI = GameObject.Find("Turret_System").GetComponent<System_Status>().GazeAndAIO;
        MouseOnly = GameObject.Find("Turret_System").GetComponent<System_Status>().MouseOnly;

        gazeTexture = GameObject.Find("Data").GetComponent<TextureData>().crosshairGaze;
        mouseTexture = GameObject.Find("Data").GetComponent<TextureData>().crosshairMouse;

        gazeRect = new Rect(0, 0, gazeTexture.width, gazeTexture.height);
        mouseRect = new Rect(0, 0, mouseTexture.width, mouseTexture.height);
    }

    void Start()
    {
        if (GazeAndAOI)
        {
            gazeActive = true;
        }
        else if (GazeAndMouse)
        {
            gazeActive = true;
        }
        else
        {
            gazeActive = false;
        }
    }

    void Update()
    {
        Debug.Log("Update from cursor drawer");
        if (gazeActive)
        {
            Vector2 GPos = (gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f;
            gazeRect.x = GPos.x - (gazeTexture.width/2);
            gazeRect.y = GPos.y - (gazeTexture.height / 2);
        }
        else
        {
            mouseRect.x = (Screen.width / 2) - (mouseTexture.width / 2);
            mouseRect.y = (Screen.height / 2) - (mouseTexture.height / 2);
            Screen.lockCursor = true;
            Debug.Log("update else works: " + mouseRect.x + ", " + mouseRect.y);
        }
    }

    void OnGUI()
    {
        if (gazeActive)
        {
            GUI.DrawTexture(gazeRect, gazeTexture);
        }
        else
        {
            GUI.DrawTexture(mouseRect, mouseTexture);
        }
    }
}
