using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShotgunShoot : MonoBehaviour
{
    public float shotgunDamage = 60f;
    public float range = 20f;
    public float fireRate = 3f;
    public float nextFire;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.5f);
    public Transform shotgunStart;
    public LineRenderer laserLine;
    public bool isFiring;
    public int shotgunAmmo;
    public int maxAmmo = 99;
    public TMP_Text shotgunAmmoUI;
    public AudioSource shootingSound;

    IEnumerator shotgunShotDelay()
    {
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }

     void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        shootingSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        shotgunAmmoUI.text = shotgunAmmo.ToString();
        if (Input.GetButton("Fire1") && Time.time > nextFire && !isFiring && shotgunAmmo > 0)
        {
            nextFire = Time.time + fireRate;
            isFiring = true;
            shootingSound.Play();
            Shoot();
            shotgunAmmo--;
            isFiring = false;
            StartCoroutine(shotgunShotDelay());
        }
    }

    public void IncreaseAmmo(int increaseAmount)
    {
        shotgunAmmo += increaseAmount;
        if (shotgunAmmo > maxAmmo)
        {
            shotgunAmmo = maxAmmo;
        }
    }

    void Shoot()
    {
        

        RaycastHit hit;
        laserLine.SetPosition(0, shotgunStart.position);
        if (Physics.Raycast(shotgunStart.transform.position, shotgunStart.transform.forward, out hit, range))
        {
            laserLine.SetPosition(1, hit.point);
            Debug.Log(hit.transform.name);
            SMGEnemyHealth sMGEnemyHealth = hit.transform.GetComponent<SMGEnemyHealth>();

            if (sMGEnemyHealth != null)
            {
                sMGEnemyHealth.TakeSMGEnemyDamage(shotgunDamage);
            }

            SentryHealth sentryHealth = hit.transform.GetComponent<SentryHealth>();
            if (sentryHealth != null)
            {
                sentryHealth.TakeSentryDamage(shotgunDamage);
            }
        }
        else
        {
            laserLine.SetPosition(1, shotgunStart.transform.position + (shotgunStart.transform.forward * range));
        }
    }
}
