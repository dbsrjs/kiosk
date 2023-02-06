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
    [SerializeField] private itemDetail detailPrefab;

    List<string> titlelist = new List<string>();
    Dictionary<string, KioskDate> menuDic = new Dictionary<string, KioskDate>();
    private MaunMenuType selectType = MaunMenuType.FastFood;

    List<itemDetail> ItemDetails = new List<itemDetail>();

    // Start is called before the first frame update
    void Start()
    {
        titlelist.Clear();
        // 메뉴 메
        switch (selectType)
        {
            case MaunMenuType.FastFood:
                {
                    string[] strs = { "햄버거", "음료", "스낵류", "소스", "아이스크림" };
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
        // 메뉴 서브
        OnShowMain();
    }

    public void OnShowMain()
    {
        ShowMain(true);

        // 타이틀 셋팅
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
        menuDic.Clear();

        for (int i = detailParent.childCount - 1; i >= 0; i--)
        {
            Destroy(detailParent.GetChild(i).gameObject);
        }

        switch (toggle.name)
        {
            case "햄버거":
                {
                    string[] keys = { "불고기버거", "새우버거", "소고기버거", "치즈버거", "치킨버거" };
                    int[] prices = { 3000, 5000, 8000, 4500, 6000 };
                    DataSetCrateMenu(keys, prices);
                }                
                break;
            case "음료":
                {
                    string[] keys = { "콜라", "제로콜라", "사이다", "환타", "밀키스" };
                    int[] prices = { 1200, 1500, 1200, 1300, 1100 };
                    DataSetCrateMenu(keys, prices);
                }
                break;
            case "스낵류":
                {
                    string[] keys = { "감자튀김", "어니언링", "오징어", "너겟", "치즈스틱" };
                    int[] prices = { 500, 800, 1000, 800, 600 };
                    DataSetCrateMenu(keys, prices);
                }
                break;
            case "소스":
                {
                    string[] keys = { "칠리", "어니언", "치즈", "케찹", "머스타드" };
                    int[] prices = { 300, 500, 800, 100, 100 };
                    DataSetCrateMenu(keys, prices);
                }
                break;
            case "아이스크림":
                {
                    string[] keys = { "초코", "바닐라", "딸기", "오레오", "녹차", "민트초코" };
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
        int addCount = 0;
        if (ItemDetails.Count == 0)
        {
            foreach (var item in menuDic)
            {
                itemDetail id = Instantiate(detailPrefab, detailParent);
                id.SetNameText(item.Value.name);
                id.SetPriceText(item.Value.price);
                ItemDetails.Add(id);
            }
        }
        else if(addCount > detailParent.childCount)
        {
            foreach(var item in menuDic)
            {
                if(addCount < keys.Length)
                {
                    ItemDetails[addCount].gameObject.SetActive(true);
                    ItemDetails[addCount]
                        .SetNameText(item.Value.name)
                        .SetPriceText(item.Value.price);
                }
                else
                {
                    ItemDetails[addCount].gameObject.SetActive(false);
                }
                addCount++;
            }
        }
    }
}
