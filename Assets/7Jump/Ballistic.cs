using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballistic : MonoBehaviour
{
    public void JumpToPoint(Vector3 point)
    {
        var velocity = CalculateVelocity(point, 60f);

        //Debug.Log("Jumping at " + point + " velocity " + velocity);

        GetComponent<Rigidbody>().velocity = velocity;
    }

    private Vector3 CalculateVelocity(Vector3 destination, float angle)
    {
        Vector3 dir = destination - transform.position; // get Target Direction
        float height = dir.y; // get height difference
        dir.y = 0; // retain only the horizontal difference
        float dist = dir.magnitude; // get horizontal direction
        float a = angle * Mathf.Deg2Rad; // Convert angle to radians
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
        dist += height / Mathf.Tan(a); // Correction for small height differences

        // Calculate the velocity magnitude
        float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * dir.normalized; // Return a normalized vector.
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;


        //denna rörelse borde ske under typ en halv sekund
        //större colisonsarea och en timer borde kunna fixa det...
        Vector3 pos = collision.transform.position;
        pos.y += 0.1f;
        transform.position = pos;

    }

    
}
