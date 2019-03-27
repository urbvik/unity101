using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class wallet : MonoBehaviour
{
    private int total = 1000;



    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshPro>().text = "Wallet: " + total.ToString() + "$";
    }

    public void Pay(int price)
    {
        total -= price;
    }
}
