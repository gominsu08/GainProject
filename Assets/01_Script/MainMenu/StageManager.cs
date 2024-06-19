using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using DG.Tweening;

public class StageManager : MonoSingleton<StageManager>
{
    [SerializeField] private GameObject _stageInfo;

    [SerializeField] private TMP_Text _enemyCount;
    [SerializeField] private TMP_Text _waveCount;
    [SerializeField] private TMP_Text _questStage;

    [SerializeField] private TMP_Text _useQuestText;


    private void Awake()
    {
        _useQuestText.text = "";
    }

    public int currentStage = 0;

    public int currentStageInfo = 0;
    public void Stage1Click()
    {
        currentStageInfo = 1;
        _enemyCount.text = "���� ��� ���ͼ� : 40";
        _waveCount.text = "���� ���̺�� : 5";
        _questStage.text = "����Ʈ ���� : ���� ";
        StageInfoSet();
    }

    private void StageInfoSet()
    {
        _stageInfo.transform.DOMove(new Vector2(0,12), 1);
    }

    public void StageIntCheck()
    {
        currentStage = currentStageInfo;
        UseQuest();
        StageInfoExit();
    }

    private void UseQuest()
    {
        _useQuestText.text = "����";
    }

    public void StageInfoExit()
    {
        currentStageInfo = 0;
        _enemyCount.text = "���� ��� ���ͼ� :";
        _waveCount.text = "���� ���̺�� :";
        _questStage.text = "����Ʈ ���� :";
        _stageInfo.transform.position = Vector2.zero;
    }



    public void StageEnter()
    {
        switch (currentStage)
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
