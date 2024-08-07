using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BackEnd;
using System.Text;

public class UserData
{
    public float cost = 0;
    public int useStage = 0;
    public int clearStage = 0;
    public int manaStone = 0;
    public string info = string.Empty;

    // 데이터를 디버깅하기 위한 함수입니다.(Debug.Log(UserData);)
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"cost : {cost}");
        result.AppendLine($"UseStage : {useStage}");
        result.AppendLine($"ClearStage : {clearStage}");
        result.AppendLine($"ManaStone : {manaStone}");

        return result.ToString();
    }
}

public class BackendGameData
{
    private static BackendGameData _instance = null;

    public static BackendGameData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BackendGameData();
            }

            return _instance;
        }
    }

    public static UserData userData;

    private string gameDataRowInDate = string.Empty;

    public void GameDataInsert()
    {
        if (userData == null)
        {
            userData = new UserData();
        }

        Debug.Log("데이터를 초기화합니다.");
        userData.cost = 0;
        userData.useStage = 0;
        userData.clearStage = 0;
        userData.manaStone = 0;

        Debug.Log("뒤끝 업데이트 목록에 해당 데이터들을 추가합니다.");
        Param param = new Param();
        param.Add("cost", userData.cost);
        param.Add("UseStage", userData.useStage);
        param.Add("ClearStage", userData.clearStage);
        param.Add("ManaStone", userData.manaStone);


        Debug.Log("게임 정보 데이터 삽입을 요청합니다.");
        var bro = Backend.GameData.Insert("SCORE_DATA", param);

        if (bro.IsSuccess())
        {
            Debug.Log("게임 정보 데이터 삽입에 성공했습니다. : " + bro);

            //삽입한 게임 정보의 고유값입니다.  
            gameDataRowInDate = bro.GetInDate();
        }
        else
        {
            Debug.LogError("게임 정보 데이터 삽입에 실패했습니다. : " + bro);
        }
    }
    public void GameDataGet()
    {
        Debug.Log("게임 정보 조회 함수를 호출합니다.");
        var bro = Backend.GameData.GetMyData("SCORE_DATA", new Where());
        if (bro.IsSuccess())
        {
            Debug.Log("게임 정보 조회에 성공했습니다. : " + bro);


            LitJson.JsonData gameDataJson = bro.FlattenRows(); // Json으로 리턴된 데이터를 받아옵니다.  

            // 받아온 데이터의 갯수가 0이라면 데이터가 존재하지 않는 것입니다.  
            if (gameDataJson.Count <= 0)
            {
                Debug.LogWarning("데이터가 존재하지 않습니다.");
            }
            else
            {
                gameDataRowInDate = gameDataJson[0]["inDate"].ToString(); //불러온 게임 정보의 고유값입니다.  

                userData = new UserData();

                userData.cost = float.Parse(gameDataJson[0]["cost"].ToString());
                userData.useStage = int.Parse(gameDataJson[0]["UseStage"].ToString());
                userData.clearStage = int.Parse(gameDataJson[0]["ClearStage"].ToString());
                userData.manaStone = int.Parse(gameDataJson[0]["ManaStone"].ToString());

                Debug.Log(userData + "값");

                DataManager.Instance.currentGold = userData.cost;
                DataManager.Instance.clearStage = userData.clearStage;
                DataManager.Instance.useStage = userData.useStage;
                DataManager.Instance.manaStone = userData.manaStone;

            }
        }
        else
        {
            Debug.LogError("게임 정보 조회에 실패했습니다. : " + bro);
        }
    }

    public void LevelUp()
    {
        Debug.Log("헌터 점수를 확인합니다.");
        userData.cost = DataManager.Instance.currentGold;
        userData.useStage = DataManager.Instance.useStage;
        userData.clearStage = DataManager.Instance.clearStage;
        userData.manaStone = DataManager.Instance.manaStone;
    }

    // 게임 정보 수정하기
    public void GameDataUpdate()
    {
        if (userData == null)
        {
            Debug.LogError("서버에서 다운받거나 새로 삽입한 데이터가 존재하지 않습니다. Insert 혹은 Get을 통해 데이터를 생성해주세요.");
            return;
        }

        Param param = new Param();
        param.Add("cost", userData.cost);
        param.Add("UseStage", userData.useStage);
        param.Add("ClearStage", userData.clearStage);
        param.Add("ManaStone", userData.manaStone);

        BackendReturnObject bro = null;

        if (string.IsNullOrEmpty(gameDataRowInDate))
        {
            Debug.Log("내 제일 최신 게임 정보 데이터 수정을 요청합니다.");

            bro = Backend.GameData.Update("SCORE_DATA", new Where(), param);
        }
        else
        {
            Debug.Log($"{gameDataRowInDate}의 게임 정보 데이터 수정을 요청합니다.");

            bro = Backend.GameData.UpdateV2("SCORE_DATA", gameDataRowInDate, Backend.UserInDate, param);
        }

        if (bro.IsSuccess())
        {
            Debug.Log("게임 정보 데이터 수정에 성공했습니다. : " + bro);
        }
        else
        {
            Debug.LogError("게임 정보 데이터 수정에 실패했습니다. : " + bro);
        }
    }
}
