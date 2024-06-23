using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Tower
{
    [SerializeField] private float minAngle = -10;
    [SerializeField] private float maxAngle = 10;

    public override void Fire(Vector2 vector)
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject bullet = Instantiate(m_BulletPrefab,transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().Fire(vector.normalized,m_BulletSpeed,m_Damage);
            Vector2 newDirection = Quaternion.Euler(new Vector3(0, 0, Random.Range(minAngle, maxAngle))) * vector;
            bullet.GetComponent<Bullet>().Fire(newDirection, m_BulletSpeed, m_Damage);
        }
    }

    private void OnDisable()
    {
        m_IsDead = true;
    }
}
