using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(Vector3.up, 1f);
    }

    private void OnMouseDown()
    {
        print("Klickade på kuben");

        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.AddForce(transform.up * 300f);
        rigid.AddForce(transform.right * 300f);
        rigid.useGravity = true;
    }
}
