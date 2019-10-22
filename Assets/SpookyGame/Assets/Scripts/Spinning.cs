using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    [SerializeField]
    float strength;
    
    Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Seek.direction;
        direction.Normalize();
        body.AddTorque(new Vector3(direction.z * strength, 0, -direction.x * strength));
    }
}
