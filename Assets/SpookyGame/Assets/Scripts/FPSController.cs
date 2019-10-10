using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    private float fSpeed;
    private bool bSprint;

    void Start()
    {
        fSpeed = 0.1f;
    }

    
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement() // Change this to messing with the rigidbody - adding forces rather than changing the transform
    {
        if (Input.GetKey(KeyCode.LeftShift))
            bSprint = true;
        else
            bSprint = false;
        if (Input.GetKey(KeyCode.W))
        {
            if(bSprint)
                gameObject.transform.Translate(0.0f, 0.0f, fSpeed * 2);
            else
                gameObject.transform.Translate(0.0f, 0.0f, fSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (bSprint)
                gameObject.transform.Translate(0.0f, 0.0f, -fSpeed * 2);
            else
                gameObject.transform.Translate(0.0f, 0.0f, -fSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (bSprint)
                gameObject.transform.Translate(-fSpeed * 2, 0.0f, 0.0f);
            else
                gameObject.transform.Translate(-fSpeed, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (bSprint)
                gameObject.transform.Translate(fSpeed * 2, 0.0f, 0.0f);
            else
                gameObject.transform.Translate(fSpeed, 0.0f, 0.0f);
        }
    }
}
