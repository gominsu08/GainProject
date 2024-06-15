using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : Tower
{
    private void OnDisable()
    {
        m_IsDead = false;
    }
}
