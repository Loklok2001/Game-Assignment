using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PotionUI : MonoBehaviour
{
    public int potionquantity = 0;
    public TextMeshProUGUI text_quantity;

    // Update is called once per frame
    void Update()
    {
        text_quantity.text = potionquantity.ToString();
    }

    public void getPotionQuantity(int quantity)
    {
        potionquantity = quantity;
    }
}
