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

    private string _loginIDSave;
    private string _joinIDSave;
    private string _joinPWSave;
    private string _loginPWSave;

    public void JoinDataSave()
    {
        if (_joinID == null || _joinPW == null)
        {
            return;
        }

        _joinIDSave = _joinID.text;
        _joinPWSave = _joinPW.text;
    }

    public void LoginDataSave()
    {

        if (_loginID == null || _loginPW == null)
        {
            return;
        }
        _loginIDSave = _loginID.text;
        _loginPWSave = _loginPW.text;
    }


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
        if (_joinID == null || _joinPW == null)
        {
            return;
        }

        await Task.Run(() =>
        {
            // 추후 테스트 케이스 추가
            BackendLogin.instance.CustomSignUp($"{_joinIDSave}", $"{_joinPWSave}"); // [추가] 뒤끝 회원가입 함수
            
            //BackendLogin.Instance.CustomLogin("원하는 이름", "1234");// [추가] 뒤끝 로그인
            //BackendLogin.Instance.UpdateNickname("원하는 이름"); // [추가] 닉네임 변겅
            Debug.Log("테스트를 종료합니다.");
        });
    }


    public async void Login()
    {
        if (_loginID == null || _loginPW == null)
        {
            return;
        }

        await Task.Run(() =>
        {
            // 추후 테스트 케이스 추가
            //BackendLogin.Instance.CustomSignUp($"{_JoinID.text}", $"{_JoinPW.text}"); // [추가] 뒤끝 회원가입 함수
            BackendLogin.instance.CustomLogin($"{_loginIDSave}", $"{_loginPWSave}");// [추가] 뒤끝 로그인
            //BackendLogin.Instance.UpdateNickname("원하는 이름"); // [추가] 닉네임 변겅
            Debug.Log("테스트를 종료합니다.");
        });
    }

    private void Update()
    {
        if (BackendLogin.instance.isLogin)
            SceneManager.LoadScene("MenuScene");
        if (BackendLogin.instance.isJoin)
            SceneManager.LoadScene("MenuScene");
    }
}
