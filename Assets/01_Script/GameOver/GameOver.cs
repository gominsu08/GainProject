using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void MenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
