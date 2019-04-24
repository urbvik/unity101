 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickContry : MonoBehaviour
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
  

        //delete all game objects - exclude light and camera
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {

            Component lig = o.GetComponent<Light>();

            if (lig==null)
                Destroy(o);  
        }

        
       Instantiate(Resources.Load("star")); //MUST BE INSIDE THE RESOURCES FOLDER!
       




    }
}
