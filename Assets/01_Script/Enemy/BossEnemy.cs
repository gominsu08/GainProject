using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    private EnemyManager _enemyManager;
    private Animator _animator;

    [SerializeField] private int _bossSkillCoolTime = 7;
    [SerializeField] private int _bossSkillRange = 7;


    [SerializeField] private ParticleSystem _particleSystem;

    public override void Awake()
    {
        base.Awake();
        _enemyManager = FindObjectOfType<EnemyManager>();
        _animator = GetComponentInChildren<Animator>();

    }

    private void Start()
    {
        _enemyManager.enemySpwanTime = int.MaxValue;
        StartCoroutine(EnemySkill());
    }

    private IEnumerator EnemySkill()
    {
        yield return new WaitForSeconds(_bossSkillCoolTime);
        isMove = false;
        _animator.SetBool("IsAttack", true);
        yield return new WaitForSeconds(0.7f);
        _animator.SetBool("IsAttack", false);
        isMove = true;
        ParticleSystem partocle = Instantiate(_particleSystem);
        partocle.transform.position = transform.position;
        Collider2D[] collider2D = Physics2D.OverlapCircleAll(transform.position, _bossSkillRange , LayerMask.GetMask("Unit"));

        foreach (Collider2D item in collider2D)
        {
            Destroy(item.gameObject);
        }
        StartCoroutine(EnemySkill());
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnStageClearEvent?.Invoke();
        _enemyManager.enemySpwanTime = 0;
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Home"))
        {
            OnEnemyAttack?.Invoke(m_Damage);
            gameObject.SetActive(false);
        }
    }
}
