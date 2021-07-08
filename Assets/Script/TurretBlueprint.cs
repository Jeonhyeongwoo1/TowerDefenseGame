using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmout()
    {
        return cost / 2;
    }
    
}
