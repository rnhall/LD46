using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    public Camera camera;

    public float grabRange = 2f;
    public bool canInteract;
    public GameObject interactable;
    public Transform grabPoint;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
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

        Interact();

        if (canInteract && Input.GetMouseButton(0))
        {
            interactable.transform.position = grabPoint.position;
        }

    }

    public void Interact()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            float distance = Vector3.Distance(camera.transform.position, hit.transform.position);
            if (hit.collider.gameObject.layer == 10 && distance < grabRange)
            {
                interactable = hit.collider.gameObject;
                interactable.GetComponent<Interactable>().canBeInteracted = true;
                canInteract = true;
            } else if (hit.collider.gameObject != interactable)
            {
                interactable.GetComponent<Interactable>().canBeInteracted = false ;
                interactable = hit.collider.gameObject;
                interactable.GetComponent<Interactable>().canBeInteracted = true;
                canInteract = true;
            }
        } else
        {
            interactable.GetComponent<Interactable>().canBeInteracted = false;
            interactable = null;
            canInteract = false;
        }
    }
}
