using UnityEngine;
using System.Collections;
using iViewX;

public class AIOTestCircle : MonoBehaviour {

    Rect areaCircle;
    public Texture fill;

    Vector3 rotation;

	void Start () {
        areaCircle = new Rect((Screen.width/2) - ((Screen.width/5)/2), ((Screen.height/2) - ((Screen.width/5)/2)), Screen.width/5, Screen.width/5);
        rotation = new Vector3(0, 0, 0);
	}
	
	void Update () {
        Vector2 mouseInput = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 circlePositionMid = new Vector2(areaCircle.x + (areaCircle.width / 2), areaCircle.y + (areaCircle.height / 2));
        Vector2 direction = new Vector2(mouseInput.x - circlePositionMid.x, mouseInput.y - circlePositionMid.y);
        Debug.Log(mouseInput);
        if (areaCircle.Contains(mouseInput) && ((Mathf.Sqrt((direction.x * direction.x) + (direction.y * direction.y))) < (areaCircle.width/2)))
        {
            rotation.y += 10.0f * Time.deltaTime;
        }
        gameObject.transform.localRotation = Quaternion.Euler(rotation);
	}

    void OnGUI()
    {
        GUI.DrawTexture(areaCircle, fill);
    }
}
