using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsTips : MonoBehaviour
{
    private static ControlsTips _instance;
    public GameObject tipItemPrefab;
    public List<ItemTipHolder> tipsList;
    private GameObject content;



    public static ControlsTips Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        content = transform.GetChild(0).GetChild(0).gameObject;
        AddTipsToScrollView();
    }

    void AddTipsToScrollView()
    {
        foreach (ItemTipHolder tip in tipsList)
        {
            GameObject _go = Instantiate(tipItemPrefab, Vector3.zero, Quaternion.identity);
            tip.selfObject = _go;
            _go.name = "Tip_" + tip.name;
            _go.transform.SetParent(content.transform);
            _go.transform.GetChild(0).GetComponent<Image>().sprite = tip.keyImage;
            _go.transform.GetChild(1).GetComponent<Text>().text = tip.tipDescription;
            _go.SetActive(false);
        }
    }

    public void ShowTip(string name)
    {
        tipsList.Find(item => item.name == name).selfObject.SetActive(true);
    }


    public void HideTip(string name)
    {
        tipsList.Find(item => item.name == name).selfObject.SetActive(false);
    }
}

[System.Serializable]
public class ItemTipHolder
{
    [Tooltip("It is necessary when calling the TipShow() or TipHide() methods to identify specific tip object")]
    public string name;
    public Sprite keyImage;
    public string tipDescription;
    [HideInInspector]
    public GameObject selfObject;
}

