using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SniperScript : MonoBehaviour
{
    public float damage = 10f;
    public float fireRate = .0001f;
    public float range = 400f;

    public int maxAmmo = 4;
    private int currentAmmo;
    private bool isReloading = false;

    public float reloadTime = 3f;

    public Text ammoDisplay;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject impactBlood;
    public AudioSource source;
    public AudioClip clip;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
    }

    void Update()
    {
        ammoDisplay.text = currentAmmo.ToString();

        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 10f / fireRate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
        Debug.Log("Weapon is reloaded");
    }

    void Shoot()
    {
        muzzleFlash.Play();
        source.PlayOneShot(clip);

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            TargetObject targetObject = hit.transform.GetComponent<TargetObject>();
            Target target = hit.transform.GetComponent<Target>();
            boss boss = hit.transform.GetComponent<boss>();
            if (target != null)
            {
                target.TakeDamage(damage);
                GameObject impactGO = Instantiate(impactBlood, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
            else if (targetObject != null)
            {
                targetObject.TakeDamage(damage);
            }
            else if (boss != null)
            {
                boss.TakeDamage(damage);
            }
            else
            {
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
        }
    }
}
