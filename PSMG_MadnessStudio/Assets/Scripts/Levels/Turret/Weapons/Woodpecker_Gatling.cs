using UnityEngine;
using System.Collections;

public class Woodpecker_Gatling : MonoBehaviour {

    public Camera camera;
    public Transform shotPos;

    private float CoolDown;
    private float CoolDownRemain;
    private float RayCheckRange;

    private GameObject Hit;
    private GameObject Flash;
    private GameObject ProjectileEffect;

    private AudioClip[] shotSounds;
    private AudioSource source;

    private int Damage;

    void Start()
    {
        GameObject data = GameObject.Find("Data");
        CoolDown = data.GetComponent<CoolDownValues>().Gatling;
        RayCheckRange = data.GetComponent<GUIData>().RayCheckRange;
        Damage = data.GetComponent<DamageData>().WoodpeckerGatlingDamage;
        Flash = data.GetComponent<ModelData>().CannonMuzzleFlash;
        ProjectileEffect = data.GetComponent<ModelData>().WoopeckerProjectile;
        shotSounds = data.GetComponent<AudioData>().WoodpeckerShotSounds;
        source = shotPos.GetComponent<AudioSource>();
        CoolDownRemain = 0;
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
            Ray ray = camera.ScreenPointToRay(new Vector2(direction.x, Screen.height - direction.y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, RayCheckRange))
            {
                float rel = Vector3.Distance(hit.point, transform.position)/400;
                Vector3 hitRandom = new Vector3(hit.point.x + Random.Range(-10 * rel, 10 * rel), hit.point.y + Random.Range(-10 * rel, 10 * rel), hit.point.z + Random.Range(-10 * rel, 10 * rel));
                Collider[] colliders = Physics.OverlapSphere(hitRandom, 5f);
                foreach (Collider c in colliders)
                {
                    AsteroidHP h = c.gameObject.GetComponent<AsteroidHP>();
                    if (h != null)
                    {
                        h.AddDamage(Damage);
                    }
                }

                Instantiate(Flash, shotPos.position, Quaternion.identity);
                Quaternion rotation = Quaternion.LookRotation((hitRandom - (shotPos.transform.position + shotPos.transform.forward)).normalized);
                Instantiate(ProjectileEffect, shotPos.position, rotation);

                //Shoot sound
                int index = Random.Range(0, shotSounds.Length - 1);
                source.clip = shotSounds[index];
                source.Play();
            }
        }
    }
}
