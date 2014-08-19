using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public GameObject Lab;
    public GameObject Bar;
    public GameObject BarOutline;
    public GameObject HealthText;

    private float healthScale;
    private float originalScaleBar;
    private float originalScaleOutline;


    void Awake()
    {
        Bar.SetActive(true);
        BarOutline.SetActive(true);
        HealthText.SetActive(true);
        healthScale = Lab.GetComponent<HP>().HitPoints/100;
        originalScaleBar = Bar.transform.localScale.x;
        originalScaleOutline = BarOutline.transform.localScale.x;
    }

    void Update()
    {
        healthScale = Lab.GetComponent<HP>().HitPoints/100;
        Bar.transform.localScale = new Vector3(originalScaleBar * healthScale, Bar.transform.localScale.y, Bar.transform.localScale.z);
        BarOutline.transform.localScale = new Vector3(originalScaleOutline * healthScale, BarOutline.transform.localScale.y, BarOutline.transform.localScale.z);
        if (originalScaleBar * healthScale < 0.15f)
        {
            HealthText.SetActive(false);
        }
    }
}
