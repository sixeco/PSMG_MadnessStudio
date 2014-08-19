using UnityEngine;

[RequireComponent(typeof(SandStormButton))]
[RequireComponent(typeof(GUITexture))]
public class ButtonDownTextureChange : MonoBehaviour {

    private SandStormButton m_Button;
    private new GUITexture guiTexture;
    public Texture idleTexture;
    public Texture activeTexture;

    private bool down;

    void OnEnable() {
        m_Button = GetComponent<SandStormButton> ();
        guiTexture = GetComponent<GUITexture> ();
    }


    void Update () {
        
        if (CrossPlatformInput.GetButtonDown (m_Button.buttonName) && !down) {
            guiTexture.texture = activeTexture;
            down = true;
        }
        if (CrossPlatformInput.GetButtonUp("NextCamera") && down)
        {
            guiTexture.texture = idleTexture;
            down = false;
        }


    }



	
}
