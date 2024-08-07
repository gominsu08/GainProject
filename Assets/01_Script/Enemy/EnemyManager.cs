using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private GameObject _enemyManager;
    [SerializeField] private int[] _enemyCount;
    public int enemySpwanTime = 5;

    public List<EnemyData> enemyDataList = new List<EnemyData>();

    private int index = 0;

    private void Awake()
    {
        StartCoroutine(EnemySpwan());
    }

    private IEnumerator EnemySpwan()
    {
        for (int i = 0; i < _enemyCount[index]; i++)
        {
            GameObject enemy = Instantiate(_enemyPrefab[index], _enemyManager.transform.position, Quaternion.identity, _enemyManager.transform);
            GameManager.Instance.EnemyList.Add(enemy.GetComponent<Enemy>());
            PlayerHP.Instance.PlayerHPAwake(i);
            yield return new WaitForSeconds(0.5f);
        }

        
        yield return new WaitForSeconds(enemySpwanTime);
        index++;
        GameManager.Instance.EnemyList.Clear();
        if (_enemyPrefab.Length >= index+1)
        {
            StartCoroutine(EnemySpwan());
        }
        else
        {
            yield return null;
        }

    }
}
