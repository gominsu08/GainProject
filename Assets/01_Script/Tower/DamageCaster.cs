using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DamageCaster : MonoBehaviour
{
    [SerializeField] private float radius = 1f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private int BoomDamage;

    [SerializeField] private ParticleSystem boomParticleSystem;

    public void Attack()
    {
        ParticleSystem particle =  Instantiate(boomParticleSystem, transform.position,Quaternion.identity);
        Collider2D[] enemy = Physics2D.OverlapCircleAll(transform.position,radius, enemyLayer);

        if (enemy.Length > 0)
        {
            foreach (Collider2D item in enemy)
            {
                item.gameObject.GetComponent<Enemy>().HP -= BoomDamage;
            }
        }
        
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position,radius);
    }
#endif
}
