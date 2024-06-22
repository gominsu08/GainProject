using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/TowerSO")]
public class TowerData : ScriptableObject
{
    [Header("Tower Name")]
    public string towerName;

    [Header("Tower State")]
    public int damage;
    public float coolTime;
    public int cost;
    public Vector2 size;
    public float attackRange;
    public int bulletSpeed;

    [Header("Bullet Prefab")]
    public GameObject bulletPrefab;

    [Header("Tower Collider")]
    public CircleCollider2D towerCollider;
}
