using UnityEngine;
using System.Collections;

public class AIProjEngine : MonoBehaviour {

    private float speed;
    private GameObject lab;
    public GameObject Explosion;

    public float checkRadius = 10;
    public float explosionForce = 5;
    public float explosionRadius = 5;
    public float explosionAnchor = 1;

    public float Damage = 10f;

    public Vector3 detonationPoint;

    void OnTriggerEnter()
    {
        Detonate();
    }

    void Start()
    {
        speed = DamageDataStatic.AIProjSpeed;
        lab = ModelDataStatic.Lab;
        Explosion = ModelDataStatic.AIExplosion;
    }

    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, lab.transform.position, step);
    }

    void Detonate()
    {
        if (Explosion != null)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius);
        foreach (Collider c in colliders)
        {
            HP h = c.GetComponent<HP>();
            if (h != null)
            {
                h.AddDamage(Damage);
            }
        }
        Destroy(gameObject);
    }
}
