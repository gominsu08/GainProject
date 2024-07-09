using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    public GameObject Light;

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

    public virtual void Fire(Vector2 vec, float bulletSpeed, int damage)
    {
        this.damage = damage;
        m_BulletSpeed = bulletSpeed;
        Vector2 dis = vec - (Vector2)transform.position;
        float dir = Mathf.Atan2 (dis.y, dis.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, dir - 90);
        
    }

    public virtual void Update()
    {
        transform.position += transform.up * m_BulletSpeed * Time.deltaTime;
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().HP -= damage;
            Instantiate(ParticleSystem,transform.position,Quaternion.identity);
            Instantiate(Light, transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
