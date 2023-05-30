using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemDetail : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text priceText;

    [SerializeField] private Transform parent;
    [SerializeField] private ItemDetail itembd;

    //[SerializeField] private
    private iteamBtmController ibCount;
    private KioskDate kioskData;

    public ItemDetail SetNameText(string name)
    {
        nameText.text = name;
        return this;
    }

    public ItemDetail SetPriceText(int price)
    {
        priceText.text = string.Format("{0:#,###}¿ø", price);
        return this;
    }
    public ItemDetail SetIBCount(iteamBtmController count)
    {
        ibCount = count;
        return this;
    }
    public ItemDetail SetKioskData(KioskDate data)
    {
        kioskData = data;
        return this; 
    }
    public ItemDetail SetParent(Transform parent)
    {
        this.parent = parent;
        return this;
    }
    public ItemDetail SetItemBD(ItemDetail itembd)
    {
        this.itembd = itembd;
        return this;
    }
    public void OnClick()
    {
        if (ibCount.IsCheck(kioskData.name, kioskData))
        {
            Instantiate(itembd, parent);
        }
    }
}
