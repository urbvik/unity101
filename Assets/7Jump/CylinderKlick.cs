using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderKlick : MonoBehaviour
{
    private void OnMouseDown()
    {
        print(transform.name);

        GameObject theBoy = GameObject.Find("YoungBoy");
        theBoy.GetComponent<Rigidbody>().isKinematic = false;

        theBoy.GetComponent<Ballistic>().JumpToPoint(transform.position);
        
        theBoy.GetComponent<Rigidbody>().useGravity = true;
    }

    
}
