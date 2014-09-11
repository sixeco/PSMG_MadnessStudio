using UnityEngine;
using System.Collections;
using iViewX;

public class AimPointer : MonoBehaviour {

    public GameObject PointLight;
    
    private float LerpSpeed; 
    private Camera cam;
    private System_Status status;
    private float RayCheckRange;
    private Vector3 PointerScale;

    void Start()
    {
        cam = this.GetComponent<Camera>();
        status = GameObject.Find("Turret_System").GetComponent<System_Status>();
        LerpSpeed = GameObject.Find("Data").GetComponent<GUIData>().PointerFlowSpeed;
        RayCheckRange = GameObject.Find("Data").GetComponent<GUIData>().RayCheckRange;
        PointerScale = PointLight.transform.localScale;
    }

    void Update()
    {
        if (status.SelectedCursorType == System_Status.AimCursorType.LaserPointer)
        {
            PointLight.GetComponent<MeshRenderer>().enabled = true;
            Screen.lockCursor = true;

            //Shoot out ray based on input type
            Ray ray = new Ray();
            if (status.SelectedControls == System_Status.ControlType.GazeAndAOI || status.SelectedControls == System_Status.ControlType.GazeAndMouse)
            {
                Vector2 gaze = (gazeModel.posGazeLeft + gazeModel.posGazeRight) * 0.5f;
                ray = cam.ScreenPointToRay(new Vector2(gaze.x, Screen.height - gaze.y));
            }
            else
            {
                ray = cam.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            }

            //Lerp Pointer to hit-position
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, RayCheckRange))
            {
                PointLight.transform.localScale = PointerScale * ((Vector3.Distance(this.transform.position, hitInfo.point)) / 130f);
                PointLight.transform.position = Vector3.Lerp(PointLight.transform.position, hitInfo.point, LerpSpeed);
            }
        }
        else
        {
            PointLight.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
