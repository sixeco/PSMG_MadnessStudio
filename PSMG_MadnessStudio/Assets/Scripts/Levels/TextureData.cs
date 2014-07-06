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
        MouseViewControl.CrossHairTexture += GetCrosshairMouse;
        AOIControls4Panel.GetTexture += GetAOIFiller;
    }

    void OnDisable()
    {
        MouseViewControl.CrossHairTexture += GetCrosshairMouse;
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
