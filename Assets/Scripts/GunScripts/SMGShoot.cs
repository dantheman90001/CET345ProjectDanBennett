using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.Scripting.APIUpdating;


public class SMGShoot : MonoBehaviour
{
    PlayerMovement playerMovement;

    public float SMGDamage = 20f;
    public float range = 60f;

    public GameObject SMGStart;

    void Awake()
    {
        playerMovement = new PlayerMovement();

        playerMovement.Gameplay.Shoot.performed += ctx => Shoot();
    }
    // Update is called once per frame
    void Update()
    {
       
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

    void OnEnable()
    {
        playerMovement.Gameplay.Enable();
    }

    void OnDisable()
    {
        playerMovement.Gameplay.Disable();
    }
}
