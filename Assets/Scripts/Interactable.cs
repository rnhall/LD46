using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public bool canBeInteracted;

    // Start is called before the first frame update
    void Start()
    {
        canBeInteracted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (canBeInteracted)
        {
            this.GetComponent<MeshRenderer>().material.shader = Shader.Find("Custom/Outline");
        } else
        {
            this.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
        }
    }
}
