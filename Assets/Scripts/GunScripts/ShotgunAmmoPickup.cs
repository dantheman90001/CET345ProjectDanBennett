using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunAmmoPickup : MonoBehaviour
{
    [SerializeField] private int shotgunAmmo;
    public bool pickupAmmo;
    public GameObject Shotgun;


    private void OnTriggerStay(Collider collideObject)
    {
        if (collideObject.gameObject.name == "Player")
        {
            if(pickupAmmo)
            {
                Debug.Log("Increased Shotgun Ammo!");
                ShotgunShoot shotgunShoot = Shotgun.GetComponent<ShotgunShoot>();
                shotgunShoot.IncreaseAmmo(shotgunAmmo);
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
