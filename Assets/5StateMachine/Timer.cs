using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    bool once=true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (once && Time.time > 5)
        {
            GameObject.Find("StateMachine").GetComponent<StateMachine>().SetState(1);
            once = false;
        }
    }
}
