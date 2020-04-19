using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
    public GameObject playerCamera; //this is a reference to the main camera (drag & drop)
    public GameObject tempParent;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        Ray r = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        //if we hit something
        if (Physics.Raycast(r, out hitInfo))
        {
            print("We hit something");
            //if it is tagged as a weapon
            if (hitInfo.transform.CompareTag("Weapon"))
            {
                print("We hit a weapon");
                //if the user presses E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print("We hit a weapon and user pressed F, we should pick up the weapon");
                    GameObject weapon = hitInfo.transform.gameObject;
                    weapon.gameObject.transform.parent = tempParent.transform;
                    weapon.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                    weapon.gameObject.transform.localRotation = Quaternion.identity;
                    weapon.GetComponent<Rigidbody>().isKinematic = false; //"disabling" the rigidbody (it's still active but gravity won't apply to it.
                    weapon.GetComponent<Collider>().enabled = false; //disabling the collider.
                }

            }
        }
    }
}

