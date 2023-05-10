using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShoot : MonoBehaviour
{
    public float shotgunDamage = 60f;
    public float range = 20f;
    public float fireRate = 3f;
    public float nextFire;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.5f);
    public GameObject shotgunStart;

    IEnumerator shotgunShotDelay()
    {
        Debug.Log("Delaying Shot");
        yield return shotDuration;
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
            StartCoroutine(shotgunShotDelay());
        }
    }

    void Shoot()
    {
        Debug.Log("Shotgun Blast");

        RaycastHit hit;
        if (Physics.Raycast(shotgunStart.transform.position, shotgunStart.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            SMGEnemyHealth sMGEnemyHealth = hit.transform.GetComponent<SMGEnemyHealth>();

            if (sMGEnemyHealth != null)
            {
                sMGEnemyHealth.TakeSMGEnemyDamage(shotgunDamage);
            }
        }
    }
}
