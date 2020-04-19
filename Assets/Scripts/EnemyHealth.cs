using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Health = 25f;

    public void TakeDamage(float annt)
    {
        Health -= annt;
        if (Health <= 0)
        {
            print("Enemy has deid!!!");
        }

        print("Enemy took some damage");
    }
}
