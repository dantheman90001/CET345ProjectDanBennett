using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSentryDoor : MonoBehaviour
{
    public Animation sentryHere;
    public bool door;
    // Start is called before the first frame update
    void Start()
    {
        sentryHere.Stop();
    }

    private void OnTriggerStay(Collider collideObject)
    {
        if(collideObject.gameObject.name == "Player")
        {
            if (door)
            {
                Debug.Log("Opening Sentry Door!");
                sentryHere.Play();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        door = Input.GetButton("Interact");
    }
}
