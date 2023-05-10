using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SMGShoot : MonoBehaviour
{
   

    public float SMGDamage = 20f;
    public float range = 60f;

    public GameObject SMGStart;

   
    void Update()
    {
       if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("Shooting SMG");

        RaycastHit hit;
        if (Physics.Raycast(SMGStart.transform.position, SMGStart.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            SMGEnemyHealth sMGEnemyHealth = hit.transform.GetComponent<SMGEnemyHealth>(); 
            
            if (sMGEnemyHealth != null)
            {
                sMGEnemyHealth.TakeSMGEnemyDamage(SMGDamage);
            }
        }
    }

    
}
