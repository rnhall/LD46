using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator handAnim;

    public Camera MainCamera;
    public GameObject Guide;
    public Weapon myWeapon;
    //Animation handAnim;

    // Start is called before the first frame update
    void Start()
    {
        //handAnim = Guide.GetComponent<Animator>();
        handAnim = GetComponent<Animator>();
        myWeapon = Guide.GetComponentInChildren<Weapon>();

    }

    // Update is called once per frame
    void Update()
    {
        handAnim.SetBool("Attacking", true);
       if (Input.GetMouseButtonDown(0))
        {
            handAnim.SetBool("Attacking", true);
            DoAttack();
        }
    }

    private void DoAttack()
    {
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, myWeapon.attackRange))
        {
            if(hit.collider.tag == "Food")
            {
                //EnemyHealth health = hit.collider.GetComponent<EnemyHealth>();
                //EnemyHealth.TakeDamage(myWeapon.attackDamage);
            }
        }
    }
}
