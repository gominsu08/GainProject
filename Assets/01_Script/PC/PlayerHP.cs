using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoSingleton<PlayerHP>
{
    public Stack<GameObject> PlayerHeart = new Stack<GameObject>(); 

    [SerializeField] private GameObject _heartPrefab;
    [SerializeField] private GameObject _heartPanel;
    [SerializeField] private int _playerHp = 10;
    public bool playerDead;

    public void PlayerHPAwake(int index)
    {
        GameManager.Instance.EnemyList[index].OnEnemyAttack += EnemyIn;
    }

    private void Start()
    {
        for (int i = 0; i < _playerHp; i++) 
        {
            PlayerHeart.Push(Instantiate(_heartPrefab,_heartPanel.transform));
        }
    }

    private void EnemyIn(int damage)
    {
        _playerHp -= damage;
        for (int i = 0; i < damage; i++)
        {
            GameObject playerHeart = PlayerHeartPop();

            if (!playerDead)
            {
            Destroy(playerHeart);
            }
            else
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }

    private GameObject PlayerHeartPop()
    {
        if (PlayerHeart.Count > 0)
        {
            return PlayerHeart.Pop();
        }
        else
        {
            playerDead = true;
            return null;
        }
    }
}
