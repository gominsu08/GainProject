using BackEnd;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class MainBackendManager : MonoBehaviour
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

        Login();
    }
    public void Login()
    {
        BackendReturnObject bro = Backend.BMember.CustomLogin(DataManager.Instance._loginIDSave, DataManager.Instance._loginPWSave);
        if (bro.IsSuccess())
        {
            Debug.Log("�α��ο� �����߽��ϴ�");
        }
        //BackendLogin.instance.CustomLogin(DataManager.Instance._loginIDSave, DataManager.Instance._loginPWSave);// [�߰�] �ڳ� �α���

        BackendReturnObject brod = Backend.BMember.IsAccessTokenAlive();
        if (brod.IsSuccess())
        {
            Debug.Log("�׼��� ��ū�� ����ֽ��ϴ�");
        }
        // [�߰�] ������ �ҷ��� �����Ͱ� �������� ���� ���, �����͸� ���� �����Ͽ� ����
        if (BackendGameData.userData == null)
        {
            BackendGameData.Instance.GameDataInsert();
        }

        BackendGameData.Instance.LevelUp(); // [�߰�] ���ÿ� ����� �����͸� ����
        BackendGameData.Instance.GameDataUpdate();
        BackendGameData.Instance.GameDataGet();



        BackendRank.instance.RankInsert(DataManager.Instance.currentGold);

        ////BackendGameData.Instance.GameDataGet();


        Debug.Log("�׽�Ʈ�� �����մϴ�.");
    }
}
