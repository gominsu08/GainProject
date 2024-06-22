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

    public async void Join()
    {
        await Task.Run(() =>
        {
            if(_nickName.text == "")
                return;

            // ���� �׽�Ʈ ���̽� �߰�
            BackendLogin.instance.CustomSignUp($"{_joinID.text}", $"{_joinPW.text}"); // [�߰�] �ڳ� ȸ������ �Լ�
            BackendGameData.Instance.GameDataInsert();
            BackendRank.instance.RankInsert(0);
            //BackendLogin.Instance.CustomLogin("���ϴ� �̸�", "1234");// [�߰�] �ڳ� �α���
            BackendLogin.instance.UpdateNickname($"{_nickName.text}"); // [�߰�] �г��� ����
            Debug.Log("�׽�Ʈ�� �����մϴ�.");
        });
    }


    public async void Login()
    {
        await Task.Run(() =>
        {
            // ���� �׽�Ʈ ���̽� �߰�
            //BackendLogin.Instance.CustomSignUp($"{_JoinID.text}", $"{_JoinPW.text}"); // [�߰�] �ڳ� ȸ������ �Լ�
            BackendLogin.instance.CustomLogin($"{_loginID.text}", $"{_loginPW.text}");// [�߰�] �ڳ� �α���
            BackendGameData.Instance.GameDataGet();
            //BackendLogin.Instance.UpdateNickname("���ϴ� �̸�"); // [�߰�] �г��� ����
            Debug.Log("�׽�Ʈ�� �����մϴ�.");
        });
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
