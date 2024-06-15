using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Tower
{
    private void OnDisable()
    {
        m_IsDead = false;
    }
}
