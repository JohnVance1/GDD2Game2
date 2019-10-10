using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{

    void Start()
    {
        
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
            gameObject.transform.Translate(
                0.0f,
                0.0f,
                0.1f
                );
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(
                0.0f,
                0.0f,
                -0.1f
                );
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(
                -0.1f,
                0.0f,
                0.0f
                );
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(
                0.1f,
                0.0f,
                0.0f
                );
        }
    }

    void StayUp()
    {
        gameObject.transform.rotation = new Quaternion(0, gameObject.transform.rotation.y, 0, gameObject.transform.rotation.w);
    }
}
