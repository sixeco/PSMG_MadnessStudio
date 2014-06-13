using UnityEngine;
using System.Collections;
using iViewX;

public class AOITestRects : MonoBehaviour {

    Rect scaleArea;
    Rect areaLeft;
    Rect areaRight;
    Rect areaTop;
    Rect areaBottom; 
    public Texture border;

    public float scaleFactor;
    float maxRange;

    public float rotationSpeed = 10.0f;
    Vector3 rotation;

	// Use this for initialization
	void Start () {
        maxRange = (Screen.height / 4) * 2;
        float scaleHeight = (Screen.height/4) + (maxRange * scaleFactor);
        float scaleWidth = scaleHeight * ((Screen.width* 1.05f) / Screen.height);
        scaleArea = new Rect(((Screen.width/2) - (scaleWidth/2)), ((Screen.height/2) - (scaleHeight/2)), scaleWidth, scaleHeight);

        areaLeft = new Rect(0, 0, ((Screen.width - scaleArea.width)/2), Screen.height);
        areaRight = new Rect((Screen.width - ((Screen.width - scaleArea.width)/2)), 0, ((Screen.width - scaleArea.width)/2), Screen.height);

        areaTop = new Rect(0, 0, Screen.width, ((Screen.height - scaleArea.height)/2));
        areaBottom = new Rect(0, (Screen.height - ((Screen.height - scaleArea.height) / 2)), Screen.width, ((Screen.height - scaleArea.height) / 2));

        rotation = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 gazeInput = gazeModel.posGazeLeft + gazeModel.posGazeRight;
        Vector2 mouseInput = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        if (areaLeft.Contains(mouseInput))
        {
            float speedRateLeft = ((areaLeft.width - mouseInput.x)/areaLeft.width);
            rotation.y -= rotationSpeed * speedRateLeft * Time.deltaTime;
        }
        if (areaRight.Contains(mouseInput))
        {
            float speedRateRight = ((areaRight.width - (Screen.width - mouseInput.x))/areaRight.width);
            rotation.y += rotationSpeed * speedRateRight * Time.deltaTime;
        }
        if (areaTop.Contains(mouseInput))
        {
            float speedRateTop = (areaTop.height - mouseInput.y) / areaTop.height;
            rotation.x += rotationSpeed * speedRateTop * Time.deltaTime;
        }
        if (areaBottom.Contains(mouseInput))
        {
            float speedRateBottom = (areaBottom.height - (Screen.height - mouseInput.y)) / areaBottom.height;
            rotation.x -= rotationSpeed * speedRateBottom * Time.deltaTime;
        }
        gameObject.transform.localRotation = Quaternion.Euler(rotation);
	}

    void OnGUI()
    {
        //GUI.DrawTexture(scaleArea, border);
        GUI.DrawTexture(areaLeft, border);
        GUI.DrawTexture(areaRight, border);
        GUI.DrawTexture(areaTop, border);
        GUI.DrawTexture(areaBottom, border);
    }
}
