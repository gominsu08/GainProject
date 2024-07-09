using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using System;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class BackendManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _loginID;
    [SerializeField] private TMP_InputField _loginPW;

    [SerializeField] private TMP_InputField _joinID;
    [SerializeField] private TMP_InputField _joinPW;

    [SerializeField] private TMP_InputField _nickName;

    [SerializeField] private TMP_Text _joinErrorMessage;
    [SerializeField] private TMP_Text _loginErrorMessage;

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
        string text = _nickName.text;
        string pattern = @"sex|����|�߽�|Se��|��s|Sex|SEx|SEX|SeX|sEx|seX|����|����|��1��|��1��|//|��1��|��1��|ũ���Ľ�|�Ͼ���|�Ͼ�|����|�ù�
|������|�μ�����|����|gay|Gay|tlqkf|�۸�|�θ�|�Ϲ�|����|qudtls|tlqkf��|��|�ֹ�|��1��|��1��|��1��|��1��1|�Ͼֹ�|��1�ֹ�|�ѳ�|�ѳ�|�̱��|����|�빫
|����|��|�ڻ�|��1��|�ڵ�|��|911|523|�ѳ�����|���|��1��|�ѳ�1����|5��5��|�ϰ�|��1��|nigger|����|��Ʋ��|��ġ|�ؿ�|����|����|����|����|â��|â��|���
|��������|������|�����ڽ�|����|����|��1��|���|��ַ�|��ֻ���|�Ϻ���|�Ϻ�|�ް�����|�ް�|����|�����ô�|������|DC��|������|���|����|�ְ�";

        string replaced = Regex.Replace(text, pattern, "***");


        _nickName.text = replaced;

        if (_joinID.text == _nickName.text)
        {
            _joinErrorMessage.text = "ID�� name�� �ٸ��� �����ּ���";
            return;
        }
        try
        {
            int i = int.Parse(_joinID.text);
            try
            {
                int j = int.Parse(_nickName.text);
                _joinErrorMessage.text = "ID�� name�� ���ڰ� ���ԵǾ� ���� �ʽ��ϴ�";
                Debug.LogError("ID�� name�� ���ڰ� ���ԵǾ� ���� �ʽ��ϴ�");
            }
            catch
            {
                _joinErrorMessage.text = "ID�� ���ڰ� ���ԵǾ� ���� �ʽ��ϴ�";
                Debug.LogError("ID�� ���ڰ� ���ԵǾ� ���� �ʽ��ϴ�");
            }
        }
        catch
        {
            if (_joinID.text.Split(" ").Length > 1)
            {
                if (_nickName.text.Split(" ").Length > 1)
                {
                    _joinErrorMessage.text = "ID�� name�� ���Ⱑ ���ԵǾ� �ֽ��ϴ�";
                    Debug.LogError("ID�� name�� ���Ⱑ ���ԵǾ� �ֽ��ϴ�");
                    return;
                }
                _joinErrorMessage.text = "ID�� ���Ⱑ ���ԵǾ� �ֽ��ϴ�";
                Debug.LogError("ID�� ���Ⱑ ���ԵǾ� �ֽ��ϴ�");
                return;
            }
            try
            {
                int j = int.Parse(_nickName.text);
                _joinErrorMessage.text = "name�� ���ڰ� ���ԵǾ� ���� �ʽ��ϴ�";
                Debug.LogError("name�� ���ڰ� ���ԵǾ� ���� �ʽ��ϴ�");
            }
            catch
            {
                if (_nickName.text.Split(" ").Length > 1)
                {
                    _joinErrorMessage.text = "name�� ���Ⱑ ���ԵǾ� �ֽ��ϴ�";
                    Debug.LogError("name�� ���Ⱑ ���ԵǾ� �ֽ��ϴ�");
                    return;
                }
                BackendReturnObject bro = Backend.BMember.CustomSignUp(_joinID.text, _joinPW.text);
                if (bro.IsSuccess())
                {
                    _joinErrorMessage.text = "ȸ�����Կ� �����߽��ϴ�";
                    Debug.Log("ȸ�����Կ� �����߽��ϴ�");
                    SceneManager.LoadScene("MenuScene");
                    var bro2 = Backend.BMember.UpdateNickname(_nickName.text);

                    if (bro2.IsSuccess())
                    {
                        Debug.Log("�г��� ���濡 �����߽��ϴ� : " + bro2);
                        BackendGameData.Instance.GameDataInsert();
                    }
                    else
                    {
                        Debug.LogError("�г��� ���濡 �����߽��ϴ� : " + bro2);
                    }
                }
            }
        }


        //return;

        //if (_nickName.text == "")
        //    return;

        //// ���� �׽�Ʈ ���̽� �߰�
        //BackendLogin.instance.CustomSignUp($"{_joinID.text}", $"{_joinPW.text}"); // [�߰�] �ڳ� ȸ������ �Լ�
        //BackendLogin.instance.UpdateNickname($"{_nickName.text}"); // [�߰�] �г��� ����
        //BackendGameData.Instance.GameDataInsert();
        ////BackendLogin.Instance.CustomLogin("���ϴ� �̸�", "1234");// [�߰�] �ڳ� �α���
        //Debug.Log("�׽�Ʈ�� �����մϴ�.");
    }


    public void Login()
    {
        // ���� �׽�Ʈ ���̽� �߰�
        //BackendLogin.Instance.CustomSignUp($"{_JoinID.text}", $"{_JoinPW.text}"); // [�߰�] �ڳ� ȸ������ �Լ�
        BackendReturnObject bro = Backend.BMember.CustomLogin(_loginID.text, _loginPW.text);
        if (bro.IsSuccess())
        {
            Debug.Log("�α��ο� �����߽��ϴ�");
            _loginErrorMessage.text = "�α��ο� �����߽��ϴ�";
            BackendGameData.Instance.GameDataGet();
            SceneManager.LoadScene("MenuScene");
        }
        else
        {
            Debug.LogError("�α��ο� ���� �Ͽ����ϴ�");
            _loginErrorMessage.text = "�α��ο� �����߽��ϴ�";

        }
        //BackendLogin.instance.CustomLogin($"{_loginID.text}", $"{_loginPW.text}");// [�߰�] �ڳ� �α���

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
