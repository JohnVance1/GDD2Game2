using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : MonoBehaviour
{
    // ********************* use the Obstacle tag to find obstacles to avoid


    GameObject[] goObstacles = GameObject.FindGameObjectsWithTag("Obstace");
    public GameObject goVehicle;
    Rigidbody vBody;
    Vector3 v3VehiclePos;
    Vector3 v3Velocity;

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="obstacle"></param>
    /// <returns>Returns the force needed to avoid an obstacle.</returns>
    protected Vector3 AvoidObstacle(GameObject obstacle)
    {
        // Vector to obstacle
        Vector3 vecToCenter = obstacle.transform.position - vehiclePosition;
        // dot product to forward
        float dotForward = Vector3.Dot(vecToCenter, transform.forward);
        // dot product to right
        float dotRight = Vector3.Dot(vecToCenter, transform.right);
        // radii sum
        float radiiSum = obstacle.GetComponent<Obstacle>().radius + radius;

        // Step 1: what is behind? If so, return an empty force.
        if (dotForward < 0)
        {
            return Vector3.zero;
        }

        // Step 2: is it within distance? If not, return an empty force.
        if (vecToCenter.sqrMagnitude > (safeDistance * safeDistance))
        {
            return Vector3.zero;
        }

        // Step 3: test for non-intersections.
        if (dotRight > radiiSum)
        {
            return Vector3.zero;
        }

        // Step 4: calculate the dodge force.
        Vector3 desiredVelocity = Vector3.zero;
        if (dotRight >= 0) // If right, dodge left.
        {
            desiredVelocity = -transform.right * maxSpeed;
        }
        else // If left, dodge right.
        {
            desiredVelocity = transform.right * maxSpeed;
        }

        Debug.DrawLine(transform.position, obstacle.transform.position, Color.green);
        Debug.DrawLine(transform.position, transform.position + desiredVelocity * 10, Color.red);

        return desiredVelocity - velocity;
    }

}
