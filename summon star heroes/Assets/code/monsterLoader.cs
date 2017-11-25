using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterLoader : MonoBehaviour {
    private PlayerMemory memory;
    public Transform [] slots3;
    public Transform[] slots2;
    public Transform slots1;
    public battleM battle;
    public monsterSheat Msheat;
    public int SpawnChance;
    public int slot;
    void Awake()
    {
        slot = 0;
        memory = FindObjectOfType<PlayerMemory>();

        var newmonsters = Instantiate(memory.MonsterFightingID[0], transform.position, transform.rotation);
        Msheat = newmonsters.gameObject.GetComponent<monsterSheat>();
        if (Msheat.monstersToSpawn.Count == 1)
        {
            var NewM = Instantiate(Msheat.monstersToSpawn[0].unitToSpawn, slots1.transform.position, slots1.transform.rotation);
            Msheat.UnitStats.Add(NewM.gameObject.GetComponent<unitStats>());
            NewM.gameObject.GetComponent<unitStats>().MonsterStuff[0].location = slots1;
            NewM.gameObject.GetComponent<unitStats>().MonsterStuff[0].isHit.BattleWach = battle;
            NewM.gameObject.GetComponent<unitStats>().MonsterStuff[0].isHit.memory = memory;
            NewM.transform.parent = Msheat.gameObject.transform;
        }
        if (Msheat.monstersToSpawn.Count == 2)
        {

            for (int i = 0; i < Msheat.monstersToSpawn.Count; i++)
            {
                var NewM = Instantiate(Msheat.monstersToSpawn[i].unitToSpawn, slots2[slot].transform.position, slots2[slot].transform.rotation);
                Msheat.UnitStats.Add(NewM.gameObject.GetComponent<unitStats>());
                NewM.gameObject.GetComponent<unitStats>().MonsterStuff[0].location = slots2[slot];
                NewM.gameObject.GetComponent<unitStats>().MonsterStuff[0].isHit.BattleWach = battle;
                NewM.gameObject.GetComponent<unitStats>().MonsterStuff[0].isHit.memory = memory;
                NewM.transform.parent = Msheat.gameObject.transform;
                slot += 1;
            }

        }
        if (Msheat.monstersToSpawn.Count == 3)
        {

            for (int i = 0; i < Msheat.monstersToSpawn.Count; i++)
            {
                var NewM = Instantiate(Msheat.monstersToSpawn[i].unitToSpawn, slots3[slot].transform.position, slots3[slot].transform.rotation);
                Msheat.UnitStats.Add(NewM.gameObject.GetComponent<unitStats>());
                NewM.gameObject.GetComponent<unitStats>().MonsterStuff[0].location = slots3[slot];
                NewM.gameObject.GetComponent<unitStats>().MonsterStuff[0].isHit.BattleWach = battle;
                NewM.gameObject.GetComponent<unitStats>().MonsterStuff[0].isHit.memory = memory;
                NewM.transform.parent = Msheat.gameObject.transform;
                slot += 1;
            }

        }
        namesetup();
    }







    public void namesetup()
    {
        int couter = 0;
        int NameID = 0;
          Msheat.UnitStats.Sort(
                   delegate (unitStats a, unitStats b)
                   {
                       if (a.MonsterID > b.MonsterID) return -1;
                       if (a.MonsterID < b.MonsterID) return 1;
                       return 0;
                   }
        );
       if(Msheat.UnitStats.Count >1)
        {
             for(int i = 1; i< Msheat.UnitStats.Count; i++)
            {
                if(Msheat.UnitStats[couter].Name == Msheat.UnitStats[i].Name)
                {
                   if(NameID == 0)
                    {
                        Debug.Log("this was hit");
                        Msheat.UnitStats[couter].TexTID = "A";
                        Msheat.UnitStats[i].TexTID = "B";
                    }
                    if (NameID == 1)
                    {
                        Msheat.UnitStats[i].TexTID = "C";
                     }
                    NameID++;
                }
                if(Msheat.UnitStats[couter].Name != Msheat.UnitStats[i].Name)
                {
                    couter = i;
                    NameID = 0;
                }
            }
             foreach(unitStats theName in Msheat.UnitStats)
            {
                theName.Name += theName.TexTID;
            }

        }
        
    }
   
    
}
