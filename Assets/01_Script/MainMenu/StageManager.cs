using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using DG.Tweening;
using UnityEngine.UI;

public class StageManager : MonoSingleton<StageManager>
{
    [SerializeField] private GameObject _stageInfo;

    [SerializeField] private TMP_Text _enemyCount;
    [SerializeField] private TMP_Text _waveCount;
    [SerializeField] private TMP_Text _questStage;

    [SerializeField] private TMP_Text _useQuestText;

    [SerializeField] private TMP_Text _hunterScore;

    [SerializeField] private List<Button> _gateButton = new List<Button>();


    private void Update()
    {
        _hunterScore.text = $"헌터 점수 : {DataManager.Instance.currentGold}";
        GateSet();
    }

    private void Awake()
    {
        DataManager.Instance.currentStage = 0;
        DataManager.Instance.currentStageInfo = 0;
        DataManager.Instance.quest = "";
        _useQuestText.text = $"{DataManager.Instance.quest}";
        
    }

    private void GateSet()
    {
        for (int i = 0; i < _gateButton.Count; i++)
        {
            if (!DataManager.Instance.StageUse[i])
            {
                _gateButton[i].interactable = false;
                _gateButton[i].image.color = Color.red;
            }
            if (DataManager.Instance.StageUse[i])
            {
                _gateButton[i].interactable = true;
                _gateButton[i].image.color = Color.white;
            }
        }

        for (int i = 0; i < _gateButton.Count; i++)
        {
            if (DataManager.Instance.StageClear[i])
            {
                _gateButton[i].image.color = Color.green;
            }
        }
    }

    public void Stage1Click()
    {
        DataManager.Instance.currentStageInfo = 1;
        DataManager.Instance.quest = "서울";
        DataManager.Instance.waveCount = 5;
        DataManager.Instance.enemyCount = 40;
        SetQuestPanel();
        StageInfoSet();
    }
    public void Stage2Click()
    {
        DataManager.Instance.currentStageInfo = 2;
        DataManager.Instance.quest = "도쿄";
        DataManager.Instance.waveCount = 7;
        DataManager.Instance.enemyCount = 75;
        SetQuestPanel();
        StageInfoSet();
    }

    public void Stage3Click()
    {
        DataManager.Instance.currentStageInfo = 3;
        DataManager.Instance.quest = "베를린";
        DataManager.Instance.waveCount = 12;
        DataManager.Instance.enemyCount = 184;
        SetQuestPanel();
        StageInfoSet();
    }

    public void Stage4Click()
    {
        DataManager.Instance.currentStageInfo = 4;
        DataManager.Instance.quest = "베이징";
        DataManager.Instance.waveCount = 16;
        DataManager.Instance.enemyCount = 240;
        SetQuestPanel();
        StageInfoSet();
    }

    public void Stage5Click()
    {
        DataManager.Instance.currentStageInfo = 5;
        DataManager.Instance.quest = "워싱턴 D.C.";
        DataManager.Instance.waveCount = 21;
        DataManager.Instance.enemyCount = 281;
        SetQuestPanel();
        StageInfoSet();
    }

    public void Stage6Click()
    {
        DataManager.Instance.currentStageInfo = 6;
        DataManager.Instance.quest = "로마";
        DataManager.Instance.waveCount = 25;
        DataManager.Instance.enemyCount = 302;
        SetQuestPanel();
        StageInfoSet();
    }

    public void Stage7Click()
    {
        DataManager.Instance.currentStageInfo = 7;
        DataManager.Instance.quest = "오타와";
        DataManager.Instance.waveCount = 29;
        DataManager.Instance.enemyCount = 325;
        SetQuestPanel();
        StageInfoSet();
    }

    public void Stage8Click()
    {
        DataManager.Instance.currentStageInfo = 8;
        DataManager.Instance.quest = "파리";
        DataManager.Instance.waveCount = 42;
        DataManager.Instance.enemyCount = 649;
        SetQuestPanel();
        StageInfoSet();
    }

    public void SetQuestPanel()
    {
        _enemyCount.text = $"예상 출몰 몬스터수 : {DataManager.Instance.enemyCount}";
        _waveCount.text = $"예상 웨이브수 : {DataManager.Instance.waveCount}";
        _questStage.text = $"퀘스트 구역 : {DataManager.Instance.quest} ";
    }

    private void StageInfoSet()
    {
        _stageInfo.transform.DOMove(new Vector2(0,12), 1).SetEase(Ease.OutBounce);
    }

    public void StageIntCheck()
    {
        DataManager.Instance.currentStage = DataManager.Instance.currentStageInfo;
        UseQuest();
        StageInfoExit();
    }

    private void UseQuest()
    {
        _useQuestText.text = $"{DataManager.Instance.quest}";
    }

    public void StageInfoExit()
    {
        DataManager.Instance.currentStageInfo = 0;
        _enemyCount.text = "예상 출몰 몬스터수 :";
        _waveCount.text = "예상 웨이브수 :";
        _questStage.text = "퀘스트 구역 :";
        _stageInfo.transform.position = Vector2.zero;
    }



    public void StageEnter()
    {
        switch (DataManager.Instance.currentStage)
        {
            case 1:
                SceneManager.LoadScene("Stage1");
                break;
            case 2:
                SceneManager.LoadScene("Stage2");
                break;
            case 3:
                SceneManager.LoadScene("Stage3");
                break;
            case 4:
                SceneManager.LoadScene("Stage4");
                break;
            case 5:
                SceneManager.LoadScene("Stage5");
                break;
            case 6:
                SceneManager.LoadScene("Stage6");
                break;
            case 7:
                SceneManager.LoadScene("Stage7");
                break;
            case 8:
                SceneManager.LoadScene("Stage8");
                break;
            default:
                print("스테이지를 선택해 주세요");
                break;
        }
    }
}
