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
    [SerializeField] private TMP_InputField _LoginID;
    [SerializeField] private TMP_InputField _LoginPW;

    [SerializeField] private TMP_InputField _JoinID;
    [SerializeField] private TMP_InputField _JoinPW;

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
        if (_JoinID == null || _JoinPW == null)
        {
            return;
        }

        await Task.Run(() =>
        {
            // ���� �׽�Ʈ ���̽� �߰�
            BackendLogin.instance.CustomSignUp($"{_JoinID.text}", $"{_JoinPW.text}"); // [�߰�] �ڳ� ȸ������ �Լ�
            //BackendLogin.Instance.CustomLogin("���ϴ� �̸�", "1234");// [�߰�] �ڳ� �α���
            //BackendLogin.Instance.UpdateNickname("���ϴ� �̸�"); // [�߰�] �г��� ����
            Debug.Log("�׽�Ʈ�� �����մϴ�.");
        });
    }


    public async void Login()
    {
        if (_LoginID == null || _LoginPW == null)
        {
            return;
        }

        await Task.Run(() =>
        {
            // ���� �׽�Ʈ ���̽� �߰�
            //BackendLogin.Instance.CustomSignUp($"{_JoinID.text}", $"{_JoinPW.text}"); // [�߰�] �ڳ� ȸ������ �Լ�
            BackendLogin.instance.CustomLogin($"{_LoginID.text}", $"{_LoginPW.text}");// [�߰�] �ڳ� �α���
            //BackendLogin.Instance.UpdateNickname("���ϴ� �̸�"); // [�߰�] �г��� ����
            Debug.Log("�׽�Ʈ�� �����մϴ�.");
        });
    }

    private void Update()
    {
        if (BackendLogin.instance.isJoin)
            SceneManager.LoadScene("MenuScene");
        if (BackendLogin.instance.isLogin)
            SceneManager.LoadScene("MenuScene");
    }
}
