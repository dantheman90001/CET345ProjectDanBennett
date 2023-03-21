using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovementPC : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] private Vector3 jumpVelocity;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private int speed = 5;

    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravity = -0.01f;
    [SerializeField] private bool Grounded;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

   

    // Update is called once per frame
    void Update()
    {
        Grounded = controller.isGrounded;

        if (Grounded && jumpVelocity.y < 0)
        {
            jumpVelocity.y = 0f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontal, 0, vertical);

        if(moveDirection == Vector3.zero)
        {
            animator.SetFloat("Speed", 0);
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("Speed", 0.5f);
        }
        else
        {
            animator.SetFloat("Speed", 1);
        }

        moveDirection *= speed;

        if ((moveDirection.x != 0) || (moveDirection.z !=0))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime);
        }

        controller.Move(moveDirection * Time.deltaTime);

        if (Grounded && Input.GetKeyDown(KeyCode.Space))
        {
            jumpVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
        jumpVelocity.y += gravity * Time.deltaTime;
        controller.Move(jumpVelocity * Time.deltaTime);
    }
}
