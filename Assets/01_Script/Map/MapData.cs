using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/MapData")]
public class MapData : ScriptableObject
{
    public List<GameObject> MapList = new List<GameObject>();
}
