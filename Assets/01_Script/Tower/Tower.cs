using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;


public abstract class Tower : MonoBehaviour
{
    protected string m_TowerName;
    protected int m_Damage;
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

    public GameObject _fireLight;


    //protected DamageCaster m_Caster;


    [SerializeField] private LayerMask _enemyLayer;

    [SerializeField] private LayerMask _UnitLineLayer;

    public Action OnMouseDown1Event;
    public Action OnMouseDown2Event;

    public bool isFire = false;


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
        m_Damage = _weaponSO.damage;
    }

    public virtual void Start()
    {
        Physics2D.queriesHitTriggers = true;
        m_TowerCollider.radius = m_AttackRange;
    }

    private void Update()
    {
        UnitCollisionCheck();

        RotateTower();

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

    private void RotateTower()
    {
        if (enemyTargetList.Count > 0 && isFire)
        {
            Vector2 dis = enemyTargetList[0].transform.position - transform.position;
            float dir = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
            transform.DORotate(new Vector3(0, 0, dir - 90), 0.2f);
            //transform.rotation = Quaternion.Euler(0, 0, dir - 90);
        }
    }

    public virtual void Fire(Vector2 vector)
    {
        GameObject bullet = Instantiate(m_BulletPrefab);
        Instantiate(_fireLight, transform.position, Quaternion.identity);
        bullet.transform.position = transform.position;
        bullet.GetComponent<Bullet>().Fire(vector, m_BulletSpeed, m_Damage);
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
                try
                {
                    foreach (GameObject item in enemyTargetList)
                    {
                        if (item.IsDestroyed())
                            enemyTargetList.Remove(item.gameObject);
                    }
                }
                catch
                {
                    enemyTargetList = new List<GameObject>();
                    print(enemyTargetList);
                    Debug.LogError("쉬발 이거 뭔 에러냐");
                }
                print("밍");
                if (!m_IsFireCheck && isFire && enemyTargetList.Count > 0)
                {
                    Fire(enemyTargetList[0].transform.position);
                }
            }
            m_BulletCount++;
            yield return new WaitForSeconds(m_CoolTime);
        }
        print(1);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, m_Size);
    }

#endif
}
