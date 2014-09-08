using UnityEngine;
using System.Collections;

public class Rabbit_TwinCannon : MonoBehaviour {

    public Transform UpperShotPos;
    public Transform LowerShotPos;
    public Camera Camera;
    public GUIText guiText;

    public int Ammo;
    private int MagSize = 100;

    private float CoolDown;
    private float coolDownRemain;
    private float shotForce;

    private Rigidbody projectile;
    private GameObject flash;

    private bool turn;
    private float RayCheckRange = 300.0f;

    void Awake()
    {
        GameObject data = GameObject.Find("Data");
        projectile = data.GetComponent<ModelData>().CannonProjectile;
        flash = data.GetComponent<ModelData>().CannonMuzzleFlash;
        CoolDown = data.GetComponent<CoolDownValues>().Cannon;
        shotForce = data.GetComponent<DamageData>().RabbitCannonForce;
    }

    void Start()
    {
        turn = true;
        coolDownRemain = 0;
        Ammo = MagSize;
        guiText.text = Ammo + "/" + MagSize;
        RayCheckRange = GameObject.Find("Data").GetComponent<GUIData>().RayCheckRange;
    }

    void Update()
    {
        coolDownRemain -= Time.deltaTime;
        guiText.text = Ammo + "/" + MagSize;
    }

    public void Shoot(Vector2 direction)
    {
        if (coolDownRemain <= 0 && Ammo > 0)
        { 
            Ray ray = Camera.ScreenPointToRay(new Vector3(direction.x, Screen.height - direction.y, 0));
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, RayCheckRange))
            {
                if (turn)
                {
                    Instantiate(flash, UpperShotPos.position, Quaternion.identity);
                    Rigidbody upperShot = Instantiate(projectile, UpperShotPos.position, UpperShotPos.rotation) as Rigidbody;
                    Vector3 UpperShotVector = hitInfo.point - upperShot.transform.position;
                    upperShot.AddForce(UpperShotVector * shotForce, ForceMode.Acceleration);
                    turn = !turn;
                    Ammo--;
                }
                else
                {
                    Instantiate(flash, LowerShotPos.position, Quaternion.identity);
                    Rigidbody lowerShot = Instantiate(projectile, LowerShotPos.position, LowerShotPos.rotation) as Rigidbody;
                    Vector3 LowerShotVector = hitInfo.point - lowerShot.transform.position;
                    lowerShot.AddForce(LowerShotVector * shotForce, ForceMode.Acceleration);
                    turn = !turn;
                    Ammo--;
                }

                coolDownRemain = CoolDown;
            }
        }
        else if(Ammo <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(5f);
        Ammo = MagSize;
    }
}
