using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Monster")
        {
            Debug.Log("Item contacted");
            Destroy(gameObject);
        }
    }
}
