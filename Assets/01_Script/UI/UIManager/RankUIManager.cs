using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using BackEnd;
using System.Text;
using UnityEngine.AI;
using DG.Tweening;
using UnityEngine.SocialPlatforms.Impl;

public class RankUIManager : MonoBehaviour
{
    [SerializeField] private RectTransform Panel;

    [SerializeField] private TMP_Text _myRank;

    [SerializeField] private List<TMP_Text> RankList = new List<TMP_Text>();

    LitJson.JsonData rankDataJson;


    private List<string> nickname;

    private void Update()
    {
        _myRank.text = BackendRank.instance.myRank;
    }

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
        nickname = new List<string>();

        var collback = Backend.URank.User.GetRankList("b959c130-30ac-11ef-8960-0b7bd9c413a8", 13);

        if (collback.IsSuccess())
        {
            Debug.Log($" ��ŷ ��ȸ�� �����Ͽ����ϴ� : {collback}");

            rankDataJson = collback.FlattenRows();

            if (rankDataJson.Count <= 0)
            {
                for (int i = 0; i < 11; i++)
                {
                    Rank(i,"???");
                }

                Debug.Log("���� �����Ͱ� �������� �ʽ��ϴ�");
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
                RankList[i].text = $"�����Ƿ±�  :  {name}  /  ���� ���� : {rankDataJson[0]["score"]}";
                break;
            case 2:
                RankList[i].text = $"S�� 1��  :  {name}";
                break;
            case 3:
                RankList[i].text = $"S�� 2��  :  {name}";
                break;
            case 4:
                RankList[i].text = $"S�� 3��  :  {name}";
                break;
            case 5:
                RankList[i].text = $"A�� 1��  :  {name}";
                break;
            case 6:
                RankList[i].text = $"A�� 2��  :  {name}";
                break;
            case 7:
                RankList[i].text = $"A�� 3��  :  {name}";
                break;
            case 8:
                RankList[i].text = $"A�� 4��  :  {name}";
                break;
            case 9:
                RankList[i].text = $"A�� 5��  :  {name}";
                break;
            case 10:
                RankList[i].text = $"B�� 1��  :  {name}";
                break;
            case 11:
                RankList[i].text = $"B�� 2��  :  {name}";
                break;
            default: break;
        }
    }
}
