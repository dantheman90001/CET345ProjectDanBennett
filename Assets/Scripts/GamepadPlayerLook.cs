using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.Scripting.APIUpdating;


public class GamepadPlayerLook : MonoBehaviour
{
    PlayerMovement playerMovement;
    Vector3 look;

    public float rotateSpeed = 10f;
     void Awake()
    {
        playerMovement = new PlayerMovement();

        playerMovement.Gameplay.Look.performed += ctx => look = ctx.ReadValue<Vector2>();
        playerMovement.Gameplay.Look.performed += ctx => look = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 r = new Vector3(-look.y, 0, -look.x) * rotateSpeed * Time.deltaTime;
        transform.Rotate(r, Space.World);
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
