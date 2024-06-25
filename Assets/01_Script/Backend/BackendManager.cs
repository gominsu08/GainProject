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

    [SerializeField] private TMP_InputField _nickName;

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

    public void Join()
    {
            if(_nickName.text == "")
                return;

            // ���� �׽�Ʈ ���̽� �߰�
            BackendLogin.instance.CustomSignUp($"{_joinID.text}", $"{_joinPW.text}"); // [�߰�] �ڳ� ȸ������ �Լ�
            BackendLogin.instance.UpdateNickname($"{_nickName.text}"); // [�߰�] �г��� ����
            BackendGameData.Instance.GameDataInsert();
            //BackendLogin.Instance.CustomLogin("���ϴ� �̸�", "1234");// [�߰�] �ڳ� �α���
            Debug.Log("�׽�Ʈ�� �����մϴ�.");
    }


    public void Login()
    {
            // ���� �׽�Ʈ ���̽� �߰�
            //BackendLogin.Instance.CustomSignUp($"{_JoinID.text}", $"{_JoinPW.text}"); // [�߰�] �ڳ� ȸ������ �Լ�
            BackendLogin.instance.CustomLogin($"{_loginID.text}", $"{_loginPW.text}");// [�߰�] �ڳ� �α���
            BackendGameData.Instance.GameDataGet();
            //BackendLogin.Instance.UpdateNickname("���ϴ� �̸�"); // [�߰�] �г��� ����
            Debug.Log("�׽�Ʈ�� �����մϴ�.");
    }

    private void Update()
    {

        if (BackendLogin.instance.isLogin)
        {
            DataManager.Instance._loginIDSave = _loginID.text;
            DataManager.Instance._loginPWSave = _loginPW.text;
            SceneManager.LoadScene("MenuScene");
        }
        if (BackendLogin.instance.isJoin)
        {
            DataManager.Instance._loginIDSave = _joinID.text;
            DataManager.Instance._loginPWSave = _joinPW.text;
            SceneManager.LoadScene("MenuScene");
        }
    }
}
