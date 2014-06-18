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

    bool isGazeInputActive;
    private Vector2 mainInput;

    public bool isActive;

    public float scaleFactor;
    float maxRange;

    public bool visible;

    public float rotationSpeed = 20.0f;
    public float upDownRange = 70.0f;
    public float leftRightRange = 70.0f;
    Vector3 rotation;

	// Use this for initialization
	void Start () {
        isActive = this.GetComponent<TurretActivation>().isActive;
        visible = this.GetComponent<TurretActivation>().AOIVisibility;
        isGazeInputActive = this.GetComponent<TurretActivation>().isGazeInputActive;


        Vector2 gazeInput = gazeModel.posGazeLeft + gazeModel.posGazeRight;
        Vector2 mouseInput = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        if (isGazeInputActive)
        {
            mainInput = gazeInput;
        }
        else
        {
            mainInput = mouseInput;
        }

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
        isActive = this.GetComponent<TurretActivation>().isActive;
        visible = this.GetComponent<TurretActivation>().AOIVisibility;
        Vector2 gazeInput = gazeModel.posGazeLeft + gazeModel.posGazeRight;
        Vector2 mouseInput = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        if (isGazeInputActive)
        {
            mainInput = gazeInput;
        }
        else
        {
            mainInput = mouseInput;
        }

        if (isActive)
        {
            if (areaLeft.Contains(mainInput))
            {
                float speedRateLeft = ((areaLeft.width - mainInput.x) / areaLeft.width);
                rotation.y -= rotationSpeed * speedRateLeft * Time.deltaTime;
            }
            if (areaRight.Contains(mainInput))
            {
                float speedRateRight = ((areaRight.width - (Screen.width - mainInput.x)) / areaRight.width);
                rotation.y += rotationSpeed * speedRateRight * Time.deltaTime;
            }
            if (areaTop.Contains(mainInput))
            {
                float speedRateTop = (areaTop.height - mainInput.y) / areaTop.height;
                rotation.x += rotationSpeed * speedRateTop * Time.deltaTime;
                rotation.x = Mathf.Clamp(rotation.x, -upDownRange, upDownRange);
            }
            if (areaBottom.Contains(mainInput))
            {
                float speedRateBottom = (areaBottom.height - (Screen.height - mainInput.y)) / areaBottom.height;
                rotation.x -= rotationSpeed * speedRateBottom * Time.deltaTime;
            }
            gameObject.transform.localRotation = Quaternion.Euler(rotation);
        }
	}

    void OnGUI()
    {
        if (isActive && visible)
        {
            //GUI.DrawTexture(scaleArea, border);
            GUI.DrawTexture(areaLeft, border);
            GUI.DrawTexture(areaRight, border);
            GUI.DrawTexture(areaTop, border);
            GUI.DrawTexture(areaBottom, border);
        }
    }
}
