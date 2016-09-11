using UnityEngine;
using System.Collections;

public class DrawMouseCursor : MonoBehaviour {

    private Texture crosshairMouse;
    private Rect textureRect;
    private bool isAOIActive = false;

    void Start()
    {
        this.enabled = !GameObject.Find("Turret Manager").GetComponent<TurretStats>().isGazeInputActive;
        crosshairMouse = GameObject.Find("Data").GetComponent<TextureData>().crosshairMouse;
        isAOIActive = GameObject.Find("Turret Manager").GetComponent<TurretStats>().isAOIcontrolActive;
        textureRect = new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, crosshairMouse.width, crosshairMouse.height);
    }

    void Update()
    {
        if (isAOIActive)
        {
            textureRect.x = Input.mousePosition.x;
            textureRect.y = Screen.height - Input.mousePosition.y;
            Cursor.visible = false;
        }
        else
        {
            textureRect.x = (Screen.width / 2) - (crosshairMouse.width / 2);
            textureRect.y = (Screen.height / 2) - (crosshairMouse.height / 2);
            Screen.lockCursor = true;
        }
    }

    void OnGUI()
    {
        GUI.DrawTexture(textureRect, crosshairMouse);
    }
}
