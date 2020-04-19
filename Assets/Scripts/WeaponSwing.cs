using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script by cheesecake: http://www.code4all.nl/dokuwiki/unity_how_to_swing_a_sword

public class WeaponSwing : MonoBehaviour
{

    private float swingDuration = 0.5f;
    private float swingSpeed = 0.22f;

    private float swingTimer = 0f;
    private bool swinging = false;
    private Vector3 startRot;

    void Start()
    {
        startRot = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !swinging)
        {
            swinging = true;
        }

        if (swinging)
        {
            swingTimer += Time.deltaTime;

            if (swingTimer < (swingDuration / 2))
            {
                transform.eulerAngles = Vector3.Lerp(startRot, new Vector3(0, 0, 1), swingSpeed);
            }

            if (swingTimer > (swingDuration / 2))
            {
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, startRot, swingSpeed);
            }

            if (swingTimer > swingDuration)
            {
                swingTimer = 0f;
                swinging = false;
            }
        }
    }
}

