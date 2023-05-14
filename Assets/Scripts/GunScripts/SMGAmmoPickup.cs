using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SMGAmmoPickup : MonoBehaviour
{

    [SerializeField] private int smgAmmo = 30;
    public bool pickupAmmo;
    public GameObject SMG;


    private void OnTriggerStay(Collider colldieObject)
    {
        if(colldieObject.gameObject.name == "Player")
        {
            if (pickupAmmo)
            {
                Debug.Log("SMG Ammo Increased");
                SMGShoot sMGShoot = SMG.GetComponent<SMGShoot>();
                sMGShoot.IncreaseAmmo(smgAmmo);
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        pickupAmmo = Input.GetButton("Interact");
    }
}
