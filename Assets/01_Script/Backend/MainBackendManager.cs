using BackEnd;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class MainBackendManager : MonoBehaviour
{
    void Start()
    {
        var bro = Backend.Initialize(true); // 뒤끝 초기화
        print(bro);

        // 뒤끝 초기화에 대한 응답값
        if (bro.IsSuccess())
        {
            Debug.Log("초기화 성공 : " + bro); // 성공일 경우 statusCode 204 Success
        }
        else
        {
            Debug.LogError("초기화 실패 : " + bro); // 실패일 경우 statusCode 400대 에러 발생
        }

        Login();
    }
    public void Login()
    {
        BackendReturnObject bro = Backend.BMember.CustomLogin(DataManager.Instance._loginIDSave, DataManager.Instance._loginPWSave);
        if (bro.IsSuccess())
        {
            Debug.Log("로그인에 성공했습니다");
        }
        //BackendLogin.instance.CustomLogin(DataManager.Instance._loginIDSave, DataManager.Instance._loginPWSave);// [추가] 뒤끝 로그인

        BackendReturnObject brod = Backend.BMember.IsAccessTokenAlive();
        if (brod.IsSuccess())
        {
            Debug.Log("액세스 토큰이 살아있습니다");
        }
        // [추가] 서버에 불러온 데이터가 존재하지 않을 경우, 데이터를 새로 생성하여 삽입
        if (BackendGameData.userData == null)
        {
            BackendGameData.Instance.GameDataInsert();
        }

        BackendGameData.Instance.LevelUp(); // [추가] 로컬에 저장된 데이터를 변경
        BackendGameData.Instance.GameDataUpdate();
        BackendGameData.Instance.GameDataGet();



        BackendRank.instance.RankInsert(DataManager.Instance.currentGold);

        ////BackendGameData.Instance.GameDataGet();


        Debug.Log("테스트를 종료합니다.");
    }
}
