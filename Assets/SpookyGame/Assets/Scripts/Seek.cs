using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{

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

        timer = 3.0f;

    }

    // Update is called once per frame
    void Update()
    {
        TPos = target.transform.position;
        TPos.y += 1.5f;

        SPos = seeker.transform.position;

        Vector3 vecVelocity = SPos - TPos;

        if(timer <= 0)
        {
            vecVelocity += Jump(vecVelocity);
            timer = 3.0f;
        }

        timer -= Time.deltaTime;

        vecVelocity.Normalize();

        vecVelocity -= velocity;

        vecVelocity *= -1 * thrust;

        sBody.AddForce(vecVelocity);


    }

    Vector3 Jump(Vector3 currentV)
    {
        Vector3 jump;
        Quaternion jumpQuat;

        jump = currentV.normalized;

        jumpQuat = Quaternion.AngleAxis(45, Vector3.up);

        jump  = jumpQuat * jump;

        return jump;

    }

}
