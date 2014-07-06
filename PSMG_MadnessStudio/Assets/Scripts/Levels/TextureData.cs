using UnityEngine;
using System.Collections;

public class TextureData : MonoBehaviour {

    public Texture aoiFiller;
    public Texture crosshairMouse;
    public Texture crosshairGaze;

    void OnEnable()
    {
        TextureDataStatic.CrosshairMouse = crosshairMouse;
        TextureDataStatic.AOIFiller = aoiFiller;
    }
}
