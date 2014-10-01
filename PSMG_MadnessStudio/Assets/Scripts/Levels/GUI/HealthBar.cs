using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public GameObject Shield;
    public GUITexture Bar;
    public GUITexture BarOutline;
    public GUIText HealthText;

    private float healthScale;
    private float originalScaleBar;
    private float originalScaleOutline;

    void Awake()
    {
        Bar.enabled = true;
        BarOutline.enabled = true;
        HealthText.enabled = true;
        healthScale = Shield.GetComponent<TortoiseLife>().HP / 100;
        originalScaleBar = Bar.transform.localScale.x;
    }

    void Update()
    {
        if (Shield.GetComponent<TortoiseLife>().HP > 0)
        {
            healthScale = Shield.GetComponent<TortoiseLife>().HP / 100;
            Bar.transform.localScale = new Vector3(originalScaleBar * healthScale, Bar.transform.localScale.y, Bar.transform.localScale.z);
            if (originalScaleBar * healthScale < 0.15f)
            {
                HealthText.enabled = false;
            }
        }else{
            Bar.enabled = false;
        }
    }
}
