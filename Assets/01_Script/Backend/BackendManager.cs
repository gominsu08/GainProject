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
        
        Test();
    }

    async void Test()
    {
        await Task.Run(() => {
            // 추후 테스트 케이스 추가
            //BackendLogin.Instance.CustomSignUp("user1", "1234"); // [추가] 뒤끝 회원가입 함수
            BackendLogin.Instance.CustomLogin("원하는 이름", "1234");// [추가] 뒤끝 로그인
            //BackendLogin.Instance.UpdateNickname("원하는 이름"); // [추가] 닉네임 변겅
            Debug.Log("테스트를 종료합니다.");
        });
    }
    
}
