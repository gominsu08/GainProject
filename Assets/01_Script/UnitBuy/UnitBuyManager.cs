using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBuyManager : MonoBehaviour
{
    [SerializeField] private GameObject _panelTrmF;//처음 아래꺼
    [SerializeField] private GameObject _panelTrmS;//처음 위에꺼


    /// <summary>
    /// 처음 아래꺼 버튼
    /// </summary>
    private Button[] _buyButton1;
    /// <summary>
    /// 처음 위에꺼 버튼
    /// </summary>
    private Button[] _buyButton2;
    /// <summary>
    /// 처음 아래꺼
    /// </summary>
    [SerializeField] private Image image1;
    /// <summary>
    /// 처음 위에꺼
    /// </summary>
    [SerializeField] private Image image2;

    [SerializeField] private Color32 color1;
    [SerializeField] private Color32 color2;

    private int index = 0;
    private Vector3 _panelTrmT;

    private void Awake()
    {
        _buyButton1 = _panelTrmF.GetComponentsInChildren<Button>();
        _buyButton2 = _panelTrmS.GetComponentsInChildren<Button>();
        foreach (Button button in _buyButton1)
        {
            button.interactable = false;
        }

    }

    public void BuyPanelChange()
    {
        _panelTrmT = _panelTrmF.transform.position;
        _panelTrmF.transform.position = _panelTrmS.transform.position;
        _panelTrmS.transform.position = _panelTrmT;
        index++;
        PanelSet(index);
    }

    public void PanelSet(int index)
    {
        if (index % 2 == 0)
        {
            image1.color = color2;
            image2.color = color1;
            image1.rectTransform.SetAsFirstSibling();
            foreach (Button button in _buyButton1)
            {
                button.interactable = false;
            }
            foreach (Button button in _buyButton2)
            {
                button.interactable = true;
            }
        }
        if (index % 2 != 0)
        {
            foreach (Button button in _buyButton1)
            {
                button.interactable = true;
            }
            foreach (Button button in _buyButton2)
            {
                button.interactable = false;
            }
            image1.color = color1;
            image2.color = color2;
            image2.rectTransform.SetAsFirstSibling();
        }
    }
}
