using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField] private PoolListSO _poolList;

    private Dictionary<string, Pool> _pools;

    private void Awake()
    {
        _pools = new Dictionary<string, Pool>();
        foreach (PoolItemSO so in _poolList.list)
        {
            CretePool(so);
        }
    }

    private void CretePool(PoolItemSO so)
    {
        Ipoolable poolable = so.prefab.GetComponent<Ipoolable>();
        if (poolable == null)
        {
            Debug.LogWarning($"GameObject {so.prefab.name} has no Ipoolable Script");
            return;
        }

        Pool pool = new Pool(poolable, transform, so.count);
        _pools.Add(poolable.PoolName,pool);
    }

    public Ipoolable Pop(string itemName)
    {
        if (_pools.ContainsKey(itemName))
        {
            Ipoolable item = _pools[itemName].Pop();
            item.ResetItem();
            return item;
        }
        Debug.LogError($"There is no pool {itemName}");
        return null;
    }

    public void Push(Ipoolable item)
    {
        if (_pools.ContainsKey(item.PoolName))
        {
            _pools[item.PoolName].Push(item);
            return;
        }

        Debug.LogError($"There is no pool {item.PoolName}");
    }
}
