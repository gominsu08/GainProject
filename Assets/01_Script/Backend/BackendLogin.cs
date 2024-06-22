using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class BackendLogin : MonoBehaviour
{
    public static BackendLogin instance;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public bool isLogin = false;
    public bool isJoin = false;

    public void CustomSignUp(string id, string pw)
    {
        // Step 2. ȸ������ �����ϱ� ����
        Debug.Log("ȸ�������� ��û�մϴ�.");

        var bro = Backend.BMember.CustomSignUp(id, pw);

        if (bro.IsSuccess())
        {
            Debug.Log("ȸ�����Կ� �����߽��ϴ�. : " + bro);
            isJoin = true;
            print(isJoin);
        }
        else
        {
            Debug.LogError("ȸ�����Կ� �����߽��ϴ�. : " + bro);
        }
    }


    public void CustomLogin(string id, string pw)
    {
        // Step 3. �α��� �����ϱ� ����
        Debug.Log("�α����� ��û�մϴ�.");

        var bro = Backend.BMember.CustomLogin(id, pw);

        if (bro.IsSuccess())
        {
            Debug.Log("�α����� �����߽��ϴ�. : " + bro);

            isLogin = true;
            print(isLogin);
        }
        else
        {
            Debug.LogError("�α����� �����߽��ϴ�. : " + bro);
        }
    }

    public void UpdateNickname(string nickname)
    {
        // Step 4. �г��� ���� �����ϱ� ����
        Debug.Log("�г��� ������ ��û�մϴ�.");

        var bro = Backend.BMember.UpdateNickname(nickname);

        if (bro.IsSuccess())
        {
            Debug.Log("�г��� ���濡 �����߽��ϴ� : " + bro);
        }
        else
        {
            Debug.LogError("�г��� ���濡 �����߽��ϴ� : " + bro);
        }
    }
}
