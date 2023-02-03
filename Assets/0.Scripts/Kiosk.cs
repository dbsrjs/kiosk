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

public class Kiosk : MonoBehaviour
{
    [SerializeField] private GameObject menuObj;
    [SerializeField] private GameObject detailMenuObj;
    [SerializeField] private GameObject titleObj;

    [SerializeField] private Transform titleParent;
    [SerializeField] private ItemTitle titlePrefab;
    [SerializeField] private Transform detailParent;
    [SerializeField] private Transform detailPrefab;

    List<string> titlelist = new List<string>();
    Dictionary<string, int> menuDoc = new Dictionary<string, int>();

    private MaunMenuType selectType = MaunMenuType.FastFood;

    // Start is called before the first frame update
    void Start()
    {
        titlelist.Clear();
        switch (selectType)
        {
            case MaunMenuType.FastFood:
                {
                    string[] strs = {"햄버거", "음료", "튀김", "스낵류", "소스", "아이스크림"};
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
        if (toggle.isOn)
        {
            Debug.Log(toggle.name);
        }
    }
}
