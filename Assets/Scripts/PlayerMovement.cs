using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;

    private void Start()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
    // isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    //This function triggers every time this game object's collider hits another collider. 
    private void OnCollisionEnter(Collision collision)
    {
        //This checks if the collision is a member of layer 9 ("Ground")
        if (collision.gameObject.layer == 9)
        {
            //If touching, set isGrounded to true
            isGrounded = true;
        }
    }

    //Same as the statement above, just opposite. 
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            isGrounded = false;
        }
    }
}
