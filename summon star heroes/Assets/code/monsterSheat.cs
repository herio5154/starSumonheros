using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum majic { NA, Fire, Ice,Water, Ground,Grass, Wind , Mind}
public enum battleKInds { noraml,boss,MidBoss}

public class monsterSheat : MonoBehaviour {
    public string Name;
    public int maxSPawn;
    public battleKInds kindofBattle;
    public int MidBossID;
     public int outcome;
    public int stage;
     public float ExpToGive;
    public int LevleTObosst;
     public int level;
    public int bost;
    public int Gold;     
    public string stagetoGoback;
    public AudioClip soundtrack;
     public PlayerMemory memory;
    public int odds;
    public int randomCard;
    public stasM cards;
    public List<SpawCard> monstersToSpawn = new List<SpawCard>();
    public List<unitStats> UnitStats = new List<unitStats>();
    public List<slots> Monstercards = new List<slots>();
    static bool onlyOne;
    void OnEnable()
    {
        if (onlyOne == true)
        {
            Debug.Log("yo");
        }
        if (onlyOne == false)
        {
            onlyOne = true;
        }
       
        cards = FindObjectOfType<stasM>();
        memory = FindObjectOfType<PlayerMemory>();
 

        for (int I = 0; I <odds; I++ )
        {
            randomCard = Random.Range(0, Monstercards.Count - 1);
             cards.numbers.Add(Monstercards[randomCard]);
        }
 
    }
   
 
}