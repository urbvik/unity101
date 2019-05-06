using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    //ROTATE CUBE LOOP VALUES
    float distance = 10;
    float xRotation = 60f;
    float yRotation = 190f;
    float zRotation = 180f;
    float speed = 2.7f;

    //TRACE MOUSE POINTER VALUES
    public Vector3 mousePosition;
    public Vector3 objposition;
    public Rigidbody rb;

    //STATE TO USE CUBE
    bool CanUseCube = true;
    //STATE FOLLOW CUBE
    int FollowPlayer = 0;

    //THROW CUBE ON MOUSE RELEASE VALUES
    public int clickForce = 500;
    private Plane plane = new Plane(Vector3.up, Vector3.zero);

    public Vector3 offSet;
    float speedCamera = 100.0f;

    public float ZoomOutTime = 2f;
    int diceState = 0;
    float startTime=0;

    GameObject cam;
    Vector3 camStartPos;
    Quaternion camStartRotation;

    private void Start()
    {
        cam = GameObject.Find("Main Camera");
    }

    //ON MOUSE HOLD
    private void OnMouseDrag()
    {
        if (CanUseCube)
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
        if (diceState==1 && rb.velocity.sqrMagnitude < .001 && rb.angularVelocity.sqrMagnitude < .001 && FollowPlayer == 1)//much faster than magnitude
        {
            //save cam start position and rotation
            camStartPos = cam.transform.position;
            camStartRotation = cam.transform.rotation;

            //zoom in
            cam.transform.position = rb.transform.position - offSet;
            diceState = 2;
            startTime = Time.time;

            Camera.main.transform.eulerAngles = Vector3.Lerp(Camera.main.transform.eulerAngles, new Vector3(15, 0, 0), Time.deltaTime * speedCamera);
               
            
        }
        else if (diceState == 2)
        {
            //zoom out after time
            if ((Time.time - startTime) > ZoomOutTime)
            {
                //reset cam to start position and rotation
                cam.transform.position = camStartPos;
                cam.transform.rotation = camStartRotation;
                diceState = 0;

                //activat dice again
                CanUseCube = true;
            }
        }
    }

    //ON MOUSE RELEASE
    private void OnMouseUp()
    {
        //THROW CUBE ON MOUSE RELEASE 
        if (CanUseCube)
        {
            diceState = 1;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //NEW VALUES
            CanUseCube = false;
            FollowPlayer = 1;

            if (plane.Raycast(ray, out float enter))
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
