using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public Action<int> OnEnemyAttack;

    [SerializeField] private EnemyData _enemyData;
    protected int m_EnemyHP = 10;
    protected int m_Damage = 1;
    public float speed = 3;
    protected float m_gold;
    protected int m_cost;


    private void Awake()
    {
        m_Damage = _enemyData.damage;
        m_EnemyHP = _enemyData.hp;
        speed = _enemyData.moveSpeed;
        m_gold = _enemyData.gold;
        m_cost = _enemyData.cost;
    }

    


    public int HP
    {
        get => m_EnemyHP;
        set
        {
            m_EnemyHP = value;
            if (m_EnemyHP <= 0)
            {
                CostManager.Instance.CurrentCost += m_cost;
                Destroy(gameObject);
            }
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP -= collision.gameObject.GetComponent<Bullet>().damage;
        }

        if (collision.gameObject.CompareTag("Home"))
        {
            OnEnemyAttack?.Invoke(m_Damage);
            Destroy(gameObject);
        }
        
    }
}
