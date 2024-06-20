using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class StageClear : MonoBehaviour
{
    [SerializeField] private GameObject clearPanel;
    private RectTransform _rectTrm;

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
