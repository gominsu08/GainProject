using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
