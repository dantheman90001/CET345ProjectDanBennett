using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class GamepadPlayerMovement : MonoBehaviour
{
    

    private CharacterController controller;

    private float speed = 5f;


    private Vector2 playerMovementInput;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    
   

    public void Jump(InputAction.CallbackContext context)
    {
       
    }

    void Update()
    {
        MovePlayer();
   
    }

    


    void MovePlayer()
    {
        Vector3 movement = new Vector3(playerMovementInput.x, 0.0f, playerMovementInput.y);

        controller.SimpleMove(movement * speed);
    }

    void OnMove(InputValue iv)
    {
        playerMovementInput = iv.Get<Vector2>();
    }

    
}
