using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;


public abstract class Tower : MonoBehaviour
{
    protected string m_TowerName;
    protected float m_CoolTime;
    public int cost;
    protected float m_AttackRange;
    protected bool m_IsDead;
    protected int m_BulletSpeed;
    protected GameObject m_BulletPrefab;
    protected CircleCollider2D m_TowerCollider;
    protected GameObject m_Enemy;
    public bool IsFire;
    protected Vector2 m_Size;

    protected int m_BulletCount;
    protected bool m_IsFireCheck;


    //protected DamageCaster m_Caster;


    [SerializeField] private LayerMask _enemyLayer;

    [SerializeField] private LayerMask _UnitLineLayer;

    public Action OnMouseDown1Event;
    public Action OnMouseDown2Event;

    [field: SerializeField] public TowerData _weaponSO { get; private set; }

    public List<GameObject> enemyTargetList = new List<GameObject>();
    [SerializeField] private float radius = 0.5f;


    public bool isUnitCheck;

    public virtual void Awake()
    {
        m_BulletSpeed = _weaponSO.bulletSpeed;
        m_CoolTime = _weaponSO.coolTime;
        cost = _weaponSO.cost;
        m_AttackRange = _weaponSO.attackRange;
        m_TowerName = _weaponSO.towerName;
        m_BulletPrefab = _weaponSO.bulletPrefab;
        m_TowerCollider = _weaponSO.towerCollider;
        m_Size = _weaponSO.size;
    }

    public virtual void Start()
    {
        Physics2D.queriesHitTriggers = true;
        m_TowerCollider.radius = m_AttackRange;
    }

    private void Update()
    {
        UnitCollisionCheck();

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            float distance = (mousePos - transform.position).magnitude;

            if (distance <= radius)
            {
                OnMouseDown1Event?.Invoke();
            }
            else if (distance > radius)
            {
                OnMouseDown2Event?.Invoke();
            }
        }
    }
    public virtual void Fire(Vector2 vector)
    {
        GameObject bullet = Instantiate(m_BulletPrefab);
        bullet.transform.position = transform.position;
        bullet.GetComponent<Bullet>().Fire(vector, m_BulletSpeed);
    }

    private void UnitCollisionCheck()
    {
        
        if (Physics2D.OverlapBox(transform.position, m_Size, 0, _UnitLineLayer))
        {
            isUnitCheck = true;
        }
        else
        {
            isUnitCheck = false;
        }
    }


    public IEnumerator Fire()
    {
        IsFire = true;
        while (!m_IsDead)
        {
            if (enemyTargetList.Count > 0)
            {
                if (enemyTargetList[0].gameObject.IsDestroyed())
                {
                    enemyTargetList.Remove(enemyTargetList[0].gameObject);
                }
                if(!m_IsFireCheck)
                Fire(enemyTargetList[0].transform.position);
            }
            m_BulletCount++;
            yield return new WaitForSeconds(m_CoolTime);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, m_Size);
    }

#endif
}
