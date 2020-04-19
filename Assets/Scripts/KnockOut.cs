using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockOut : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Weapon")
        {
            Debug.Log("Weapon contact!");
            animator.enabled = false;
            //SetKinematic(false);
            Destroy(gameObject);
        }
    }
}
