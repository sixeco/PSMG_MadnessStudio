using UnityEngine;
using System.Collections;

public class DrawMouseCursor : MonoBehaviour {

    private Texture crosshairMouse;
    private Rect textureRect;
    private bool isAOIActive = false;

    void Start()
    {
        this.enabled = !ActivationDataStatic.isGazeInputActive;
        crosshairMouse = TextureDataStatic.CrosshairMouse;
        isAOIActive = ActivationDataStatic.isAOIcontrolActive;
        textureRect = new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, crosshairMouse.width, crosshairMouse.height);
    }

    void Update()
    {
        if (isAOIActive)
        {
            textureRect.x = Input.mousePosition.x;
            textureRect.y = Screen.height - Input.mousePosition.y;
            Screen.showCursor = false;
        }
        else
        {
            textureRect.x = (Screen.width/2) - (crosshairMouse.width/2);
            textureRect.y = (Screen.height/2) - (crosshairMouse.height/2);
            Screen.lockCursor = true;
        }
        
    }

    void OnGUI()
    {
        GUI.DrawTexture(textureRect, crosshairMouse);
    }
}
