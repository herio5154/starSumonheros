using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ActOutCome : MonoBehaviour
{
    public battleSound background;

    public AudioClip winerSound;
    public AudioSource gameoverSounds;
    public PlayerMemory memory;
    public turnWacher turns;
    public ActTurn theTurn;
    [HideInInspector]
    public monsterSheat MStats;
    public string[] outCome;
    public Text outComeText;
    public GameObject[] Next;
    public GameObject slotBox;
    public GameObject winer;
    private bool reading;
    public int[] goldExpHPMPtoGive;
    private float time = 0.3f;
    public int Togive;
    public int exp;
    public int gold;
    public string  winText;
    public int stage;

    // Use this for initialization

    void OnEnable()
    {
        Togive = 0;
        reading = true;
        MStats = FindObjectOfType<monsterSheat>();
        memory = FindObjectOfType<PlayerMemory>();
        StartCoroutine(wait());
 

            outcome();
    }
    public void cleen()
    {
     while(memory.MonsterFightingID.Count >0)
        {
            memory.MonsterFightingID.Remove(memory.MonsterFightingID[0]);
        }
        foreach (unitStats player in memory.Partty)
        {
            player.atackCard.clear();
         }

    }
    public void outcome()
    {
         winText = "";
          if(theTurn.ActOutCome == roleOutcome.win)
        {
            foreach (unitStats monster in MStats.UnitStats)
            {
                monster.MonsterStuff[0].isHit.win();
            }
        

            background.winer();
            gameoverSounds.PlayOneShot(winerSound, 1.0F);
            theTurn.victoryCard[0].CardVaule = vaule.EXP;
            foreach(lineCheck win in theTurn.victoryCard)
            {
                if(win.CardVaule == vaule.EXP)
                {
                     exp = win.cardBaseVaule;
                    expAdd();

                }
                if (win.CardVaule == vaule.gold)
                {
                    gold += win.cardBaseVaule;
                     winText += "you win"+ win.cardBaseVaule+"gold " + "\n";
                }
                if (win.CardVaule == vaule.HP)
                {
                    heal();
                    winText += "the partty is healled" + "\n";
                }
                if (win.CardVaule == vaule.MP)
                {
                    mpResore();
                  winText += "the partty gets there mp back" + "\n";
                }
                if (win.CardVaule == vaule.NA)
                {
                    winText += "you win" + "\n";
                }
            }
           
            outComeText.text = winText;
         
        }
        if (theTurn.ActOutCome == roleOutcome.lose)
        {
            outComeText.text = "its not very efeactive";
        }
        if (theTurn.ActOutCome == roleOutcome.draw)
        {
            outComeText.text = "noting happens";
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("AButton"))
        {
            if (reading == false)
            {

                if (theTurn.ActOutCome == roleOutcome.lose)
                {
                    Next[0].SetActive(true);
                    gameObject.SetActive(false);

                }
                if (theTurn.ActOutCome == roleOutcome.draw || theTurn.ActOutCome == roleOutcome.noWin)
                {
                    Next[1].SetActive(true);
                    gameObject.SetActive(false);

                }
                if (theTurn.ActOutCome == roleOutcome.win)
                {
                    cleen();
                    theTurn.ActOutCome = roleOutcome.win;
                    if (MStats.kindofBattle == battleKInds.boss)
                    {
                        memory.stage[MStats.stage].stagecomplated = MStats.outcome;
                        memory.stage[MStats.stage].Bossfight = roleOutcome.win;
                    }
                    SceneManager.LoadScene(MStats.stagetoGoback);

                }
                slotBox.SetActive(false);
            }
        }
    }
  
    public void heal()
    {
        foreach (unitStats HP in memory.Partty)
        {
            Debug.Log(HP.Name);
            HP.currentHealth = HP.MaxHealth;
        }
    
    }
    public void mpResore()
    {
        foreach(unitStats MP in memory.Partty)
        {
            Debug.Log(MP.Name);
            MP.currentMana  = MP.MaxMana;
        }       
    }
    public void expAdd()
    {
 
        for (int i = 0; i < memory.Partty.Count; i++)
        {
            memory.Partty[i].Exp.levelup(exp);
             winText += memory.Partty[i].Exp.expText;
        }
    }
    IEnumerator wait()
    {
        reading = true;
        yield return new WaitForSeconds(time);
        reading = false;
 
    }
}
