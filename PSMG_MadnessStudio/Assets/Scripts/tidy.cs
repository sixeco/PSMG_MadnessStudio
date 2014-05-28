using UnityEngine;
using System.Collections;

public class tidy : MonoBehaviour
{
    public float offSet = 5f;

    void Start()
    {
        Destroy(gameObject, offSet);
    }
}
