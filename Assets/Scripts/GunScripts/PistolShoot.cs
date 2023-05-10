using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShoot : MonoBehaviour
{


    public float pistolDamage = 10f;
    public float range = 20f;
    public float fireRate = 2f;
    public float nextFire;
    public Transform pistolStart;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.5f);
    public LineRenderer laserLine;
    IEnumerator ShootDelay()
    {
        Debug.Log("Delaying Shot");
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }

     void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
                Shoot();
            StartCoroutine(ShootDelay());

        }
    }

    void Shoot()
    {
        Debug.Log("Pistol Shooting!");

        RaycastHit hit;
        laserLine.SetPosition(0, pistolStart.position);

        if (Physics.Raycast(pistolStart.transform.position, pistolStart.transform.forward, out hit, range))
        {
            laserLine.SetPosition(1, hit.point);
            Debug.DrawLine(pistolStart.transform.position, pistolStart.transform.forward, Color.black);
            Debug.Log(hit.transform.name);


            SMGEnemyHealth sMGEnemyHealth = hit.transform.GetComponent<SMGEnemyHealth>();

            if (sMGEnemyHealth != null)
            {
                sMGEnemyHealth.TakeSMGEnemyDamage(pistolDamage);
            }


        }
        else
        {
            laserLine.SetPosition(1, pistolStart.transform.position + (pistolStart.transform.forward * range));
        }
    }
}
