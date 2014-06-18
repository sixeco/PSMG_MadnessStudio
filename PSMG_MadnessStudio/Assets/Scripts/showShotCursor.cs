using UnityEngine;
using System.Collections;

public class showShotCursor : MonoBehaviour {

    public static bool cursorOff = false;

    public bool isActive;
    public Texture crosshairTexture;
    private Rect textureRect;

    void Start()
    {
        textureRect = new Rect(Input.mousePosition.x, Input.mousePosition.y, crosshairTexture.width, crosshairTexture.height);
        isActive = this.GetComponent<TurretActivation>().isActive;
        //Screen.showCursor = cursorOff;
    }

	void Update () {
        isActive = this.GetComponent<TurretActivation>().isActive;
        if (isActive)
        {
            textureRect.x = Input.mousePosition.x;
            textureRect.y = Screen.height - Input.mousePosition.y;
            Screen.showCursor = cursorOff;
        }
	}

    void OnGUI()
    {
        isActive = this.GetComponent<TurretActivation>().isActive;
        if (isActive)
        {
            GUI.DrawTexture(textureRect, crosshairTexture);
        }
    }
}
