using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VillageState
{
    Waterwheel,
    Windmill,
    Medicine,
    Traders,
    Disease,
    BadWater,
    WaterFilter,
    MagpieThief,
    MagpieDisease,
    MagpieAttack,
    RabidWolves,
    Storm,
    Harvest,
    WitchHunt
}

[Serializable]
public class Village : MonoBehaviour
{
    public int week;
    public int wood;
    public int metal;
    public int naturalProducts;
    public int trust;
    public int prosperity;
    public List<VillageState> villageStates = new List<VillageState>();
    public PlayerProject projectInProgress;
}
