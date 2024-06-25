using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitUIManager : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        DataManager.Instance.CurrentGold -= 1000;
        SceneManager.LoadScene("TitleScene");
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
