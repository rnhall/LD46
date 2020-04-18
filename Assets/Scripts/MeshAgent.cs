using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;


public class MeshAgent : MonoBehaviour
{

    public Camera camera;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        SetKinematic(true);
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance && agent.enabled)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else if (agent.enabled)
        {
            character.Move(Vector3.zero, false, false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            agent.enabled = false;
            animator.enabled = false;
            SetKinematic(false);
            //animator.enabled = false;
        }
    }

    void SetKinematic(bool newValue)
    {
        //Get an array of components that are of type Rigidbody
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();

        //For each of the components in the array, treat the component as a Rigidbody and set its isKinematic property
        foreach (Rigidbody rb in bodies)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = newValue;
        }
    }
}
