using UnityEngine;
using System.Collections;

public class AIOTestCircle : MonoBehaviour {

    Rect activeAreaCircle;
    Rect deadAreaCircle;
    public Texture texture;

    public float rotationSpeed = 10.0f;

    Vector3 rotation;

	void Start () {
        float activeHeight = Screen.height;
        float deadHeight = (Screen.height)/6;
	    activeAreaCircle = new Rect((Screen.width/2) - (activeHeight/2), (Screen.height/2) - (activeHeight/2), activeHeight, activeHeight);
        deadAreaCircle = new Rect((Screen.width / 2) - (deadHeight / 2), (Screen.height / 2) - (deadHeight / 2), deadHeight, deadHeight);

        rotation = new Vector3(0, 0, 0);
	}
	
	void Update () {
        //Vector2 gazeInput = gazeModel.posGazeLeft + gazeModel.posGazeRight;
        Vector2 mouseInput = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 activeMid = new Vector2(activeAreaCircle.x + ((activeAreaCircle.width)/2), activeAreaCircle.y + ((activeAreaCircle.height)/2));
        float distance = Vector2.Distance(activeMid, mouseInput);

        if (distance > (deadAreaCircle.width/2))
        {
            Vector3 direction = new Vector3(mouseInput.x - activeMid.x, mouseInput.y - activeMid.y, 0);
            Debug.Log(direction.normalized);
        }
        if (distance > (activeAreaCircle.width/2))
        {

        }
        gameObject.transform.localRotation = Quaternion.Euler(rotation);
	}

    void OnGUI()
    {
        GUI.DrawTexture(activeAreaCircle, texture);
        GUI.DrawTexture(deadAreaCircle, texture);
    }
}
