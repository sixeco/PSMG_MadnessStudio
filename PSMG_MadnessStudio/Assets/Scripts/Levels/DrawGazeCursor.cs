using UnityEngine;
using System.Collections;
using iViewX;

public class DrawGazeCursor : MonoBehaviour {

    private Texture gazeCursor;
    private Rect gazeRect;

    void Start()
    {
        this.enabled = ActivationDataStatic.isGazeInputActive;
        gazeCursor = TextureDataStatic.CrosshairGaze;
        gazeRect = new Rect(0, 0, gazeCursor.width, gazeCursor.height);
    }

    void Update()
    {
        Vector2 GPos = (gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f;
        gazeRect.x = GPos.x;
        gazeRect.y = GPos.y;
        print(gazeRect.x);
        print(gazeRect.y);
    }

    void OnGUI()
    {
        GUI.DrawTexture(gazeRect, gazeCursor);
    }
}
