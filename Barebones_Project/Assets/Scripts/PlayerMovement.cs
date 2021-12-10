using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private float speed;
    public float startingSpeed = 3f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpHeight = 0f; 
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded; 
    
    void Start()
    {
        speed = startingSpeed; 
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 2;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = startingSpeed;
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            controller.height *= .50f; 
        }

        if (Input.GetKeyUp(KeyCode.C)) {
            controller.height /= .50f;

        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); 
        if (isGrounded && velocity. y < 0)
        {
            velocity.y = -2f; 
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); 
    }
}