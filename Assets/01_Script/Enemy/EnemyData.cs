using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemySO")]
public class EnemyData : ScriptableObject
{
    [Header("Stat")]
    public int hp;
    /// <summary>
    /// Enemy�� Home���� ������ �޴� ������
    /// </summary>
    public int damage;
    /// <summary>
    /// Enemy�� �����̴� �ӵ�
    /// </summary>
    public float moveSpeed;
    /// <summary>
    /// Enemy�� ������� ������ �ִ� �ִ� ���� cost�� Enemy�� �����ǰ� �������� ���� �پ���
    /// </summary>
    public float cost;
    /// <summary>
    /// Enemy�� ������� ���� �� �ִ� ���(��ȭ)
    /// </summary>
    public int gold;
}
