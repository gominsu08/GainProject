using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using System;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BackendManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _loginID;
    [SerializeField] private TMP_InputField _loginPW;

    [SerializeField] private TMP_InputField _joinID;
    [SerializeField] private TMP_InputField _joinPW;

    private string _loginIDSave;
    private string _joinIDSave;
    private string _joinPWSave;
    private string _loginPWSave;

    public void JoinDataSave()
    {
        if (_joinID == null || _joinPW == null)
        {
            return;
        }

        _joinIDSave = _joinID.text;
        _joinPWSave = _joinPW.text;
    }

    public void LoginDataSave()
    {

        if (_loginID == null || _loginPW == null)
        {
            return;
        }
        _loginIDSave = _loginID.text;
        _loginPWSave = _loginPW.text;
    }


    void Start()
    {
        var bro = Backend.Initialize(true); // �ڳ� �ʱ�ȭ
        print(bro);

        // �ڳ� �ʱ�ȭ�� ���� ���䰪
        if (bro.IsSuccess())
        {
            Debug.Log("�ʱ�ȭ ���� : " + bro); // ������ ��� statusCode 204 Success
        }
        else
        {
            Debug.LogError("�ʱ�ȭ ���� : " + bro); // ������ ��� statusCode 400�� ���� �߻�
        }
    }

    public async void Join()
    {
        if (_joinID == null || _joinPW == null)
        {
            return;
        }

        await Task.Run(() =>
        {
            // ���� �׽�Ʈ ���̽� �߰�
            BackendLogin.instance.CustomSignUp($"{_joinIDSave}", $"{_joinPWSave}"); // [�߰�] �ڳ� ȸ������ �Լ�
            
            //BackendLogin.Instance.CustomLogin("���ϴ� �̸�", "1234");// [�߰�] �ڳ� �α���
            //BackendLogin.Instance.UpdateNickname("���ϴ� �̸�"); // [�߰�] �г��� ����
            Debug.Log("�׽�Ʈ�� �����մϴ�.");
        });
    }


    public async void Login()
    {
        if (_loginID == null || _loginPW == null)
        {
            return;
        }

        await Task.Run(() =>
        {
            // ���� �׽�Ʈ ���̽� �߰�
            //BackendLogin.Instance.CustomSignUp($"{_JoinID.text}", $"{_JoinPW.text}"); // [�߰�] �ڳ� ȸ������ �Լ�
            BackendLogin.instance.CustomLogin($"{_loginIDSave}", $"{_loginPWSave}");// [�߰�] �ڳ� �α���
            //BackendLogin.Instance.UpdateNickname("���ϴ� �̸�"); // [�߰�] �г��� ����
            Debug.Log("�׽�Ʈ�� �����մϴ�.");
        });
    }

    private void Update()
    {
        if (BackendLogin.instance.isLogin)
            SceneManager.LoadScene("MenuScene");
        if (BackendLogin.instance.isJoin)
            SceneManager.LoadScene("MenuScene");
    }
}
