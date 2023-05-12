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
            // Pistol
        }
        else if (x == 1)
        {
            Debug.Log("SMG Equipped!");
            IsRight = true;
            // smg
        }

        if (y == -1)
        {
            Debug.Log("Shotgun Equipped!");
            IsDown = true;
            // Shotgun
        }
    }
}
