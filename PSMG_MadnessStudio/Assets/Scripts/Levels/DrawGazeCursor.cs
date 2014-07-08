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
        gazeRect.x = GPos.x - (gazeCursor.width/2);
        gazeRect.y = GPos.y - (gazeCursor.height/2);
    }

    void OnGUI()
    {
        GUI.DrawTexture(gazeRect, gazeCursor);
    }
}
