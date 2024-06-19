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
        if (_JoinID == null || _JoinPW == null)
        {
            return;
        }

        await Task.Run(() =>
        {
            // 추후 테스트 케이스 추가
            BackendLogin.instance.CustomSignUp($"{_JoinID.text}", $"{_JoinPW.text}"); // [추가] 뒤끝 회원가입 함수
            //BackendLogin.Instance.CustomLogin("원하는 이름", "1234");// [추가] 뒤끝 로그인
            //BackendLogin.Instance.UpdateNickname("원하는 이름"); // [추가] 닉네임 변겅
            Debug.Log("테스트를 종료합니다.");
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
            // 추후 테스트 케이스 추가
            //BackendLogin.Instance.CustomSignUp($"{_JoinID.text}", $"{_JoinPW.text}"); // [추가] 뒤끝 회원가입 함수
            BackendLogin.instance.CustomLogin($"{_LoginID.text}", $"{_LoginPW.text}");// [추가] 뒤끝 로그인
            //BackendLogin.Instance.UpdateNickname("원하는 이름"); // [추가] 닉네임 변겅
            Debug.Log("테스트를 종료합니다.");
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
