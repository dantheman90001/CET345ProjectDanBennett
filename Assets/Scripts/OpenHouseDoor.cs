using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenHouseDoor : MonoBehaviour
{
    public Animation hingeHere;
    public bool door;

    

    void Start()
    {
        hingeHere.Stop();
        
    }

    void OnTriggerStay(Collider collideObject)
    {
        if (collideObject.gameObject.name == "Player")
        {
            if (door)
            {
                Debug.Log("Opening Door");
                hingeHere.Play();
            }

            
        }
        

    }

     void Update()
    {
        door = Input.GetButton("Interact");
    }
}
