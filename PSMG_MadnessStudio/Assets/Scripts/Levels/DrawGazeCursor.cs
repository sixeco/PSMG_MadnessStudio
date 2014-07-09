using UnityEngine;
using System.Collections;
using iViewX;

public class DrawGazeCursor : MonoBehaviour {

    private Texture gazeCursor;
    private Rect gazeRect;
    private Vector2 GPos;

    void OnEnable()
    {
        TwinCannon.MainInput += GetGazeInput;
        RocketLauncher.MainInput += GetGazeInput;
    }

    void OnDisable()
    {
        TwinCannon.MainInput -= GetGazeInput;
        RocketLauncher.MainInput -= GetGazeInput;
    }

    void Start()
    {
        this.enabled = ActivationDataStatic.isGazeInputActive;
        gazeCursor = TextureDataStatic.CrosshairGaze;
        GPos = Vector2.zero;
        gazeRect = new Rect(0, 0, gazeCursor.width, gazeCursor.height);
    }

    void Update()
    {
        GPos = (gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f;
        gazeRect.x = GPos.x - (gazeCursor.width/2);
        gazeRect.y = GPos.y - (gazeCursor.height/2);
    }

    void OnGUI()
    {
        GUI.DrawTexture(gazeRect, gazeCursor);
    }

    Vector3 GetGazeInput()
    {
        return new Vector3(GPos.x, GPos.y, 0);
    }
}
