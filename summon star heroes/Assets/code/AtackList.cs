using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class AtackList
{
    
    public string MoveName;
    public string MoveText;
    public string monsterMoveInforamation;
    public majic Element;
    public float Hit;
    public movekind moveKind;
    [Tooltip("0 one target,0 All")]
    public targetKind [] Target;  
    public int MoveID;
    public float Atack;
    public float Cost;
     public bool Buff;
    public bool mutable;
    public GameObject AttckPrefab;
    public List<StatsBoost> buffDebuff = new List<StatsBoost>();
}

