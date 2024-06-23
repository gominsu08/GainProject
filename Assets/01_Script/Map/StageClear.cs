using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;


public class StageClear : MonoSingleton<StageClear>
{
    [SerializeField] private GameObject clearPanel;
    private RectTransform _rectTrm;

    [SerializeField] private int clearItemCount;

    [SerializeField] private TMP_Text ItemText;
    [SerializeField] private TMP_Text hunterScoreText;
    [SerializeField] private TMP_Text TimeText;

    private float clearTime;

    private void Update()
    {
        clearTime += Time.deltaTime;
    }

    private int enemyDead;

    private void Awake()
    {
        DataManager.Instance.quest = "";
        _rectTrm = clearPanel.transform as RectTransform;
    }

    private void Start()
    {
        GameManager.Instance.OnStageClearEvent += Clear;
    }

    public void Clear()
    {
        DataManager.Instance.haveManaStone = clearItemCount;
        DataManager.Instance.manaStone += DataManager.Instance.haveManaStone;
        ItemText.text = $"얻은 정수 : {DataManager.Instance.haveManaStone}개";
        hunterScoreText.text = $"헌터 점수 : {DataManager.Instance.currentGold}";
        TimeText.text = $"클리어 시간 : {(int)clearTime}초";
        StartCoroutine(CealrPanel());
        DataManager.Instance.StageClear[DataManager.Instance.currentStage - 1] = true;
        DataManager.Instance.StageUse[DataManager.Instance.currentStage] = true;
    }

    private IEnumerator CealrPanel()
    {
        yield return new WaitForSeconds(0.5f);
        //clearPanel.transform.DOMoveY(-5f, 1);
        _rectTrm.DOAnchorPosY(0f, 1f).SetEase(Ease.OutBounce);
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
