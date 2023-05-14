using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSentryKey : MonoBehaviour
{
    public GameObject sentryDoorColliderhere;
    public GameObject sentryKeyGone;
    public bool pickingUpKey;

    // Update is called once per frame

     void OnTriggerStay(Collider collideObject)
    {
        if (collideObject.gameObject.name == "Player")
        {
            if (pickingUpKey)
            {
                Debug.Log("Interacted");
                sentryDoorColliderhere.GetComponent<BoxCollider>().enabled = true;
                sentryKeyGone.SetActive(false);
            }
        }
    }
    void Update()
    {
        pickingUpKey = Input.GetButton("Interact");
    }


}
