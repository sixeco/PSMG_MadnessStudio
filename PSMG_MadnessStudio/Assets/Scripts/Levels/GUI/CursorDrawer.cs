using UnityEngine;
using System.Collections;
using iViewX;

public class CursorDrawer : MonoBehaviour {

    Texture gazeTexture;
    Texture mouseTexture;

    Rect gazeRect;
    Rect mouseRect;

    System_Status status;
    float LerpSpeed;

    void Awake()
    {
        gazeTexture = GameObject.Find("Data").GetComponent<TextureData>().crosshairGaze;
        mouseTexture = GameObject.Find("Data").GetComponent<TextureData>().crosshairMouse;

        gazeRect = new Rect(0, 0, gazeTexture.width, gazeTexture.height);
        mouseRect = new Rect(0, 0, mouseTexture.width, mouseTexture.height);
    }

    void Start()
    {
        status = GameObject.Find("Turret_System").GetComponent<System_Status>();
        LerpSpeed = GameObject.Find("Data").GetComponent<GUIData>().PointerFlowSpeed;
    }

    void Update()
    {
        if (status.SelectedControls == System_Status.ControlType.GazeAndAOI || status.SelectedControls == System_Status.ControlType.GazeAndMouse)
        {
            Vector2 GPos = (gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f;
            //gazeRect.x = GPos.x - (gazeTexture.width/2);
            //gazeRect.y = GPos.y - (gazeTexture.height / 2);
            gazeRect.position = Vector2.Lerp(gazeRect.position, new Vector2((GPos.x - (gazeTexture.width / 2)), (GPos.y - (gazeTexture.height / 2))), LerpSpeed);
        }
        else
        {
            mouseRect.x = (Screen.width / 2) - (mouseTexture.width / 2);
            mouseRect.y = (Screen.height / 2) - (mouseTexture.height / 2);
            Screen.lockCursor = true;
        }
    }

    void OnGUI()
    {
        if (status.SelectedCursorType == System_Status.AimCursorType.GUI)
        {
            if (status.SelectedControls == System_Status.ControlType.GazeAndAOI || status.SelectedControls == System_Status.ControlType.GazeAndMouse)
            {
                GUI.DrawTexture(gazeRect, gazeTexture);
            }
            else
            {
                GUI.DrawTexture(mouseRect, mouseTexture);
            }
        }
    }
}
