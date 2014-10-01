using UnityEngine;
using System.Collections;

public class TortoiseForcefield : MonoBehaviour {

    public Texture AnimatedTexture;
    public enum ShapeOptions { SphereShape = 0, PlaneShape = 1 };
    public ShapeOptions ShapeOption = ShapeOptions.SphereShape;

    public Color StartColor;
    public Color EndColor;

    public float FPS;
    public int xFrames;
    public int YFrames;
    public bool DestroyOnComplete = true;

    public enum PhysOptions { ReflectProjectile = 0, AbsorbProjectile = 1 };
    public PhysOptions PhysOption = PhysOptions.AbsorbProjectile;

    public GameObject GenericEffect_Sphere;
    public GameObject GenericEffect_Plane;

    void OnCollisionEnter(Collision c)
    {
        try
        {
            if (
                c.gameObject.tag.Equals("Projectile")
                && c.gameObject.GetComponent<OwnerScript>().Owner != gameObject.transform.parent.gameObject)
            {
                ShowEffect(c.gameObject, ShapeOption);

                if (PhysOption == PhysOptions.ReflectProjectile)
                {
                    // do nothing
                    Debug.Log("Collision happened with reflective intention");
                }
                else
                {
                    Debug.Log("Destroying Projectile");
                    Destroy(c.gameObject);
                }
            }
        }
        catch (MissingComponentException m)
        {
            Debug.Log(m);
        }
    }

    public void ShowEffect(GameObject Target, ShapeOptions input_ShapeOptions)
    {
        if (input_ShapeOptions == ShapeOptions.SphereShape)
        {
            //Vector3 dir = Target.transform.position - transform.position;
            //Quaternion rotation = Quaternion.LookRotation(dir);

            //GameObject ThisEffect = Instantiate(GenericEffect_Sphere, gameObject.transform.position, rotation) as GameObject;
        }
        else
        {

        }
    }

    public void ShowEffect(Vector3 Target, ShapeOptions input_ShapeOptions)
    {

    } 
}
