using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using UnityEngine.SceneManagement;

public class BackendLogin : MonoBehaviour
{
    public static BackendLogin _instance;

    public static BackendLogin Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BackendLogin();
                Debug.Log("new single nyamni");
            }

            return _instance;
        }
    }

    public bool isLogin = false;
    public bool isJoin;

    public void CustomSignUp(string id, string pw)
    {
        // Step 2. 회원가입 구현하기 로직
        Debug.Log("회원가입을 요청합니다.");

        var bro = Backend.BMember.CustomSignUp(id, pw);


        if (bro.IsSuccess())
        {
            Debug.Log("회원가입에 성공했습니다. : " + bro);
            SceneManager.LoadScene("MenuScene");
            isJoin = true;
            print(isJoin);
        }
        else
        {
            Debug.LogError("회원가입에 실패했습니다. : " + bro);
        }
    }

    
    public void CustomLogin(string id, string pw)
    {
        // Step 3. 로그인 구현하기 로직
        Debug.Log("로그인을 요청합니다.");

        var bro = Backend.BMember.CustomLogin(id, pw);

        Debug.Log(1);
        if (bro.IsSuccess())
        {
            Debug.Log("로그인이 성공했습니다. : " + bro);
            
            isLogin = true;
            print(isLogin);
        }
        else
        {
            Debug.LogError("로그인이 실패했습니다. : " + bro);
        }
    }

    public void UpdateNickname(string nickname)
    {
        // Step 4. 닉네임 변경 구현하기 로직
        Debug.Log("닉네임 변경을 요청합니다.");

        var bro = Backend.BMember.UpdateNickname(nickname);

        if (bro.IsSuccess())
        {
            Debug.Log("닉네임 변경에 성공했습니다 : " + bro);
        }
        else
        {
            Debug.LogError("닉네임 변경에 실패했습니다 : " + bro);
        }
    }
}
