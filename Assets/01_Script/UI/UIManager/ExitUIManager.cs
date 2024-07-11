using DG.Tweening;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitUIManager : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private GameObject _penal;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _rectTransform != null)
        {
            PanelSet();
        }
    }

    public void PanelSet()
    {
        _rectTransform.DOAnchorPosY(0,1).SetEase(Ease.OutBounce);
    }

    public void PanelExit()
    {
        _rectTransform.DOAnchorPosY(1500, 1).SetEase(Ease.OutBounce);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void TitleExit()
    {
        DataManager.Instance.CurrentGold -= 5000;
        SceneManager.LoadScene("TitleScene");
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Exit()
    {
        _penal.SetActive(false);
    }
}
