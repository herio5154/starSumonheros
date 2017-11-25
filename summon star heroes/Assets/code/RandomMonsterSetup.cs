using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    [System.Serializable]

public class RandomMonsterSetup  {
    public string Name;
    public int maxMonsters;
    public int monsterApear;
    public float expToGive;
    public int goldToGive;
    public float expErnt;
    public GameObject MonsterTospawn;
    public List<SpawCard> monsterstats = new List<SpawCard>();
}
