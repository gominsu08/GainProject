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
        _hunterScore.text = $"���� ���� : {DataManager.Instance.currentGold}";
    }

    private void Awake()
    {
        DataManager.Instance.currentStage = 0;
        DataManager.Instance.currentStageInfo = 0;
        DataManager.Instance.quest = "";
        _useQuestText.text = $"{DataManager.Instance.quest}";
        GateSet();
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
        DataManager.Instance.quest = "����";
        DataManager.Instance.waveCount = 5;
        DataManager.Instance.enemyCount = 40;
        SetQuestPanel();
        StageInfoSet();
    }
    public void Stage2Click()
    {
        DataManager.Instance.currentStageInfo = 2;
        DataManager.Instance.quest = "����";
        DataManager.Instance.waveCount = 7;
        DataManager.Instance.enemyCount = 75;
        SetQuestPanel();
        StageInfoSet();
    }

    public void SetQuestPanel()
    {
        _enemyCount.text = $"���� ��� ���ͼ� : {DataManager.Instance.enemyCount}";
        _waveCount.text = $"���� ���̺�� : {DataManager.Instance.waveCount}";
        _questStage.text = $"����Ʈ ���� : {DataManager.Instance.quest} ";
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
        _enemyCount.text = "���� ��� ���ͼ� :";
        _waveCount.text = "���� ���̺�� :";
        _questStage.text = "����Ʈ ���� :";
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
            default:
                print("���������� ������ �ּ���");
                break;
        }
    }
}
