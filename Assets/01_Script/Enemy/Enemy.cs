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
    protected Vector3 m_dir = Vector3.right;
    protected int m_EnemyHP = 10;
    protected int m_Damage = 1;
    protected float m_Speed = 3;

    private void Awake()
    {
        m_Damage = _enemyData.damage;
        m_EnemyHP = _enemyData.hp;
        m_Speed = _enemyData.moveSpeed;
    }


    public int HP { 
        get => m_EnemyHP; 
        set { 
            m_EnemyHP = value;
            if (m_EnemyHP <= 0)
            {
                Destroy(gameObject);
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Home"))
        {
            OnEnemyAttack?.Invoke(m_Damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Right"))
        {
            m_dir = Vector3.right;
        }

        if (collision.gameObject.CompareTag("Up"))
        {
            m_dir = Vector3.up;
        }

        if (collision.gameObject.CompareTag("Down"))
        {
            m_dir = Vector3.down;
        }

        if (collision.gameObject.CompareTag("Left"))
        {
            m_dir = Vector3.left;
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
    }
}
