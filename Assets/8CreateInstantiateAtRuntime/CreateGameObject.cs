using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameObject : MonoBehaviour
{
    float offset = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.AddComponent<Rigidbody>();

                cube.transform.position = new Vector3(x + offset*x, y + offset*y, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
