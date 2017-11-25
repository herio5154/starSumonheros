using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomIncouters : MonoBehaviour {

    public int monsterfoundID;
    public string nextStage;    
    public int stage;
     public pause pasued;
    public PlayerMemory memory;
     public int  find;
    public hitBox box;
     public sound_effect_manager sound;
    public pause stop;
    public bool roled;
    public float time;
    public bool fight;
    public GameObject blackscreen;
    public moveCalog catalog;
    public int monstercouter;
    public int chance;
    public List<RandomMonsterSetup> monstersToSpawn = new List<RandomMonsterSetup>();
    // Use this for initialization
  
    void Start () {
        memory = FindObjectOfType<PlayerMemory>();


        monstersToSpawn[0].MonsterTospawn.GetComponent<monsterSheat>().ExpToGive = 0;
        if (monstersToSpawn[0].MonsterTospawn.GetComponent<monsterSheat>().monstersToSpawn.Count >0)
        {
            while(monstersToSpawn[0].MonsterTospawn.GetComponent<monsterSheat>().monstersToSpawn.Count >0)
            {
                monstersToSpawn[0].MonsterTospawn.GetComponent<monsterSheat>().monstersToSpawn.Remove(monstersToSpawn[0].MonsterTospawn.GetComponent<monsterSheat>().monstersToSpawn[0]);
            }
        }
        if(memory.stage[stage].monstersInTheRoom == 0)
        {
            Debug.Log("boop");
            Destroy(gameObject);
        }
        float avrigeEXp = 0;
         for(int i = 0; i<memory.Partty.Count; i++)
        {
            avrigeEXp += memory.Partty[i].Exp.ExpNeeded;
        }        
        avrigeEXp = (Mathf.Round(avrigeEXp / memory.Partty.Count));
        for (int X = 0; X < monstersToSpawn[0].monsterstats.Count; X++)
        {
            monstersToSpawn[0].monsterstats[X].BaceExp = (Mathf.Round(monstersToSpawn[0].monsterstats[X].Expvaule / avrigeEXp * 100));
         }

     }
   
    public void loadmonsters(int amounttosapawn)
    {
        for(int i = 0; i < amounttosapawn; i++)
        {
            int role = Random.Range(0, 100);
        
            if(role <= monstersToSpawn[0].monsterstats[i].spawnRate)
            {
                if(monstercouter < monstersToSpawn[0].maxMonsters)
                {
                monstersToSpawn[0].MonsterTospawn.GetComponent<monsterSheat>().monstersToSpawn.Add(monstersToSpawn[0].monsterstats[i]);
                    monstersToSpawn[0].MonsterTospawn.GetComponent<monsterSheat>().ExpToGive += monstersToSpawn[0].monsterstats[i].BaceExp;
                    monstercouter++;
                    Debug.Log(role + monstersToSpawn[0].monsterstats[i].Name);

                }
            }
            if(monstercouter < monstersToSpawn[0].maxMonsters)
            {
                i = 0;
            }
          
        }
        memory.MonsterFightingID.Add(monstersToSpawn[0].MonsterTospawn);
        var black = Instantiate(blackscreen, new Vector3(0, 0, 0), Quaternion.identity);
        black.gameObject.GetComponent<StartStage>().start = false;
    }




}
