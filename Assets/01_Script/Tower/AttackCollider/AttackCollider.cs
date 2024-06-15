using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackCollider : MonoBehaviour
{
    private Tower tower;

    private SpriteRenderer _spriteRenderer;

    private bool _isMouseDown;

    private void Awake()
    {
        tower = GetComponentInParent<Tower>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        tower.OnMouseDown1Event += AttackRangeCheck;
        tower.OnMouseDown2Event += AttackRangeCheckFalse;
    }

    private void AttackRangeCheck()
    {
        _spriteRenderer.enabled = true;
    }

    private void AttackRangeCheckFalse()
    {
        _spriteRenderer.enabled = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            tower.enemyTargetList.Add(collision.gameObject);
            if (!tower.IsFire)
                StartCoroutine(tower.Fire());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            tower.enemyTargetList.Remove(collision.gameObject);
        }
    }
}
