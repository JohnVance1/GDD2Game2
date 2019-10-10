﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    public GameObject target;
    public GameObject seeker;
    Rigidbody sBody;
    Vector3 TPos;
    
    Vector3 SPos;

    Vector3 velocity;
    

    // Start is called before the first frame update
    void Start()
    {
        TPos = target.transform.position;
        
        SPos = seeker.transform.position;

        velocity = seeker.GetComponent<Rigidbody>().velocity;

        sBody = seeker.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        TPos = target.transform.position;

        SPos = seeker.transform.position;

        Vector3 vecVelocity = SPos - TPos;

        vecVelocity.Normalize();

        vecVelocity -= velocity;

        vecVelocity *= -1;

        sBody.AddForce(vecVelocity);


    }

}
