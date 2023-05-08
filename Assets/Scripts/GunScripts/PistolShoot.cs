using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.Scripting.APIUpdating;

public class PistolShoot : MonoBehaviour
{

    PlayerMovement playerMovement;
    public float pistolDamage = 10f;
    public float range = 20f;
    public float fireRate = 1f;
    public bool canFire;
    public GameObject pistolStart;
     void Awake()
    {
        playerMovement = new PlayerMovement();

        playerMovement.Gameplay.Shoot.performed += ctx => Shoot();
    }

    void Shoot()
    {
        Debug.Log("Pistol Shooting!");

        RaycastHit hit;
        if(Physics.Raycast(pistolStart.transform.position, pistolStart.transform.forward, out hit, range)&&canFire == true)
        {
            Debug.Log(hit.transform.name);
            canFire = false;
            StartCoroutine(ShootDelay());
            SMGEnemyHealth sMGEnemyHealth = hit.transform.GetComponent<SMGEnemyHealth>();
            
            if (sMGEnemyHealth != null)
            {
                sMGEnemyHealth.TakeSMGEnemyDamage(pistolDamage);
            }

           
        }
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        playerMovement.Gameplay.Enable();
    }

    void OnDisable()
    {
        playerMovement.Gameplay.Disable();
    }
}
