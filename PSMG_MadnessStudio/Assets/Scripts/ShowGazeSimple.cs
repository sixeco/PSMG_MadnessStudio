using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using iViewX;

public class ShowGazeSimple : MonoBehaviour
{

    public Texture2D gazeCursor;

    void OnGUI()
    {

        #region drawGazeCursor

        //Draw GazeCursor only if it is activated
        Vector3 posGaze = (gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f;
        GUI.DrawTexture(new Rect(posGaze.x, posGaze.y, gazeCursor.width, gazeCursor.height), gazeCursor);
        #endregion
    }
}