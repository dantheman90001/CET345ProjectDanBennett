using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;



public class GamepadPlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    PlayerMovement playermovement;
    [SerializeField] private Vector3 jumpVelocity;
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravity = -0.01f;
    [SerializeField] private bool Grounded;
    [SerializeField] private Vector3 moveDirection;

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
        

        moveDirection *= speed;

        Vector3 m = new Vector3(movement.x, 0, movement.y) * speed * Time.deltaTime;
        controller.Move(jumpVelocity * Time.deltaTime);

       
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
