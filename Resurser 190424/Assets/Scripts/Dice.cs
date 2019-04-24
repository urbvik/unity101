using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    //ROTATE CUBE LOOP VALUES
    float distance = 10;
    float xRotation = 60f;
    float yRotation = 90f;
    float zRotation = 180f;
    float speed = 0.33f;

    //TRACE MOUSE POINTER VALUES
    public Vector3 mousePosition;
    public Vector3 objposition;
    public Rigidbody rb;

    //STATE TO USE CUBE
    int CanUseCube = 1;
    //STATE FOLLOW CUBE
    int FollowPlayer = 0;

    //THROW CUBE ON MOUSE RELEASE VALUES
    public int clickForce = 500;
    private Plane plane = new Plane(Vector3.up, Vector3.zero);

    public Vector3 offSet;
    float speedCamera = 100.0f;
    int RotateCam = 1;
    //ON MOUSE HOLD
    private void OnMouseDrag()
    {
        if (CanUseCube == 1)
        {
            //TRACE MOUSE POINTER
            mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            objposition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objposition;
            //ROTATE CUBE LOOP
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(xRotation, yRotation, zRotation), Time.deltaTime * speed);
        }
    }

    private void Update()
    {
        //IF CUBE VELOCITY = 0 PLACE CAMERA OVER CUBE
        if (rb.velocity.sqrMagnitude < .001 && rb.angularVelocity.sqrMagnitude < .001 && FollowPlayer == 1)//much faster than magnitude
        {
            GameObject.Find("Main Camera").transform.position = rb.transform.position - offSet;

            if (RotateCam == 1)
            {
                Camera.main.transform.eulerAngles = Vector3.Lerp(Camera.main.transform.eulerAngles, new Vector3(15, 0, 0), Time.deltaTime * speedCamera);
                RotateCam = 2;
            }
        }
    }

    //ON MOUSE RELEASE
    private void OnMouseUp()
    {
        //THROW CUBE ON MOUSE RELEASE 
        if (CanUseCube == 1)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //NEW VALUES
            CanUseCube = 0;
            FollowPlayer = 1;
            float enter;
                if (plane.Raycast(ray, out enter))
                {
                    var hitPoint = ray.GetPoint(enter);
                    var mouseDir = hitPoint - gameObject.transform.position;
                    mouseDir = mouseDir.normalized;
                    rb.AddForce(mouseDir * clickForce);
                    rb.AddForce(5, 0, 5);
                }
        }
    }
}
