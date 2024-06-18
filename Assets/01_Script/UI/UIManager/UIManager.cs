using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _loginPanel;
    [SerializeField] private GameObject _joinPanel;
    [SerializeField] private GameObject _loginAndJoin;


    private void Awake()
    {
        _loginPanel.SetActive(false);
        _joinPanel.SetActive(false);
        _loginAndJoin.SetActive(false);
    }

    public void LoginAndJoin()
    {
        _loginPanel.SetActive(false);
        _joinPanel.SetActive(false);
        _loginAndJoin.SetActive(true);
    }

    public void Join()
    {
        _joinPanel.SetActive(true);
        _loginAndJoin.SetActive(false);
    }

    public void Login()
    {
        _loginPanel.SetActive(true);
        _loginAndJoin.SetActive(false);
    }

}
