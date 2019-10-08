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
    }

    void PlayerMovement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            //gameObject.transform.Translate(
            //    gameObject.transform.localPosition.x,
            //    gameObject.transform.localPosition.y + 0.001f,
            //    gameObject.transform.localPosition.z
            //    );
            gameObject.transform.Translate(
                0.0f,
                0.01f,
                0.0f
                );
        }
    }
}
