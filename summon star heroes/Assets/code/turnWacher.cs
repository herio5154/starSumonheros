using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum targetKind { Player, Enemy,All }

public class turnWacher : MonoBehaviour {
    public statsUI stats;
    public int ParttyMemberInuse;
    public PlayerMemory memory;
    public sound_effect_manager sound;
    public monsterTurnM MonsterTurn;
    [HideInInspector]
    public monsterSheat MStats;
    public List <AtackInfo> turnInfo = new List<AtackInfo>();
    public GameObject []  Moves;
     public GameObject menu;
    public GameObject theTurn;
    public GameObject [] battle;
    public GameObject Info;
    public GameObject Slots;
    public int turns;
    public bool start;
     public float playersALive;
    public string dead;
    public bool [] found;
    public roleOutcome winer;
    public bool information;
 	// Use this for initialization
	void Start () {

        memory = FindObjectOfType<PlayerMemory>();
        Moves = GameObject.FindGameObjectsWithTag("Stats");
        MStats = FindObjectOfType<monsterSheat>();
        MonsterTurn.basicAtack();

        for (int i = 0; i < Moves.Length; i++)
        {

            if(Moves[i].GetComponent<AtackInfo>() != null)
            {
                turnInfo.Add(Moves[i].GetComponent<AtackInfo>());
            }
            if (i < battle.Length)
            {
                battle[i].SetActive(false);
            }
        }
 
     

        newturn();

    }
    public void Speed()
    {
        turnInfo.Sort(
            delegate (AtackInfo a, AtackInfo b)
           {
               if (a.Stats.Speed > b.Stats.Speed) return -1;
               if (a.Stats.Speed < b.Stats.Speed) return 1;
               return 0;
           }
 );
 
    }
 

    // Update is called once per frame
    void Update ()
    {
        if(start == false)
        if (Input.GetButtonDown("AButton"))
            {
                Speed();
                 sound.soundEfeacts("yes");
                 battle[0].SetActive(false);
                battle[1].SetActive(true);
                findPlayer();                
                start = true;

            }
    }
    public void findPlayer()
    {
        bool foundit = false;
        for(int i = 0; i< turnInfo.Count; i++)
        {
            if(foundit == false)
            {
                if (turnInfo[i].monster == false && turnInfo[i].Stats.currentHealth >0)
                {
                    ParttyMemberInuse = i;
                    stats.setpartty(i);
                    foundit = true;                  
                }
            }
        }

    }
    public void newturn()
    {
 
        Speed();
         MonsterTurn.basicAtack();
        start = false;
        battle[0].SetActive(true);
        findPlayer();
        stats.setpartty(ParttyMemberInuse);

    }

    public void next()
    {
        bool foundplayer = false;

        if (memory.Partty.Count > 1)
        {
            ParttyMemberInuse++;
            if(ParttyMemberInuse <turnInfo.Count-1)
            {
            for (int I = ParttyMemberInuse; I < turnInfo.Count-1; I++)
            {
                if (foundplayer == false)
                {
                    if (turnInfo[I].monster == false && turnInfo[I].AtackInformation[3] == false)
                    {
                        ParttyMemberInuse = I;
                        stats.setpartty(I);
 
                        foundplayer = true;
                        menu.SetActive(false);
                        menu.SetActive(true);
                    }
                }
                if (I == turnInfo.Count-1 && foundplayer == false)
                {
                    if (information == false)
                    {
                        theTurn.SetActive(true);
                    }
                    if (information == true)
                    {
                        Info.SetActive(true);
                    }
                    menu.SetActive(false);
                }
            }
            }
            if (ParttyMemberInuse >= turnInfo.Count - 1)
            {
                if (information == false)
                {
                    theTurn.SetActive(true);
                }
                if (information == true)
                {
                    Info.SetActive(true);
                }
                menu.SetActive(false);
            }
        }
        if (memory.Partty.Count <= 1)
        {
            if (information == false)
            {
                theTurn.SetActive(true);
            }
            if (information == true)
            {
                Info.SetActive(true);
            }
            menu.SetActive(false);
        }


    }

   public void act()
    {
        menu.SetActive(false);
        Slots.SetActive(true);
        for(int i = 0; i< turnInfo.Count-1; i++)
        {
            if(turnInfo[i].monster == false)
            {
 
                turnInfo[i].MoveKind = movekind.Defence;
             }
        }
    }
    public void runforIt()
    {
        menu.SetActive(false);
        for (int i = 0; i < turnInfo.Count - 1; i++)
        {
            if (turnInfo[i].monster == false)
            {

                turnInfo[i].MoveKind = movekind.Stats;
            }
        }
    }
}



  

