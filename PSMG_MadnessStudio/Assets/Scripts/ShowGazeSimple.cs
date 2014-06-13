using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using iViewX;

public class ShowGazeSimple : MonoBehaviour
{

    private bool isGazeCursorActive = true;
    private int xPos_Elements;
    private int yPos_Element;

    public Texture2D gazeCursor;

    void OnGUI()
    {
        //Calculate the Position of the GUI Elements
        xPos_Elements = (int)(Screen.width * 0.45f);
        yPos_Element = (int)(Screen.height * 0.45f);

        #region drawGazeCursor

        //Draw GazeCursor only if it is activated
        if (isGazeCursorActive)
        {
            Vector3 posGaze = (gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f;
            GUI.DrawTexture(new Rect(posGaze.x, posGaze.y, gazeCursor.width, gazeCursor.height), gazeCursor);
        }
        #endregion
    }
}