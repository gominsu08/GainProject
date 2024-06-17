using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public enum EnemyDir
{
    up,
    down, 
    left, 
    right
}
public class Enemy : MonoBehaviour
{
    public Action<int> OnEnemyAttack;

    [SerializeField] private EnemyData _enemyData;
    protected Vector3 m_dir = Vector3.right;
    protected int m_EnemyHP = 10;
    protected int m_Damage = 1;
    protected float m_Speed = 3;
    protected float m_gold;
    protected int m_cost;

    private EnemyDir _enemyDir;

    private void Awake()
    {
        m_Damage = _enemyData.damage;
        m_EnemyHP = _enemyData.hp;
        m_Speed = _enemyData.moveSpeed;
        m_gold = _enemyData.gold;
        m_cost = _enemyData.cost;
    }

    private void Start()
    {
        _enemyDir = EnemyDir.right;
        m_dir = Vector3.right;
    }


    public int HP { 
        get => m_EnemyHP; 
        set { 
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
    }


    private void Update()
    {
        transform.position += m_dir * m_Speed * Time.deltaTime;
        ColliderCheck();
    }

    private void ColliderCheck()
    {
        if (_enemyDir == EnemyDir.up)
        {
            if (ColliderCheckUp())
            {
                if (!ColliderCheckLeft())
                {
                    m_dir = Vector3.left;
                    _enemyDir = EnemyDir.left;
                }
                if (!ColliderCheckRight())
                {
                    m_dir = Vector3.right;
                    _enemyDir = EnemyDir.right;
                }
            }
        }

        if (_enemyDir == EnemyDir.down)
        {
            if (ColliderCheckDown())
            {
                if (!ColliderCheckLeft())
                {
                    m_dir = Vector3.left;
                    _enemyDir = EnemyDir.left;
                }
                if (!ColliderCheckRight())
                {
                    m_dir = Vector3.right;
                    _enemyDir = EnemyDir.right;
                }
            }
        }

        if (_enemyDir == EnemyDir.left)
        {
            if (ColliderCheckLeft())
            {
                if (!ColliderCheckUp())
                {
                    m_dir = Vector3.up;
                    _enemyDir = EnemyDir.up;
                }
                if (!ColliderCheckDown())
                {
                    m_dir = Vector3.down;
                    _enemyDir = EnemyDir.down;
                }
            }
        }

        if (_enemyDir == EnemyDir.right)
        {
            if (ColliderCheckRight())
            {
                if (!ColliderCheckUp())
                {
                    m_dir = Vector3.up;
                    _enemyDir = EnemyDir.up;
                }
                if (!ColliderCheckDown())
                {
                    m_dir = Vector3.down;
                    _enemyDir = EnemyDir.down;
                }
            }
        }
    }

    private bool ColliderCheckUp()
    {
        return Physics2D.Raycast(transform.position, Vector2.up, 0.5f, LayerMask.GetMask("Line"));
    }
    private bool ColliderCheckLeft()
    {
        return Physics2D.Raycast(transform.position, Vector2.left, 0.5f, LayerMask.GetMask("Line"));
    }
    private bool ColliderCheckRight()
    {
        return Physics2D.Raycast(transform.position, Vector2.right, 0.5f, LayerMask.GetMask("Line"));
    }
    private bool ColliderCheckDown()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.5f, LayerMask.GetMask("Line"));
    } 
}
