using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CostManager : MonoBehaviour
{
    private CostManager _instance;

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

    public CostManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new CostManager();
            }

            return _instance;
        }
    }


    private void Start()
    {
        _currentCostText.text = $"Current Cost : {_startCost}";
    }
}
