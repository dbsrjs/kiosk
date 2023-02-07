using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iteamBtmController : MonoBehaviour
{
    private List<KioskDate> kioskDatas = new List<KioskDate>();
    
  public bool IsCheck(string name, KioskDate data)
    {
        if (kioskDatas.Count == 0)
        {
            kioskDatas.Add(data);
            return true;
        }
        else
        {
            bool check = true;
            foreach (var item in kioskDatas)
            {
                if (item.name == name)
                    check = false;
            }

            if(check)
            {
                kioskDatas.Add(data);
            }
            return check;
        }
    }
}
