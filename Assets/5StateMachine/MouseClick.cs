using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnMouseDown()
    {
        print(transform.name + " clicked!");

        StateMachine stateMachnine = GameObject.Find("StateMachine").GetComponent<StateMachine>();

        int state = stateMachnine.GetState();
        if (state < 3)
            stateMachnine.SetState(state + 1);
        else
            stateMachnine.SetState(0);

    }
}
