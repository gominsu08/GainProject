using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    protected float m_BulletSpeed;


    public int damage;

    private void Start()
    {
        StartCoroutine(BulletDestroy());
    }

    private IEnumerator BulletDestroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    public virtual void Fire(Vector2 vec, float bulletSpeed)
    {
        this.m_BulletSpeed = bulletSpeed;
        Vector2 dis = vec - (Vector2)transform.position;
        float dir = Mathf.Atan2 (dis.y, dis.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(dir, Vector3.forward);
        
    }

    public virtual void Update()
    {
        transform.position += transform.right * m_BulletSpeed * Time.deltaTime;
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
