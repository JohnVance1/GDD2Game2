using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{

    public static Vector3 direction;

    [SerializeField]
    private float thrust;

    public GameObject target;
    public GameObject seeker;
    Rigidbody sBody;
    Vector3 TPos;
    
    Vector3 SPos;

    Vector3 velocity;

    float timer;


    // Start is called before the first frame update
    void Start()
    {
        TPos = target.transform.position;
        
        SPos = seeker.transform.position;

        velocity = seeker.GetComponent<Rigidbody>().velocity;

        sBody = seeker.GetComponent<Rigidbody>();

        timer = 10.0f;

    }

    // Update is called once per frame
    void Update()
    {
        TPos = target.transform.position;
        TPos.y += 1.5f;

        SPos = seeker.transform.position;

        Vector3 vecVelocity = SPos - TPos;

        
        Debug.Log(timer);

        timer -= Time.deltaTime;

        vecVelocity.Normalize();

        vecVelocity -= velocity;

        vecVelocity *= -1 * thrust;

        direction = vecVelocity;

        if (timer <= 0)
        {
            vecVelocity.y = 1;
            vecVelocity.y *= 7500;

            timer = 10.0f;
        }

        sBody.AddForce(vecVelocity);


    }

 

}
