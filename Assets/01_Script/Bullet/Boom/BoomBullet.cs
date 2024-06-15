using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBullet : Bullet
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponentInChildren<DamageCaster>().Attack();
        }
    }
}
