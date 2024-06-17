using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class CostManager : MonoSingleton<CostManager>
{
    [SerializeField] private int _startCost;

    private int _currentCost;

    public int CurrentCost 
    {
        get 
        { 
            return _currentCost;
        }
        set
        {
            if (value < 0)
            {
                _currentCost = 0;
            }
            else
            {
                _currentCost = value;
            }
        } 
    }

    [SerializeField] private TMP_Text _currentCostText;

    private void Awake()
    {
        CurrentCost = _startCost;
    }

    private void Update()
    {
        _currentCostText.text = $"Current Cost : {CurrentCost}";
    }
}
