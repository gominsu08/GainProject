using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemySO")]
public class EnemyData : ScriptableObject
{
    [Header("Stat")]
    public int hp;
    /// <summary>
    /// Enemy가 Home으로 들어갔을때 받는 데미지
    /// </summary>
    public int damage;
    /// <summary>
    /// Enemy가 움직이는 속도
    /// </summary>
    public float moveSpeed;
    /// <summary>
    /// Enemy를 잡았을때 얻을수 있는 최대 점수 cost는 Enemy가 생성되고 나서부터 점차 줄어든다
    /// </summary>
    public float cost;
    /// <summary>
    /// Enemy를 잡았을때 얻을 수 있는 골드(재화)
    /// </summary>
    public int gold;
}
