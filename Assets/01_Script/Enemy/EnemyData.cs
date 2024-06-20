using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public float gold;
    /// <summary>
    /// Enemy�� ������� ���� �� �ִ� ���(��ȭ)
    /// </summary>
    public int cost;


    public Sprite enemyImage;
}
