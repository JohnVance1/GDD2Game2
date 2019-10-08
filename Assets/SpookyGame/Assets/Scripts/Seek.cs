using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    GameObject target;
    GameObject seeker;
    float Tx;
    float Ty;
    float Tz;
    float Sx;
    float Sy;
    float Sz;

    // Start is called before the first frame update
    void Start()
    {
        Tx = target.transform.position.x;
        Ty = target.transform.position.y;
        Tz = target.transform.position.z;

        Sx = seeker.transform.position.x;
        Sy = seeker.transform.position.y;
        Sz = seeker.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        

        
    }
}
