using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyDir
{
    up,
    down,
    left,
    right
}
public class EnemyMove : MonoBehaviour
{
    protected Vector3 m_dir = Vector3.right;
    private bool _isDirChange = false;

    private EnemyDir _enemyDirEnum;


    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        _enemyDirEnum = EnemyDir.right;
        m_dir = Vector3.right;
    }
    private void Update()
    {
        transform.position += m_dir * _enemy.speed * Time.deltaTime;
        ColliderCheck();
    }

    private void ColliderCheck()
    {
        if (_enemyDirEnum == EnemyDir.up)
            UpCheck();
        if (_enemyDirEnum == EnemyDir.down)
            DownCheck();
        if (_enemyDirEnum == EnemyDir.left)
            LeftCheck();
        if (_enemyDirEnum == EnemyDir.right)
            RightCheck();
    }

    private void DownCheck()
    {
        if (ColliderCheckDown())
        {
            if (!ColliderCheckLeft())
            {
                m_dir = Vector3.left;
                _enemyDirEnum = EnemyDir.left;
            }
            else if(!ColliderCheckRight())
            {
                m_dir = Vector3.right;
                _enemyDirEnum = EnemyDir.right;
            }

        }
    }

    private void LeftCheck()
    {
        if (ColliderCheckLeft())
        {
            if (!ColliderCheckDown())
            {
                m_dir = Vector3.down;
                _enemyDirEnum = EnemyDir.down;
            }
            else if(!ColliderCheckUp())
            {
                m_dir = Vector3.up;
                _enemyDirEnum = EnemyDir.up;
            }

        }
    }

    private void RightCheck()
    {

        if (ColliderCheckRight())
        {
            if (!ColliderCheckUp())
            {
                m_dir = Vector3.up;
                _enemyDirEnum = EnemyDir.up;
            }
            else if(!ColliderCheckDown())
            {
                m_dir = Vector3.down;
                _enemyDirEnum = EnemyDir.down;

            }

        }

    }

    private void UpCheck()
    {

        if (ColliderCheckUp())
        {
            if (!ColliderCheckLeft())
            {
                m_dir = Vector3.left;
                _enemyDirEnum = EnemyDir.left;
            }
            else if (!ColliderCheckRight())
            {
                m_dir = Vector3.right;
                _enemyDirEnum = EnemyDir.right;
            }
        }

    }

    private bool ColliderCheckUp()
    {
        return Physics2D.Raycast(transform.position, Vector2.up, 0.53f, LayerMask.GetMask("Line"));
    }
    private bool ColliderCheckLeft()
    {
        return Physics2D.Raycast(transform.position, Vector2.left, 0.53f, LayerMask.GetMask("Line"));
    }
    private bool ColliderCheckRight()
    {
        return Physics2D.Raycast(transform.position, Vector2.right, 0.53f, LayerMask.GetMask("Line"));
    }
    private bool ColliderCheckDown()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.53f, LayerMask.GetMask("Line"));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector2.up * 0.53f);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.right * 0.53f);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector2.left * 0.53f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector2.down * 0.53f);
    }
}
