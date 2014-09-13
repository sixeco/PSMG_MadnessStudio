using UnityEngine;
using System.Collections;

public class Rabbit_TwinCannon : MonoBehaviour {

    public Transform UpperShotPos;
    public Transform LowerShotPos;
    public Camera Camera;
    public GUIText guiText;

    private float CoolDown;
    private float coolDownRemain;
    private float shotForce;

    private Rigidbody projectile;
    private GameObject flash;

    private AudioClip[] shotSounds;
    private AudioSource uppperSource;
    private AudioSource lowerSource;

    private bool turn;
    private float RayCheckRange;

    void Awake()
    {
        GameObject data = GameObject.Find("Data");
        projectile = data.GetComponent<ModelData>().CannonProjectile;
        flash = data.GetComponent<ModelData>().CannonMuzzleFlash;
        CoolDown = data.GetComponent<CoolDownValues>().Cannon;
        shotForce = data.GetComponent<DamageData>().RabbitCannonForce;
        shotSounds = data.GetComponent<AudioData>().RabbitShotSounds;
        uppperSource = UpperShotPos.GetComponent<AudioSource>();
        lowerSource = LowerShotPos.GetComponent<AudioSource>();
    }

    void Start()
    {
        turn = true;
        coolDownRemain = 0;
        RayCheckRange = GameObject.Find("Data").GetComponent<GUIData>().RayCheckRange;
    }

    void Update()
    {
        coolDownRemain -= Time.deltaTime;
    }

    public void Shoot(Vector2 direction)
    {
        if (coolDownRemain <= 0)
        { 
            Ray ray = Camera.ScreenPointToRay(new Vector3(direction.x, Screen.height - direction.y, 0));
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, RayCheckRange))
            {
                if (turn)
                {
                    Quaternion rotation = Quaternion.LookRotation((hitInfo.point - (LowerShotPos.transform.position + LowerShotPos.transform.forward)).normalized);
                    Instantiate(flash, UpperShotPos.position, Camera.transform.localRotation);
                    Instantiate(projectile, UpperShotPos.position, UpperShotPos.rotation);
                    //Rigidbody upperShot = Instantiate(projectile, UpperShotPos.position, UpperShotPos.rotation) as Rigidbody;
                    //Vector3 UpperShotVector = hitInfo.point - upperShot.transform.position;
                    //upperShot.AddForce(UpperShotVector * shotForce, ForceMode.Acceleration);
                    turn = !turn;

                    int index = Random.Range(0, shotSounds.Length - 1);
                    uppperSource.clip = shotSounds[index];
                    uppperSource.Play();
                }
                else
                {
                    Quaternion rotation = Quaternion.LookRotation((hitInfo.point - (LowerShotPos.transform.position + LowerShotPos.transform.forward)).normalized);
                    Instantiate(flash, LowerShotPos.position, Camera.transform.localRotation);
                    Instantiate(projectile, LowerShotPos.position, LowerShotPos.rotation);
                    //Rigidbody lowerShot = Instantiate(projectile, LowerShotPos.position, LowerShotPos.rotation) as Rigidbody;
                    //Vector3 LowerShotVector = hitInfo.point - lowerShot.transform.position;
                    //lowerShot.AddForce(LowerShotVector * shotForce, ForceMode.Acceleration);
                    turn = !turn;

                    int index = Random.Range(0, shotSounds.Length - 1);
                    lowerSource.clip = shotSounds[index];
                    lowerSource.Play();
                }

                coolDownRemain = CoolDown;
            }
        }
    }
}
