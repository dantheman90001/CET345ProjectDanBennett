using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class SMGShoot : MonoBehaviour
{
   

    public float SMGDamage = 20f;
    public float range = 60f;
    public float fireRate = 0.4f;
    public float nextFire;
    public Transform SMGStart;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.5f);
    public LineRenderer laserline;
    public bool isFiring;
    public int smgAmmo;
    public TMP_Text smgAmmoUI;
   

    IEnumerator shotDelay()
    {
        laserline.enabled = true;
        yield return shotDuration;
        laserline.enabled = false;
    }

     void Start()
    {
        laserline = GetComponent<LineRenderer>();
    }
    void Update()
    {
        smgAmmoUI.text = smgAmmo.ToString();
       if (Input.GetButton("Fire1") && Time.time > nextFire && !isFiring && smgAmmo > 0)
        {
            nextFire = Time.time + fireRate;
            isFiring = true;
            Shoot();
            smgAmmo--;
            isFiring = false;
            StartCoroutine(shotDelay());
        }
    }

    void Shoot()
    {
        

        RaycastHit hit;
        laserline.SetPosition(0, SMGStart.position);
        if (Physics.Raycast(SMGStart.transform.position, SMGStart.transform.forward, out hit, range))
        {
            laserline.SetPosition(1, hit.point);

            Debug.DrawLine(SMGStart.transform.position, SMGStart.transform.forward, Color.black);
            Debug.Log(hit.transform.name);
            SMGEnemyHealth sMGEnemyHealth = hit.transform.GetComponent<SMGEnemyHealth>(); 
            
            if (sMGEnemyHealth != null)
            {
                sMGEnemyHealth.TakeSMGEnemyDamage(SMGDamage);
            }

            SentryHealth sentryHealth = hit.transform.GetComponent<SentryHealth>();
            if (sentryHealth != null)
            {
                sentryHealth.TakeSentryDamage(SMGDamage);
            }
        }
        else
        {
            laserline.SetPosition(1, SMGStart.transform.position + (SMGStart.transform.forward * range));
        }
    }

    
}
