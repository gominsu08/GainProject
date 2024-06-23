using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoSingleton<ShopManager>
{
    [SerializeField] private GameObject _itemPanel;
    [SerializeField] private GameObject _unitPanel;

    [SerializeField] private TMP_Text moneyCount;

    private bool _changePanel;

    private void Awake()
    {
        _itemPanel.SetActive(false);
        moneyCount.text = $": {DataManager.Instance.manaStone}";
    }

    public void TextUpdate()
    {
        moneyCount.text = $": {DataManager.Instance.manaStone}";
    }

    public void PanelChange()
    {
        _unitPanel.SetActive(_changePanel);
        _changePanel = !_changePanel;
        _itemPanel.SetActive(_changePanel);
    }
}
