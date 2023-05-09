using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovementPC : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private int speed = 5;

    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravity = 20f;
    [SerializeField] private bool Grounded;

    [SerializeField] private Transform PlayerCamera;
    public float mouseSensitivity = 2f;
    public float lookUpClamp = -30f;
    public float lookDownClamp = 60;
    float rotateX, rotateY;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Grounded = controller.isGrounded;

        if (Grounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpHeight;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);


        rotateX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotateY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotateY = Mathf.Clamp(rotateY, lookUpClamp, lookDownClamp);
        transform.Rotate(0f, rotateX, 0f);

        PlayerCamera.localRotation = Quaternion.Euler(rotateY, 0f, 0f);
    }
}
