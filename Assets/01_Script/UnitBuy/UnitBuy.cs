using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitBuy : MonoBehaviour
{
    [SerializeField] private Tower _unitBuyPrefab;


    private GameObject _unit;
    private bool _isUnitSet1, _isUnitSet2;
    public void CreatUnit()
    {
        if (CostManager.Instance.CurrentCost - _unitBuyPrefab._weaponSO.cost >= 0)
        {
            CostManager.Instance.CurrentCost -= _unitBuyPrefab._weaponSO.cost;
        }
        else
        {
            return;
        }
        _unit = Instantiate(_unitBuyPrefab.gameObject);
        StartCoroutine(UnitLocationSet());
    }
    private void Update()
    {
        UnitLocationSet2();
    }

    private void UnitLocationSet2()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_unit == null)
                return;
            print((_unit.GetComponent<Tower>().isUnitCheck) + " == 현재 상태");
            if (!_unit.GetComponent<Tower>().isUnitCheck)
            {
                _unit.layer = 10;
                StopAllCoroutines();
                print("설치됨");
                SetManager();
            }
        }

    }



    private void SetManager()
    {
        _isUnitSet1 = false;
        _isUnitSet2 = false;
        _unit = null;
    }

    private IEnumerator UnitLocationSet()
    {
        while (true)
        {
            _unit.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            yield return new WaitForEndOfFrame();
        }
    }
}
