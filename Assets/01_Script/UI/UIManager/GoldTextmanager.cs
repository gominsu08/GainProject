using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldTextmanager : MonoBehaviour
{

    [SerializeField] private TMP_Text _goldTxet;
    private void Update()
    {
        _goldTxet.text = $"���� ���� : {DataManager.Instance.currentGold}";
    }
}
