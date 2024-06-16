using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GatlingGun : Tower
{

    public override void Start()
    {
        StartCoroutine(FireTimeCheck());
    }

    private IEnumerator FireTimeCheck()
    {
        while (true)
        {
            if (m_BulletCount > 12)
            {
                m_IsFireCheck = true;
                yield return new WaitForSeconds(1.5f);
                m_IsFireCheck = false;
                m_BulletCount = 0;

            }
            yield return new WaitForEndOfFrameUnit();
        }
    }

    private void OnDisable()
    {
        m_IsDead = false;
    }
}
