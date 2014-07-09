using UnityEngine;
using System.Collections;
using iViewX;

public class AOIControls4Panel : MonoBehaviour {

    Rect scaleArea;
    Rect areaLeft;
    Rect areaRight;
    Rect areaTop;
    Rect areaBottom;
    private Texture Filler;

    private Vector2 mainInput;
    private bool areAOIsVisible;

    private float aoiScaleFactor;
    private float maxScale;

    private bool isGazeInputActive;

    private float rotationSpeed;

    Vector3 rotation;

	void Start () {
        this.enabled = ActivationDataStatic.isAOIcontrolActive;
        areAOIsVisible = ActivationDataStatic.isAOIvisible;

        isGazeInputActive = ActivationDataStatic.isGazeInputActive;

        Filler = TextureDataStatic.AOIFiller;
        aoiScaleFactor = GUIDataStatic.AOIScaleFactor;
        
        maxScale = (Screen.height / 4) * 2;
        float scaleHeight = (Screen.height / 4) + (maxScale * aoiScaleFactor);
        float scaleWidth = scaleHeight * ((Screen.width * 1.05f) / Screen.height);
        scaleArea = new Rect(((Screen.width/2) - (scaleWidth/2)), ((Screen.height/2) - (scaleHeight/2)), scaleWidth, scaleHeight);

        areaLeft = new Rect(0, 0, ((Screen.width - scaleArea.width) / 2), Screen.height);
        areaRight = new Rect((Screen.width - ((Screen.width - scaleArea.width) / 2)), 0, ((Screen.width - scaleArea.width) / 2), Screen.height);

        areaTop = new Rect(0, 0, Screen.width, ((Screen.height - scaleArea.height) / 2));
        areaBottom = new Rect(0, (Screen.height - ((Screen.height - scaleArea.height) / 2)), Screen.width, ((Screen.height - scaleArea.height) / 2));

        rotationSpeed = GUIDataStatic.GazeSensitivity;

        rotation = new Vector3(0, 0, 0);
    }
	
	void Update () {
        if (isGazeInputActive)
        {
            mainInput = (gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f;
            mainInput.y = Screen.height - mainInput.y;
        }
        else
        {
            mainInput = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (areaLeft.Contains(mainInput))
        {
            float speedRate = ((areaLeft.width - mainInput.x) / areaLeft.width);
            rotation.y -= rotationSpeed * speedRate * Time.deltaTime;
        }
        if (areaRight.Contains(mainInput))
        {
            float speedRate = ((areaRight.width - (Screen.width - mainInput.x)) / areaRight.width);
            rotation.y += rotationSpeed * speedRate * Time.deltaTime;
        }
        if (areaTop.Contains(mainInput))
        {
            float speedRate = (areaTop.height - mainInput.y) / areaTop.height;
            rotation.x += rotationSpeed * speedRate * Time.deltaTime;
            if (rotation.x < -70.0f)
            {
                rotation.x = -70.0f;
            }
        }
        if (areaBottom.Contains(mainInput))
        {
            float speedRate = (areaBottom.height - (Screen.height - mainInput.y)) / areaBottom.height;
            rotation.x -= rotationSpeed * speedRate * Time.deltaTime;
            if (rotation.x > 60.0f)
            {
                rotation.x = 60.0f;
            }
        }
        gameObject.transform.localRotation = Quaternion.Euler(rotation);
	}

    void OnGUI()
    {
        if (areAOIsVisible)
        {
            //GUI.DrawTexture(scaleArea, Filler);
            GUI.DrawTexture(areaLeft, Filler);
            GUI.DrawTexture(areaRight, Filler);
            GUI.DrawTexture(areaTop, Filler);
            GUI.DrawTexture(areaBottom, Filler);
        }
    }
}
