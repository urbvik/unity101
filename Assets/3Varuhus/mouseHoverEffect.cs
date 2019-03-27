using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mouseHoverEffect : MonoBehaviour
{
    public Transform GmeObjText;
    public Transform GmeObjWallet;

    private void OnMouseEnter()
    {
        gameObject.AddComponent<Outline>();
        GmeObjText.GetComponent<TextMeshPro>().text = name;
        //print("Outline Active");   
    }
    private void OnMouseExit()
    {
        Destroy(GetComponent<Outline>());
        GmeObjText.GetComponent<TextMeshPro>().text = "Shop";
        //print("Outline Removed");
    }

    private void OnMouseDown()
    {
        int price = int.Parse(name.Split(' ')[1].Remove(3));
        Destroy(gameObject);
        GmeObjWallet.GetComponent<wallet>().Pay(price);
        GmeObjText.GetComponent<TextMeshPro>().text = "Shop";
    }

}
