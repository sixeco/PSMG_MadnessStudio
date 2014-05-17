using UnityEngine;
using System.Collections;

public class CyllinderBuilder : MonoBehaviour {

    public GameObject block;

	void Start() {
        int columns = 20;
        int rows = 10;
        float radius = -6;

        for(int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++ )
            {
                GameObject temp = (GameObject)Instantiate(block, new Vector3(0f, j, radius), Quaternion.identity);

                temp.transform.parent = transform;
            }
            transform.Rotate(0f, 360 / columns, 0f);
        }
	}
}
