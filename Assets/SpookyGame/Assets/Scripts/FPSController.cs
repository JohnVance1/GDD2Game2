using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    private float fSpeed;

    void Start()
    {
        fSpeed = 0.1f;
    }

    
    void Update()
    {
        PlayerMovement();
        StayUp();
    }

    void PlayerMovement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            if(Input.GetKey(KeyCode.LeftShift))
                gameObject.transform.Translate(0.0f, 0.0f, fSpeed * 2);
            else
                gameObject.transform.Translate(0.0f, 0.0f, fSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                gameObject.transform.Translate(0.0f, 0.0f, -fSpeed * 2);
            else
                gameObject.transform.Translate(0.0f, 0.0f, -fSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                gameObject.transform.Translate(-fSpeed * 2, 0.0f, 0.0f);
            else
                gameObject.transform.Translate(-fSpeed, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                gameObject.transform.Translate(fSpeed * 2, 0.0f, 0.0f);
            else
                gameObject.transform.Translate(fSpeed, 0.0f, 0.0f);
        }
    }

    void StayUp()
    {
        gameObject.transform.rotation = new Quaternion(0, gameObject.transform.rotation.y, 0, gameObject.transform.rotation.w);
    }
}
