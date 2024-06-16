using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using System;
using System.Threading.Tasks;

public class BackendManager : MonoBehaviour
{
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
        
        Test();
    }

    async void Test()
    {
        await Task.Run(() => {
            // ���� �׽�Ʈ ���̽� �߰�
            //BackendLogin.Instance.CustomSignUp("user1", "1234"); // [�߰�] �ڳ� ȸ������ �Լ�
            BackendLogin.Instance.CustomLogin("���ϴ� �̸�", "1234");// [�߰�] �ڳ� �α���
            //BackendLogin.Instance.UpdateNickname("���ϴ� �̸�"); // [�߰�] �г��� ����
            Debug.Log("�׽�Ʈ�� �����մϴ�.");
        });
    }
    
}
