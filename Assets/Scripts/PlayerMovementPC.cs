using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementPC : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private int speed = 5;

    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravity = 20f;
    [SerializeField] private bool Grounded;
    [SerializeField] private bool canJump;
    [SerializeField] private bool doubleJump;
    

    [SerializeField] private Transform PlayerCamera;
    public float mouseSensitivity = 200f;
    public float lookUpClamp = -30f;
    public float lookDownClamp = 60;
    float rotateX, rotateY;

    public float sprintCooldown = 3;
    public float sprintCooldownTimer = 0;
    public float nextSprint;

    public int maxStamina = 100;
    public float currentStamina;
    public TMP_Text staminaUI;

    //private WaitForSeconds regenStaminaTick = new WaitForSeconds(0.1f);
    //private Coroutine regenStamina;
    public StaminaBar staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Grounded = controller.isGrounded;
        if (sprintCooldownTimer > 0)
        {
            sprintCooldownTimer -= Time.deltaTime;
        }
        else if(sprintCooldownTimer <= 0 && currentStamina < maxStamina)
        {
            currentStamina += 30 * Time.deltaTime;
            if (currentStamina >= maxStamina)
            {
                currentStamina = maxStamina;
            }
            staminaBar.SetStamina(currentStamina);
        }


        if (Grounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            doubleJump = true;
            canJump = true;

            if (Input.GetButton("Fire3") && currentStamina > 0)
            {
                sprintCooldownTimer = sprintCooldown;
                Debug.Log("Sprinting");
                moveDirection *= 1.05f;
                DecreaseStamina(30);
            }
            else if (currentStamina < maxStamina)
            { 
                
            }
           
            if (canJump == true)
            {
                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpHeight;
                    canJump = false;
                }

                if (Input.GetButton("Jump") && doubleJump == true)
                {
                    moveDirection.y = jumpHeight * 2;
                    doubleJump = false;
                }
            }
            
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);


        rotateX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotateY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotateY = Mathf.Clamp(rotateY, lookUpClamp, lookDownClamp);
        transform.Rotate(0f, rotateX, 0f);

        PlayerCamera.localRotation = Quaternion.Euler(rotateY, 0f, 0f);

        maxStamina = Mathf.Clamp(maxStamina, 1, 100);
        if (currentStamina > maxStamina)
        {
            currentStamina = 100;
        }
    }

    public void DecreaseStamina(float decrease)
    {
        currentStamina -= decrease * Time.deltaTime;
        staminaBar.SetStamina(currentStamina);

        //regenStamina = StartCoroutine(RegenStamina());

        if (currentStamina != 0)
        {
            Debug.Log("Regen Stamina!");
            //StopCoroutine(regenStamina);
            moveDirection *= speed;
        }

        if (currentStamina <= 0)
        {

        }
    }

    //private IEnumerator RegenStamina()
    //{
    //    yield return new WaitForSeconds(3);

    //    while(currentStamina < maxStamina)
    //    {
    //        currentStamina += maxStamina / 100;
    //        staminaBar.SetStamina(currentStamina);
    //        yield return regenStaminaTick;
    //    }
    //    regenStamina = null;
    //}
}
