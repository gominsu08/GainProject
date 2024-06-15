using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/TowerSO")]
public class TowerData : ScriptableObject
{
    [Header("Tower Name")]
    public string towerName;

    [Header("Tower State")]
    public float coolTime;
    public int cost;
    public float attackRange;
    public float towerArea;
    public int bulletSpeed;

    [Header("Bullet Prefab")]
    public GameObject bulletPrefab;

    [Header("Tower Collider")]
    public CircleCollider2D towerCollider;
}
