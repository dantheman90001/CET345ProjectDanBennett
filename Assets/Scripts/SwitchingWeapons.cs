using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwitchingWeapons : MonoBehaviour
{
    public bool IsLeft;
    public bool IsRight;
    public bool IsDown;

    public GameObject pistol;
    public GameObject smg;
    public GameObject shotgun;
    
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("DPad X");
        float y = Input.GetAxis("DPad Y");

        IsLeft = false;
        IsRight = false;
        IsDown = false;
        

        if ( x == -1)
        {
            Debug.Log("Pistol Equipped!");
            IsLeft = true;
            pistol.SetActive(true);
            smg.SetActive(false);
            shotgun.SetActive(false);

            // Pistol
        }
        else if (x == 1)
        {
            Debug.Log("SMG Equipped!");
            IsRight = true;
            smg.SetActive(true);
            pistol.SetActive(false);
            shotgun.SetActive(false);
            // smg
        }

        if (y == -1)
        {
            Debug.Log("Shotgun Equipped!");
            IsDown = true;
            shotgun.SetActive(true);
            pistol.SetActive(false);
            smg.SetActive(false);
            // Shotgun
        }

        if (Input.GetButton("Shotgun"))
        {
            IsDown = true;
            shotgun.SetActive(true);
            pistol.SetActive(false);
            smg.SetActive(false);
        }

        if (Input.GetButton("SMG"))
        {
            IsRight = true;
            smg.SetActive(true);
            shotgun.SetActive(false);
            pistol.SetActive(false);
        }

        if (Input.GetButton("Pistol"))
        {
            IsLeft = true;
            smg.SetActive(false);
            shotgun.SetActive(false);
            pistol.SetActive(true);
        }
    }
}
