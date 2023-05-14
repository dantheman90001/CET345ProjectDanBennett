using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHouseKey : MonoBehaviour
{
    public GameObject doorColliderhere;
    public GameObject keyGone;
    public bool pickingUpKey;
    

     void Start()
    {
        
        
        
        
    }
    void OnTriggerStay(Collider collideobject)
    {
        if (collideobject.gameObject.name == "Player")
        {
            if (pickingUpKey)
            {
                Debug.Log("Interacting");
                doorColliderhere.GetComponent<BoxCollider>().enabled = true;
                keyGone.SetActive(false);
            }

            
        }       

        
        
    }

     void Update()
    {
        pickingUpKey = Input.GetButton("Interact");
    }
}
