using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseHoverEffect : MonoBehaviour
{
    private void OnMouseEnter()
    {
            gameObject.AddComponent<Outline>();
            print("Outline Active");   
    }
    private void OnMouseExit()
    {
        Destroy(GetComponent<Outline>());
        print("Outline Removed");
    }
    
}
