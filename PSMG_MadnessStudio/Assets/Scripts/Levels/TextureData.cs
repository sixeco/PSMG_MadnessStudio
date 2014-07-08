using UnityEngine;
using System.Collections;

public class TextureData : MonoBehaviour {

    public Texture aoiFiller;
    public Texture crosshairMouse;
    public Texture crosshairGaze;

    void Awake()
    {
        TextureDataStatic.CrosshairMouse = crosshairMouse;
        TextureDataStatic.CrosshairGaze = crosshairGaze;
        TextureDataStatic.AOIFiller = aoiFiller;
    }
}
