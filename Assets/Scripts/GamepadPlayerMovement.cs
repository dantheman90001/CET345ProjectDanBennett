using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;



public class GamepadPlayerMovement : MonoBehaviour
{
    PlayerMovement playermovement;

    Vector3 movement;
    

    public float speed = 5f;
   
    

    void Awake()
    {
        playermovement = new PlayerMovement();
        
        playermovement.Gameplay.Jump.performed += ctx => Jump();

        playermovement.Gameplay.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
        playermovement.Gameplay.Movement.canceled += ctx => movement = Vector3.zero;

       
       
    }

    void Jump()
    {
        //transform.Translate(Vector3.up * 5f);
    }

    void Update()
    {
        Vector3 m = new Vector3(movement.x, 0, movement.y) * speed * Time.deltaTime;
        transform.Translate(m, Space.World);

       
    }

    void OnEnable()
    {
        playermovement.Gameplay.Enable();
    }

    void OnDisable()
    {
        playermovement.Gameplay.Disable();
    }

}
