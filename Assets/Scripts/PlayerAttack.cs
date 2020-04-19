using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera MainCamera;
    public Weapon myWeapon;

    // Start is called before the first frame update
    void Start()
    {
        myWeapon = GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attack!");
            myWeapon.GetComponent<Animation>().Play();
            DoAttack();
        }
    }

    private void DoAttack()
    {
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, myWeapon.attackRange))
        {
            if (hit.collider.tag == "Food")
            {
                GameObject hitObj = hit.transform.gameObject;
                hitObj.GetComponent<CustomerAI>().MakeRagdoll();
            }
        }
    }
}