using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private GameObject greenCube;
    private GameObject redSphere;
    private GameObject blueCapsule;


    public string[] states;
    int current_state;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();

        greenCube = GameObject.Find("GreenCube");
        redSphere = GameObject.Find("RedSphere");
        blueCapsule = GameObject.Find("BlueCapsule");

        SetState(0);
    }

    // Update is called once per frame
    void Update()
    {
        string text = "Current state is " +
                      "<#81C100>(" + current_state.ToString() + ")"+
                      "<#AFFF08><UPPERCASE> " + states[current_state] ;

        textMeshPro.SetText(text);
    }

    public void SetState(int new_state)
    {
        if (new_state >= 0 && new_state <= states.Length)
            current_state = new_state;
        else
            print("Unable to switch to state" + new_state.ToString() + " - not defined!");


        switch(current_state)
        {
            case 0:
                greenCube.GetComponent<BoxCollider>().enabled = false;
                redSphere.GetComponent<SphereCollider>().enabled = false;
                blueCapsule.GetComponent<CapsuleCollider>().enabled = false;
                break;
            case 1:
                greenCube.GetComponent<BoxCollider>().enabled = false;
                redSphere.GetComponent<SphereCollider>().enabled = false;
                blueCapsule.GetComponent<CapsuleCollider>().enabled = true;
                break;
            case 2:
                greenCube.GetComponent<BoxCollider>().enabled = true;
                redSphere.GetComponent<SphereCollider>().enabled = false;
                blueCapsule.GetComponent<CapsuleCollider>().enabled = false;
                break;
            case 3:
                greenCube.GetComponent<BoxCollider>().enabled = false;
                redSphere.GetComponent<SphereCollider>().enabled = true;
                blueCapsule.GetComponent<CapsuleCollider>().enabled = false;
                break;

        }
    }

    public int GetState()
    {
        return current_state;
    }
}
