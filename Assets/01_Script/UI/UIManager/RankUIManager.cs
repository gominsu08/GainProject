using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using BackEnd;
using System.Text;
using UnityEngine.AI;
using DG.Tweening;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class RankUIManager : MonoBehaviour
{
    [SerializeField] private RectTransform Panel;

    [SerializeField] private TMP_Text _myRank;

    [SerializeField] private List<TMP_Text> RankList = new List<TMP_Text>();

    LitJson.JsonData rankDataJson;


    private List<string> nickname;

    public void PanelSet()
    {
        Panel.DOAnchorPosY(0, 1).SetEase(Ease.OutBounce);
    }

    public void PanelReset()
    {
        Panel.anchoredPosition = new Vector2(0, 1500);
    }

    public void RankSet()
    {
        BackendRank.instance.RankGet(); // [추가] 랭킹 불러오기 함수

        nickname = new List<string>();

        var collback = Backend.URank.User.GetRankList("07789e20-31bd-11ef-bb11-23afd11345db", 13);

        if (collback.IsSuccess())
        {
            Debug.Log($" 랭킹 조회에 성공하였습니다 : {collback}");

            rankDataJson = collback.FlattenRows();

            if (rankDataJson.Count <= 0)
            {
                for (int i = 0; i < 11; i++)
                {
                    Rank(i,"???");
                }

                Debug.Log("현재 데이터가 존재하지 않습니다");
            }
            else
            {
                Debug.Log(rankDataJson[0]["score"]);
                for (int i = 0; i < 11; i++)
                {
                    try
                    {
                        Rank(i, rankDataJson[i]?.ContainsKey("nickname") == true ? rankDataJson[i]["nickname"]?.ToString() : "???");
                    }
                    catch
                    {
                        Rank(i,"???");
                    }
                }

            }
        }
    }

    public void Rank(int i, string name)
    {
        
        switch (i + 1)
        {
            case 1:
                RankList[i].text = $"국가권력급  :  {name}  /  헌터 점수 : {rankDataJson[0]["score"]}";
                break;
            case 2:
                RankList[i].text = $"S급 1위  :  {name}";
                break;
            case 3:
                RankList[i].text = $"S급 2위  :  {name}";
                break;
            case 4:
                RankList[i].text = $"S급 3위  :  {name}";
                break;
            case 5:
                RankList[i].text = $"A급 1위  :  {name}";
                break;
            case 6:
                RankList[i].text = $"A급 2위  :  {name}";
                break;
            case 7:
                RankList[i].text = $"A급 3위  :  {name}";
                break;
            case 8:
                RankList[i].text = $"A급 4위  :  {name}";
                break;
            case 9:
                RankList[i].text = $"A급 5위  :  {name}";
                break;
            case 10:
                RankList[i].text = $"B급 1위  :  {name}";
                break;
            case 11:
                RankList[i].text = $"B급 2위  :  {name}";
                break;
            default: break;
        }
    }
}
