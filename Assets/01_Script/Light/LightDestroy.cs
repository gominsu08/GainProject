using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDestroy : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
