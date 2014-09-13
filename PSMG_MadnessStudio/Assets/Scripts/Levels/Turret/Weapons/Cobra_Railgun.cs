using UnityEngine;
using System.Collections;

public class Cobra_Railgun : MonoBehaviour {
    
    public Camera Camera;
    public Transform shotPos;

    private GameObject Strike;
    private GameObject Flash;
    private GameObject Projectile;

    private float RayCheckRange;
    private float CoolDown;
    private float CoolDownRemain;

    private AudioClip[] shotSounds;

    private int Damage;

    void Start()
    {
        GameObject data = GameObject.Find("Data");
        Strike = data.GetComponent<ModelData>().LaserSpark;
        Flash = data.GetComponent<ModelData>().CobraMuszzleFlash;
        Projectile = data.GetComponent<ModelData>().CobraProjectile;
        RayCheckRange = data.GetComponent<GUIData>().RayCheckRange;
        CoolDown = data.GetComponent<CoolDownValues>().LaserMain;
        shotSounds = data.GetComponent<AudioData>().CobraShotSounds;
        CoolDownRemain = 0;
        Damage = data.GetComponent<DamageData>().CobraRailDamage;
    }

    void Update()
    {
        CoolDownRemain -= Time.deltaTime;
    }

    public void Shoot(Vector2 direction)
    {
        if (CoolDownRemain <= 0)
        {
            CoolDownRemain = CoolDown;
            Ray ray = Camera.ScreenPointToRay(new Vector2(direction.x, Screen.height - direction.y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, RayCheckRange))
            {
                Collider[] colliders = Physics.OverlapSphere(hit.point, 10f);
                foreach (Collider c in colliders)
                {
                    AsteroidHP h = c.gameObject.GetComponent<AsteroidHP>();
                    if (h != null)
                    {
                        h.AddDamage(Damage);
                    }
                }
                AudioSource source = shotPos.GetComponent<AudioSource>();
                if (source != null)
                {
                    int index = Random.Range(0, shotSounds.Length - 1);
                    source.clip = shotSounds[index];
                    source.Play();
                }
                Quaternion rotation = Quaternion.LookRotation((hit.point - (shotPos.transform.position + shotPos.transform.forward)).normalized);
                Instantiate(Projectile, shotPos.position, rotation);
                Instantiate(Flash, shotPos.position, rotation);
                Instantiate(Strike, hit.point, Quaternion.identity);
            }
        }
    }
}
