using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistolAmmoPickup : MonoBehaviour
{
    [SerializeField] private int pistolAmmo;
    public bool pickUpAmmo;
    public GameObject Pistol;
    
    

    void Start()
    {
        
    }

    private void OnTriggerStay(Collider collideObject)
    {
        if(collideObject.gameObject.name == "Player")
        {
            if(pickUpAmmo)
            {
                Debug.Log("Increased Pistol Ammo!");
                PistolShoot pistolShoot = Pistol.GetComponent<PistolShoot>();
                pistolShoot.IncreaseAmmo(pistolAmmo);
                Destroy(gameObject);
            }
        }
    }

     void Update()
    {
        pickUpAmmo = Input.GetButton("Interact");
    }
}
