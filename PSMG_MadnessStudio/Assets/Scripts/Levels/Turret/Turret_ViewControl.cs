using UnityEngine;
using System.Collections;
using iViewX;

public class Turret_ViewControl : MonoBehaviour {

    Rect scaleArea;
    Rect areaLeft;
    Rect areaRight;
    Rect areaTop;
    Rect areaBottom;

    private bool areAOIsVisible;
    private Texture Filler;

    private float aoiScaleFactor;
    private float maxScale;

    private float gazeRotationSpeed;

    public float mouseSensitivity;
    public float upDownRange;
    public float leftRightRange;
    float verticalRotation = 0.0f;
    float horizontalRotation = 0.0f;

    GUIData gData;
    Vector3 rotation;

    void Awake()
    {
        gData = GameObject.Find("Data").GetComponent<GUIData>();
        aoiScaleFactor = gData.AoiScaleFactor;
        gazeRotationSpeed = gData.GazeSensitivity;
        maxScale = Screen.height / 2;
        mouseSensitivity = gData.MouseSensitivity;
        upDownRange = gData.TopBottomRange;
        leftRightRange = gData.LeftRightRange;
        Filler = GameObject.Find("Data").GetComponent<TextureData>().aoiFiller;
        areAOIsVisible = GameObject.Find("Turret_System").GetComponent<System_Status>().AOIVisible;
    }

    void Start()
    {        
        float scaleHeight = (Screen.height / 4) + (maxScale * aoiScaleFactor);
        float scaleWidth = scaleHeight * ((Screen.width * 1.05f) / Screen.height);
        scaleArea = new Rect(((Screen.width / 2) - (scaleWidth / 2)), ((Screen.height / 2) - (scaleHeight / 2)), scaleWidth, scaleHeight);

        areaLeft = new Rect(0, 0, ((Screen.width - scaleArea.width) / 2), Screen.height);
        areaRight = new Rect((Screen.width - ((Screen.width - scaleArea.width) / 2)), 0, ((Screen.width - scaleArea.width) / 2), Screen.height);

        areaTop = new Rect(0, 0, Screen.width, ((Screen.height - scaleArea.height) / 2));
        areaBottom = new Rect(0, (Screen.height - ((Screen.height - scaleArea.height) / 2)), Screen.width, ((Screen.height - scaleArea.height) / 2));

        rotation = new Vector3(0, 0, 0);
    }

    public void TurnCameraMouse(float xAxis, float yAxis)
    {
        horizontalRotation += xAxis * mouseSensitivity;
        horizontalRotation = Mathf.Clamp(horizontalRotation, -leftRightRange, leftRightRange);

        verticalRotation -= yAxis * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);

        gameObject.transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
    }

    public void TurnCameraGaze(Vector2 gazeVector)
    {
        gazeVector.y = Screen.height - gazeVector.y;
        if (areaLeft.Contains(gazeVector))
        {
            float speedRate = ((areaLeft.width - gazeVector.x) / areaLeft.width);
            rotation.y -= gazeRotationSpeed * speedRate * Time.deltaTime;
            if (rotation.y < -leftRightRange)
            {
                rotation.y = -leftRightRange;
            }
        }
        if (areaRight.Contains(gazeVector))
        {
            float speedRate = ((areaRight.width - (Screen.width - gazeVector.x)) / areaRight.width);
            rotation.y += gazeRotationSpeed * speedRate * Time.deltaTime;
            if (rotation.y > leftRightRange)
            {
                rotation.y = leftRightRange;
            }
        }
        if (areaTop.Contains(gazeVector))
        {
            float speedRate = (areaTop.height - gazeVector.y) / areaTop.height;
            rotation.x += gazeRotationSpeed * speedRate * Time.deltaTime;
            if (rotation.x > upDownRange)
            {
                rotation.x = upDownRange;
            }
        }
        if (areaBottom.Contains(gazeVector))
        {
            float speedRate = (areaBottom.height - (Screen.height - gazeVector.y)) / areaBottom.height;
            rotation.x -= gazeRotationSpeed * speedRate * Time.deltaTime;
            if (rotation.x < -upDownRange)
            {
                rotation.x = -upDownRange;
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
