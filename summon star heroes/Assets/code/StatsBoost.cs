using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class StatsBoost
{
    public enum buffs { Debuff,Buff }
    public string Name;
    public buffs buffkind;
    public StatsKind StatToChnange;
    public int amount;
    public int turnsLeft;
}
