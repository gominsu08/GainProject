using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoShop : MonoBehaviour
{
    public void Go()
    {
        SceneManager.LoadScene("ShopScene");
    }
}
