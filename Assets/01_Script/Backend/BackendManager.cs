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
    }

    public async void Join()
    {
        await Task.Run(() =>
        {
            if(_nickName.text == "")
                return;

            // 추후 테스트 케이스 추가
            BackendLogin.instance.CustomSignUp($"{_joinID.text}", $"{_joinPW.text}"); // [추가] 뒤끝 회원가입 함수
            BackendGameData.Instance.GameDataInsert();
            BackendRank.instance.RankInsert(0);
            //BackendLogin.Instance.CustomLogin("원하는 이름", "1234");// [추가] 뒤끝 로그인
            BackendLogin.instance.UpdateNickname($"{_nickName.text}"); // [추가] 닉네임 변겅
            Debug.Log("테스트를 종료합니다.");
        });
    }


    public async void Login()
    {
        await Task.Run(() =>
        {
            // 추후 테스트 케이스 추가
            //BackendLogin.Instance.CustomSignUp($"{_JoinID.text}", $"{_JoinPW.text}"); // [추가] 뒤끝 회원가입 함수
            BackendLogin.instance.CustomLogin($"{_loginID.text}", $"{_loginPW.text}");// [추가] 뒤끝 로그인
            BackendGameData.Instance.GameDataGet();
            //BackendLogin.Instance.UpdateNickname("원하는 이름"); // [추가] 닉네임 변겅
            Debug.Log("테스트를 종료합니다.");
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
