using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitStats : MonoBehaviour {
 
    public string Name;
    public string TexTID;
    public weponKind weponKind;
    public Sprite face;
    public int Level;
    public int MonsterID;
    public majic stretnth;
    public majic Weekness;
    public float currentMana;
    public float currentHealth;
    public float MaxHealth;
    public float MaxMana;
    public float Attack;
    public float Majic;
    public float Defence;
    public float Speed;
    public int Luck;
    public EXPM Exp;
    public int LuckyNumber;
    public AtackInfo atackCard;
    public List<AtackList> Moves = new List<AtackList>();
    public List<MonsterStasts> MonsterStuff = new List<MonsterStasts>();
    public List<Items> equipment = new List<Items>();
    
  
}
