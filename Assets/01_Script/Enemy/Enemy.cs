using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Enemy : MonoBehaviour
{
    public Action<int> OnEnemyAttack;

    [SerializeField] private EnemyData _enemyData;
    protected int m_EnemyHP = 10;
    protected int m_Damage = 1;
    public float speed = 3;
    protected float m_Gold;
    protected int m_Cost;


    public bool isGoldCount = true;

    public bool isMove = true;
    public virtual void Awake()
    {
        m_Damage = _enemyData.damage;
        m_EnemyHP = _enemyData.hp;
        speed = _enemyData.moveSpeed;
        m_Gold = _enemyData.gold;
        m_Cost = _enemyData.cost;
    }

    private void Update()
    {
        GoldCount();
    }

    private void GoldCount()
    {
        if (isGoldCount)
        {
            Gold -= 0.001f;
        }
    }

    public float Gold
    {
        get => m_Gold;


        set
        {
            if (value <= 0)
            {
                isGoldCount = false;
                m_Gold = 0;
            }
            else
            {
                m_Gold = value;
            }
        }
    }

    public int HP
    {
        get => m_EnemyHP;
        set
        {
            m_EnemyHP = value;
            if (m_EnemyHP <= 0)
            {
                CostManager.Instance.CurrentCost += m_Cost;
                DataManager.Instance.currentGold += m_Gold;
                Destroy(gameObject);
            }
        }

    }



    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Home"))
        {
            OnEnemyAttack?.Invoke(m_Damage);
            Destroy(gameObject);
        }
        
    }
}
