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

    public void Join()
    {
        string text = _nickName.text;
        string pattern = @"sex|섹스|야스|Se스|섹s|Sex|SEx|SEX|SeX|sEx|seX|자지|보지|야1스|섹1스|//|자1지|보1지|크래파스|니엄마|니엄|엄마|시발
|개새끼|민수게이|게이|gay|Gay|tlqkf|퍼리|로리|니미|병신|qudtls|tlqkf년|년|애미|애1미|아1미|ㄴ1미|니1ㅁ1|니애미|ㄴ1애미|한남|한녀|이기야|운지|노무
|누무|ㅗ|자살|자1살|앰뒤|련|911|523|한남유충|재기|재1기|한남1유충|5조5억|니거|니1거|nigger|응디|히틀러|나치|극우|극좌|하일|우파|좌파|창녀|창남|어미
|벌래새끼|벌래년|벌래자식|자해|자위|자1위|대딸|장애련|장애새끼|일베충|일베|메갈리아|메갈|여시|여성시대|워마드|DC충|버러지|장애|소추|핫걸";

        string replaced = Regex.Replace(text, pattern, "***");


        _nickName.text = replaced;

        if (_joinID.text == _nickName.text)
        {
            _joinErrorMessage.text = "ID와 name을 다르게 지어주세요";
            return;
        }
        try
        {
            int i = int.Parse(_joinID.text);
            try
            {
                int j = int.Parse(_nickName.text);
                _joinErrorMessage.text = "ID와 name에 문자가 포함되어 있지 않습니다";
                Debug.LogError("ID와 name에 문자가 포함되어 있지 않습니다");
            }
            catch
            {
                _joinErrorMessage.text = "ID에 문자가 포함되어 있지 않습니다";
                Debug.LogError("ID에 문자가 포함되어 있지 않습니다");
            }
        }
        catch
        {
            if (_joinID.text.Split(" ").Length > 1)
            {
                if (_nickName.text.Split(" ").Length > 1)
                {
                    _joinErrorMessage.text = "ID와 name에 띄어쓰기가 포함되어 있습니다";
                    Debug.LogError("ID와 name에 띄어쓰기가 포함되어 있습니다");
                    return;
                }
                _joinErrorMessage.text = "ID에 띄어쓰기가 포함되어 있습니다";
                Debug.LogError("ID에 띄어쓰기가 포함되어 있습니다");
                return;
            }
            try
            {
                int j = int.Parse(_nickName.text);
                _joinErrorMessage.text = "name에 문자가 포함되어 있지 않습니다";
                Debug.LogError("name에 문자가 포함되어 있지 않습니다");
            }
            catch
            {
                if (_nickName.text.Split(" ").Length > 1)
                {
                    _joinErrorMessage.text = "name에 띄어쓰기가 포함되어 있습니다";
                    Debug.LogError("name에 띄어쓰기가 포함되어 있습니다");
                    return;
                }
                BackendReturnObject bro = Backend.BMember.CustomSignUp(_joinID.text, _joinPW.text);
                if (bro.IsSuccess())
                {
                    _joinErrorMessage.text = "회원가입에 성공했습니다";
                    Debug.Log("회원가입에 성공했습니다");
                    SceneManager.LoadScene("MenuScene");
                    var bro2 = Backend.BMember.UpdateNickname(_nickName.text);

                    if (bro2.IsSuccess())
                    {
                        Debug.Log("닉네임 변경에 성공했습니다 : " + bro2);
                        BackendGameData.Instance.GameDataInsert();
                    }
                    else
                    {
                        Debug.LogError("닉네임 변경에 실패했습니다 : " + bro2);
                    }
                }
            }
        }


        //return;

        //if (_nickName.text == "")
        //    return;

        //// 추후 테스트 케이스 추가
        //BackendLogin.instance.CustomSignUp($"{_joinID.text}", $"{_joinPW.text}"); // [추가] 뒤끝 회원가입 함수
        //BackendLogin.instance.UpdateNickname($"{_nickName.text}"); // [추가] 닉네임 변겅
        //BackendGameData.Instance.GameDataInsert();
        ////BackendLogin.Instance.CustomLogin("원하는 이름", "1234");// [추가] 뒤끝 로그인
        //Debug.Log("테스트를 종료합니다.");
    }


    public void Login()
    {
        // 추후 테스트 케이스 추가
        //BackendLogin.Instance.CustomSignUp($"{_JoinID.text}", $"{_JoinPW.text}"); // [추가] 뒤끝 회원가입 함수
        BackendReturnObject bro = Backend.BMember.CustomLogin(_loginID.text, _loginPW.text);
        if (bro.IsSuccess())
        {
            Debug.Log("로그인에 성공했습니다");
            _loginErrorMessage.text = "로그인에 성공했습니다";
            BackendGameData.Instance.GameDataGet();
            SceneManager.LoadScene("MenuScene");
        }
        else
        {
            Debug.LogError("로그인에 실패 하였습니다");
            _loginErrorMessage.text = "로그인에 실패했습니다";

        }
        //BackendLogin.instance.CustomLogin($"{_loginID.text}", $"{_loginPW.text}");// [추가] 뒤끝 로그인

        //BackendLogin.Instance.UpdateNickname("원하는 이름"); // [추가] 닉네임 변겅
        Debug.Log("테스트를 종료합니다.");
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
