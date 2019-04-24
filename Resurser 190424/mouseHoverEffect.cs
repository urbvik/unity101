using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mouseHoverEffect : MonoBehaviour
{

    private bool sant = true;
    
    private void OnMouseDown()
    {
        //kräver en meshcollider för att fungera
        if (sant)
        {
            gameObject.AddComponent<Outline>();
            sant = false;
        }
        else
        {
            Destroy(GetComponent<Outline>());
            sant = true;
        }
        
    }

    
 
}
