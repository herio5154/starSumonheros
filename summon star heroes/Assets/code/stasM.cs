using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stasM : MonoBehaviour {
    public PlayerMemory summon;
    public Inventory slotsTorole;
    public int exp;
    public int gold;
    public int monster;
    public List<unitStats> Stats = new List<unitStats>();
    public List<slots> numbers = new List<slots>();
    void Awake()
    {
        summon = FindObjectOfType<PlayerMemory>();
        slotsTorole = FindObjectOfType<Inventory>();
        for(int i = 0; i< slotsTorole.PlayerActSlots.Count; i++)
        {
            numbers.Add(slotsTorole.PlayerActSlots[i]);

        }  
     ///  for (int i = 0; cout < Moves.Length; i++)

            for (int partty = 0; partty < summon.Partty.Count; partty++ )
        {
            Stats.Add(summon.Partty[partty]);
  
        }

    }
   
  
}
