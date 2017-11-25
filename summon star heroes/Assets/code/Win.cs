using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour

{
    public battleSound background;
    public AudioSource gameoverSounds;
    public AudioClip winer;
    public AudioClip louse;
    public string gameOver;
    public int stage;
     public turnWacher win;
    [HideInInspector]
    public monsterSheat monster;
    [HideInInspector]
    public PlayerMemory stats;
    public Inventory gold;
    public Text wintext;
    public string outCOme;
    public bool reading;
    public float expshare;
    public GameObject battleSetup;
    void OnEnable()
    {
        gold = FindObjectOfType<Inventory>();
                 monster = FindObjectOfType<monsterSheat>();
        stats = FindObjectOfType<PlayerMemory>();
        StartCoroutine(Wait());
        reading = true;
        background.winer();
        stage = monster.stage;
        battleSetup.SetActive(false);
        if (monster.kindofBattle == battleKInds.boss)
        {
            stats.stage[stage].stagecomplated = monster.outcome;
            stats.stage[stage].Bossfight = win.winer;
        }
       

 
        if (win.winer == roleOutcome.Fight)
        {            

foreach(unitStats stats in stats.Partty)
            {
                if(stats.currentHealth <=0)
                {
                    stats.currentHealth = 1;
                }
            }


            if (monster.kindofBattle == battleKInds.boss)
            {
                stats.stage[stage].stagecomplated = monster.outcome;
            }
            outCOme = " all the enemies are defeated"+"\n" + " you got  ";
            if (monster.kindofBattle == battleKInds.MidBoss)
            {
                outCOme += monster.Gold*2 + "  gold " + "\n"+monster.ExpToGive+"exp";
                stats.stage[monster.stage].BossBattles[monster.MidBossID] = true;

            }
            if (monster.kindofBattle == battleKInds.noraml)
            {
                expshare = monster.ExpToGive / stats.Partty.Count;
                outCOme += monster.Gold + "  gold "+"\n";
            }
            expCHeck();
            stats.DeathCOunt++;
            stats.stage[stage].monstersInTheRoom -= 1;
            reading = true;
            gameoverSounds.PlayOneShot(winer, 1.0F);
 
        }
        if (win.winer == roleOutcome.lose)
        {
            outCOme = "game over";
            gameoverSounds.PlayOneShot(louse, 1.0F);
          }
    }
    void Update()
    {
        wintext.text = outCOme;
        if (reading == false)
        {
            if (Input.GetButtonDown("AButton"))
            {
       if (win.winer == roleOutcome.lose)
            {
                    stats.loadRoom(gameOver, false, false);
            }
            else
            {
                    cleen();
            }
            }

         


        }
    }

    public void expCHeck()
    {
      foreach(unitStats stats in stats.Partty)
        {
            if (monster.kindofBattle != battleKInds.boss)
            {
              
                stats.Exp.levelup(expshare);
                 outCOme += stats.Exp.expText;

            }
            if (monster.kindofBattle != battleKInds.boss)
            {
                stats.Exp.AutoLevel(monster.bost);
                outCOme += stats.Name + "  leveled up" + " they are now level " + stats.Level+"\n";
            }
        }
        gold.Gold += monster.Gold;

    }
    public void cleen()
    {
        stats.MonsterFightingID.Remove(stats.MonsterFightingID[0]);

        foreach (unitStats player in stats.Partty)
        {
            player.atackCard.clear();
        }
        stats.loadRoom(monster.stagetoGoback,false,true);
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
        reading = false;
    }
}
