using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class itemDetail : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text priceText;
    
    public void SetNameText(string name)
    {
        nameText.text = name;
    }

    public itemDetail SetPriceText(int price)
    {
        // 1000;
        //priceText.text = price.ToString();
        priceText.text = string.Format("{0:#,###}¿ø", price);
        return this;
    }
}
