using UnityEngine;
using System.Collections;

public class TextureData : MonoBehaviour {

    public Texture aoiFiller;
    private Texture _aoiFiller
    {
        get{
            return aoiFiller;
        }
    }
    public Texture crosshairMouse;
    public Texture crosshairGaze;

    void OnEnable()
    {
        TextureDataStatic.CrosshairMouse = crosshairMouse;
        TextureDataStatic.AOIFiller = aoiFiller;
    }

    Texture GetCrosshairMouse()
    {
        return crosshairMouse;
    }

    Texture GetAOIFiller()
    {
        return aoiFiller;
    }
}
