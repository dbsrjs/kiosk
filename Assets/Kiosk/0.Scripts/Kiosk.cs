using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MaunMenuType
{
    FastFood,
    Pizza,
    China,
    Coffee,
    Korea,
    Chicken,
}

public struct KioskDate
{
    public string name;
    public int price;
    public string dec;
}
public class Kiosk : MonoBehaviour
{
    [SerializeField] private GameObject menuObj;
    [SerializeField] private GameObject detailMenuObj;
    [SerializeField] private GameObject titleObj;

    [SerializeField] private Transform titleParent;
    [SerializeField] private ItemTitle titlePrefab;
    [SerializeField] private Transform detailParent;
    [SerializeField] private ItemDetail detailPrefab;

    [SerializeField] private iteamBtmController ibCount;
    [SerializeField] private ItemDetail itembd;

    List<string> titlelist = new List<string>();
    Dictionary<string, KioskDate> menuDic = new Dictionary<string, KioskDate>();
    private MaunMenuType selectType = MaunMenuType.FastFood;

    List<ItemDetail> ItemDetails = new List<ItemDetail>();

    // Start is called before the first frame update
    void Start()
    {
        titlelist.Clear();
        // �޴� ��
        switch (selectType)
        {
            case MaunMenuType.FastFood:
                {
                    string[] strs = { "�ܹ���", "����", "������", "�ҽ�", "���̽�ũ��" };
                    foreach (var item in strs)
                    {
                        titlelist.Add(item);
                    }
                }
                break;
            case MaunMenuType.Pizza:
                break;
            case MaunMenuType.China:
                break;
        }
        // �޴� ����
        OnShowMain();
    }

    public void OnShowMain()
    {
        ShowMain(true);

        // Ÿ��Ʋ ����
        for (int i = 0; i < titlelist.Count; i++)
        {

            ItemTitle title = Instantiate(titlePrefab, titleParent);
            title.SetText(titlelist[i]);
            title.name = titlelist[i];

            Toggle toggle = title.GetComponent<Toggle>();
            toggle.group = titleParent.GetComponent<ToggleGroup>();
            toggle.onValueChanged.AddListener(delegate { OnToggle(toggle); });

            if (i == 0)
            {
                toggle.isOn = true;
            }
        }
    }

    public void OnShowDetail()
    {
        ShowMain(false);
    }

    void ShowMain(bool isShow)
    {
        menuObj.SetActive(isShow);
        detailMenuObj.SetActive(!isShow);
        titleObj.SetActive(!isShow);
    }

    public void OnToggle(Toggle toggle)
    {
        SubMenuSetting(toggle);
        if (toggle.isOn)
        {
            Debug.Log(toggle.name);
        }
    }

    void SubMenuSetting(Toggle toggle)
    {
        if (toggle.isOn)
            return;
        
            menuDic.Clear();
        

        switch (toggle.name)
        {
            case "�ܹ���":
                {
                    string[] keys = { "�Ұ�����", "�������", "�Ұ�����", "ġ�����", "ġŲ����" };
                    int[] prices = { 3000, 5000, 8000, 4500, 6000 };
                    DataSetCrateMenu(keys, prices);
                }                
                break;
            case "����":
                {
                    string[] keys = { "�ݶ�", "�����ݶ�", "���̴�", "ȯŸ", "��Ű��" };
                    int[] prices = { 1200, 1500, 1200, 1300, 1100 };
                    DataSetCrateMenu(keys, prices);
                }
                break;
            case "������":
                {
                    string[] keys = { "����Ƣ��", "��Ͼ�", "��¡��", "�ʰ�", "ġ�ƽ" };
                    int[] prices = { 500, 800, 1000, 800, 600 };
                    DataSetCrateMenu(keys, prices);
                }
                break;
            case "�ҽ�":
                {
                    string[] keys = { "ĥ��", "��Ͼ�", "ġ��", "����", "�ӽ�Ÿ��" };
                    int[] prices = { 300, 500, 800, 100, 100 };
                    DataSetCrateMenu(keys, prices);
                }
                break;
            case "���̽�ũ��":
                {
                    string[] keys = { "����", "�ٴҶ�", "����", "������", "����", "��Ʈ����" };
                    int[] prices = { 800, 600, 800, 900, 900, 1000 };
                    DataSetCrateMenu(keys, prices);
                }
                break;

        }
    }
    void DataSetCrateMenu(string[] keys, int[] prices)
    {
        for (int i = 0; i < keys.Length; i++)
        {
            KioskDate data = new KioskDate();
            data.price = prices[i];
            data.name = keys[i];

            menuDic.Add(keys[i], data);
        }

        if (detailParent.childCount < keys.Length)
        {
            int gap = System.Math.Abs(detailParent.childCount - keys.Length);
            for (int i = 0; i < gap; i++)
            {
                ItemDetails.Add(Instantiate(detailPrefab, detailParent));
            }
        }

        int index = 0;
        foreach(var item in menuDic)
        {
            ItemDetails[index].gameObject.SetActive(true);
            ItemDetails[index]
                 .SetNameText(item.Value.name)
                 .SetPriceText(item.Value.price)
                 .SetItemBD(itembd)
                 .SetIBCount(ibCount)
                 .SetKioskData(item.Value);
                 

            index++;                
        }

        int close = menuDic.Count - (detailParent.childCount);
        if (close < 0)
        {
            int c = detailParent.childCount - 1;
            for (int i = 0; i < System.Math.Abs(close); i++)
            {
                ItemDetails[c].gameObject.SetActive(false);
                c--;
            }
        }
    }
}
