using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyDirEnum
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

    private EnemyDirEnum _enemyDirEnum;


    private Enemy _enemy;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        _enemyDirEnum = EnemyDirEnum.right;
        m_dir = Vector3.right;
    }
    private void Update()
    {
        if (_enemy.isMove)
            transform.position += m_dir * _enemy.speed * Time.deltaTime;
        Flip();
        ColliderCheck();
    }

    private void Flip()
    {
        if (_enemyDirEnum == EnemyDirEnum.right)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_enemyDirEnum == EnemyDirEnum.left)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void ColliderCheck()
    {
        if (_enemyDirEnum == EnemyDirEnum.up)
            UpCheck();
        if (_enemyDirEnum == EnemyDirEnum.down)
            DownCheck();
        if (_enemyDirEnum == EnemyDirEnum.left)
            LeftCheck();
        if (_enemyDirEnum == EnemyDirEnum.right)
            RightCheck();
    }

    private void DownCheck()
    {
        if (ColliderCheckDown())
        {
            changePosdsition();
            if (!ColliderCheckLeft())
            {
                m_dir = Vector3.left;
                _enemyDirEnum = EnemyDirEnum.left;
            }
            else if (!ColliderCheckRight())
            {
                m_dir = Vector3.right;
                _enemyDirEnum = EnemyDirEnum.right;
            }

        }
    }

    private void LeftCheck()
    {
        if (ColliderCheckLeft())
        {
            changePosdsition();
            if (!ColliderCheckDown())
            {
                m_dir = Vector3.down;
                _enemyDirEnum = EnemyDirEnum.down;
            }
            else if (!ColliderCheckUp())
            {
                m_dir = Vector3.up;
                _enemyDirEnum = EnemyDirEnum.up;
            }

        }
    }

    private void RightCheck()
    {

        if (ColliderCheckRight())
        {
            changePosdsition();
            if (!ColliderCheckUp())
            {
                m_dir = Vector3.up;
                _enemyDirEnum = EnemyDirEnum.up;
            }
            else if (!ColliderCheckDown())
            {
                m_dir = Vector3.down;
                _enemyDirEnum = EnemyDirEnum.down;

            }

        }

    }

    private void UpCheck()
    {

        if (ColliderCheckUp())
        {
            changePosdsition();
            if (!ColliderCheckLeft())
            {
                m_dir = Vector3.left;
                _enemyDirEnum = EnemyDirEnum.left;
            }
            else if (!ColliderCheckRight())
            {
                m_dir = Vector3.right;
                _enemyDirEnum = EnemyDirEnum.right;
            }
        }

    }
    private void changePosdsition()
    {
        transform.position = TilemapManager.Instance.tilemap.GetCellCenterWorld(TilemapManager.Instance.tilemap.WorldToCell(transform.position));
    }
    private bool ColliderCheckUp()
    {
        return Physics2D.Raycast(transform.position, Vector2.up, 0.55f, LayerMask.GetMask("Line"));
    }
    private bool ColliderCheckLeft()
    {
        return Physics2D.Raycast(transform.position, Vector2.left, 0.55f, LayerMask.GetMask("Line"));
    }
    private bool ColliderCheckRight()
    {
        return Physics2D.Raycast(transform.position, Vector2.right, 0.55f, LayerMask.GetMask("Line"));
    }
    private bool ColliderCheckDown()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.55f, LayerMask.GetMask("Line"));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector2.up * 0.55f);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.right * 0.55f);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector2.left * 0.55f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector2.down * 0.55f);
    }
}
