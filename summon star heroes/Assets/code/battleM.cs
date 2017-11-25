using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class battleM : MonoBehaviour
{
    public PlayerMemory memeory;
    public turnWacher combatText;
    public monsterTurnM monsters;
    private monsterSheat checker;
    public Transform locatonY;
    public stasM Playerstats;
    public Text TheCombatText;
    public Inventory invantory;
    public sound_effect_manager sound;
    [Tooltip("0 = flash 1 == dead monster 2 == win start = 3")]
    public GameObject [] Efects;
    private int Target;
    private int turn;
    [Tooltip("read = 0 flashing ==1 win = 2 dubbles = 3")]
     public bool [] reading;
    public int Stages;
    public float time;
    public float  Damge;
   [Tooltip("the move = 0 invantory  = 1")]
    public int [] TheMove;
     public string[] turnAct;
    [Tooltip("players = 0 monster = 1")]
    public int[] Alive;
    private bool playerTarget;
     void Start()
    {
        memeory = FindObjectOfType<PlayerMemory>();
        invantory = FindObjectOfType<Inventory>();
        checker = FindObjectOfType<monsterSheat>();
        Alive[1] = checker.UnitStats.Count;
        Alive[0] = Playerstats.Stats.Count;
     }

    void OnEnable()
    {

        invantory = FindObjectOfType<Inventory>();
         reading[3] = false;
        Stages = 0;
        turn = 0;
        if (combatText.turnInfo[Stages].AtackInformation[3]  == true || combatText.turnInfo[Stages].MoveKind == movekind.Stats|| combatText.turnInfo[Stages].Stats.currentHealth <=0)
        {
            turn = 4;
        }
        if (combatText.turnInfo[Stages].TargetKind == targetKind.All)
        {
            mutablesCheck();
        }
        if (combatText.turnInfo[Stages].TargetKind != targetKind.All)
        {
            check();
        }
   
        turns();



    }
    // 
    void Update()
    {

        if (reading[0] == false && reading[1] == false)
        {
            if (Input.GetButtonDown("AButton"))
            {
                if (reading[0] == false)
                {
                    turns();
                }

            }

        }
    }


    public void nameCheck()
    {
       for(int i = 0; i< combatText.turnInfo[Stages].AtackInformation.Length; i++)
        {
            combatText.turnInfo[Stages].AtackInformation[i] = false;
        }      

        TheMove[0] = 0;
 
            for (int i = 0; i < combatText.turnInfo.Count; i++)
            {

                if (combatText.turnInfo[Stages].MoveInformation[0] == combatText.turnInfo[i].Stats.Name)
                {
                    Target = i; if 
                    (combatText.turnInfo[i].AtackInformation[3]  == true || combatText.turnInfo[i].Stats.currentHealth <= 0)
                {
                    combatText.turnInfo[Stages].AtackInformation[0] = true;
                    Debug.Log("Dead jim");
                }

            }
            }
        
       
        if (combatText.turnInfo[Stages].MoveKind == movekind.Attack|| combatText.turnInfo[Stages].MoveKind == movekind.BlackMajic|| combatText.turnInfo[Stages].MoveKind == movekind.whiteMaic|| combatText.turnInfo[Stages].MoveKind == movekind.NA)
        {
            for (int i = 0; i < combatText.turnInfo[Stages].Stats.Moves.Count; i++)
            {
                if (combatText.turnInfo[Stages].MoveInformation[1] == combatText.turnInfo[Stages].Stats.Moves[i].MoveText)
                {
                    TheMove[0] = i;

                    if (combatText.turnInfo[Stages].Stats.Moves[i].Target[1] == targetKind.Player)
                    {
                        playerTarget = true;
                    }
                    if (combatText.turnInfo[Stages].Stats.Moves[i].Target[1] == targetKind.Enemy)
                    {
                        playerTarget = false;
                    }
                 }
            }
        }
        if(combatText.turnInfo[Stages].MoveKind == movekind.Items)
        {
            TheMove[1] = 0;
              for (int i = 0; i < invantory.items.Count; i++)
            {
 if(combatText.turnInfo[Stages].MoveInformation[1] == invantory.items[i].ItemName)
                {
                    TheMove[1] = i;

                }
            }
           
            
        }

        

    }
    public void AtackSetup()
    {
        int D100 = Random.Range(0, 100);
        int D10 = Random.Range(0, 10);
        float defence = 0;
        float Atack = 0;
        Damge = 0;
        if (combatText.turnInfo[Stages].MoveKind != movekind.Items)
        {
            Damge = combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Atack;
            if (D100 > combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Hit + combatText.turnInfo[Stages].Stats.Speed)
            {
                combatText.turnInfo[Stages].AtackInformation[0]  = true;
            }

            for (int i = 0; i < combatText.turnInfo[Stages].Stats.Luck; i++)
            {
                if (combatText.turnInfo[Target].MoveKind != movekind.Defence)
                {
                    if (D10 == combatText.turnInfo[Stages].Stats.LuckyNumber)
                    {
                        combatText.turnInfo[Stages].AtackInformation[0]  = false;
                        combatText.turnInfo[Stages].AtackInformation[1]  = true;
                    }
                }

            }
        }
        
        if (combatText.turnInfo[Target].MoveKind == movekind.Defence)
        {
            defence = combatText.turnInfo[Target].Stats.Defence * 2;
 
       
        }
        if (combatText.turnInfo[Target].Stats.Weekness != majic.NA)
        {
            if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Element == combatText.turnInfo[Target].Stats.stretnth)
            {
                defence += combatText.turnInfo[Target].Stats.Defence * 2;
            }
        }

        if (combatText.turnInfo[Stages].MoveKind == movekind.Attack)
        {
            Atack += combatText.turnInfo[Stages].Stats.Attack;
        }
        if (combatText.turnInfo[Stages].MoveKind == movekind.BlackMajic || combatText.turnInfo[Stages].MoveKind == movekind.whiteMaic)
        {
            Atack += combatText.turnInfo[Stages].Stats.Majic;
        }

        if (combatText.turnInfo[Stages].MoveKind == movekind.BlackMajic || combatText.turnInfo[Stages].MoveKind == movekind.whiteMaic || combatText.turnInfo[Stages].MoveKind == movekind.Attack)
        {
            if (combatText.turnInfo[Stages].AtackInformation[1]  == true)
            {

                Atack += combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Atack;
            }

        }

        if (combatText.turnInfo[Stages].MoveKind != movekind.Items && combatText.turnInfo[Target].Stats.Weekness != majic.NA)
        {
            if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Element == combatText.turnInfo[Target].Stats.stretnth)
            {
                if (combatText.turnInfo[Stages].AtackInformation[1]  == true)
                {
                    Atack -= combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Atack;
                }

                combatText.turnInfo[Stages].AtackInformation[1]  = false;
                Atack = Damge / 2;
                Damge -= Atack;
                if (combatText.turnInfo[Target].Stats.LuckyNumber == D10)
                {
                    combatText.turnInfo[Stages].AtackInformation[0]  = true;
                }
            }
            if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Element == combatText.turnInfo[Target].Stats.Weekness && combatText.turnInfo[Stages].MoveKind != movekind.Defence)
            {
                if (combatText.turnInfo[Stages].AtackInformation[2]  == true)
                {
                    Atack += combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Atack;
                }
            }


        }
        Damge += Atack - defence;
        if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Atack == 0 || Damge <= 0)
        {
            Damge = 0;
        }
    }
    public void check()
    {
          
        nameCheck();
        AtackSetup();
         if (combatText.turnInfo[Target].AtackInformation[3]  == true)
        {
            combatText.turnInfo[Stages].AtackInformation[0]  = true;
        }
        if (combatText.turnInfo[Stages].MoveKind == movekind.Defence)
        {
            combatText.turnInfo[Stages].AtackInformation[0]  = true;
        }
        if (combatText.turnInfo[Stages].AtackInformation[0]  == false )
        {
 
            if (combatText.turnInfo[Stages].MoveKind == movekind.Attack || combatText.turnInfo[Stages].MoveKind == movekind.NA)
            {


                    turnAct[0] = combatText.turnInfo[Stages].Stats.Name + "  uses  " + combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].MoveText + "\n" + combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].MoveText;
                
            
            }
            if (combatText.turnInfo[Stages].MoveKind == movekind.BlackMajic)
            {
                turnAct[0] = combatText.turnInfo[Stages].Stats.Name + " casts " + combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].MoveText;
                if (combatText.turnInfo[Target].Stats.Name != combatText.turnInfo[Stages].Stats.Name)
                {
                    turnAct[0] += " at " + combatText.turnInfo[Target].Stats.Name;
                }
                {
                    turnAct[0] = combatText.turnInfo[Stages].Stats.Name + "  " + combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].MoveText + "\n" + combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].MoveName;
                }
              
            }
            if (combatText.turnInfo[Stages].MoveKind == movekind.whiteMaic)
            {
                combatText.turnInfo[Stages].AtackInformation[1]  = false;
                turnAct[0] = combatText.turnInfo[Stages].Stats.Name + " casts " + combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].MoveName;
                if(combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Target[0] != targetKind.All)
                {
                    turnAct[0] += " on " + combatText.turnInfo[Target].Stats.Name;
                }
                                     
             }

        }
        if (combatText.turnInfo[Stages].MoveKind == movekind.Items)
        {
             if(combatText.turnInfo[Stages].TargetKind == targetKind.Player)
            {
   
                if(combatText.turnInfo[Stages].Stats.Name == combatText.turnInfo[Target].Stats.Name)
                {
                    turnAct[0] = combatText.turnInfo[Stages].Stats.Name + " used " + invantory.items[TheMove[1]].ItemName;

                }
                else
                {
                    turnAct[0] = combatText.turnInfo[Stages].Stats.Name + " uses " + invantory.items[TheMove[1]].ItemName+"\n" + "on " + combatText.turnInfo[Target].Stats.Name; 
                   
                }
                 
            }
            if (combatText.turnInfo[Stages].TargetKind == targetKind.Enemy)
            {
                turnAct[0] = combatText.turnInfo[Stages].Stats.Name + " throws a " + invantory.items[TheMove[1]].ItemName +"\n"+"at "+ combatText.turnInfo[Target].Stats.Name;
                
            }


        }
        if (combatText.turnInfo[Stages].AtackInformation[0]  == true)
        {
            if (combatText.turnInfo[Stages].MoveKind == movekind.Defence)
            {
                turnAct[0] = combatText.turnInfo[Stages].Stats.Name+" Braces for impact";

            }
            else
            {
                turnAct[0] = combatText.turnInfo[Stages].Stats.Name + " misses ";
            }

        }


    }
    public void mutablesCheck()
    {
        int couter = 0;
        int role100 = 0;    
        turnAct[1] = "";        
        nameCheck();
         playerTarget = false;
        turnAct[0] = combatText.turnInfo[Stages].Stats.Name;



        if (combatText.turnInfo[Stages].MoveKind != movekind.Items)
        {
            #region starting text
            if (combatText.turnInfo[Stages].MoveKind == movekind.Attack || combatText.turnInfo[Stages].MoveKind == movekind.NA)
            {
                turnAct[0] += "uses " + combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].MoveName;
            }
            if (combatText.turnInfo[Stages].MoveKind == movekind.whiteMaic || combatText.turnInfo[Stages].MoveKind == movekind.BlackMajic)
            {
                turnAct[0] += " casts " + combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].MoveName;
            }
            turnAct[0] += "\n" + combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].MoveName;
            #endregion

            foreach (AtackInfo move in combatText.turnInfo)
            {
                if(move.AtackInformation[1] == false && move.Stats.currentHealth >0)
                {
                #region monster
                if (combatText.turnInfo[Stages].monster == true)
                {
                    if (playerTarget == true && move.monster == false)
                    {
                        role100 = Random.Range(0, 100);
                        turnAct[0] += "The Attack ";
                        if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Hit + combatText.turnInfo[Stages].Stats.Speed >= role100)
                        {
                            turnAct[0] += "misess " + move.Stats.Name + "\n";
                            couter++;
                            move.AtackInformation[0] = true;
                        }
                        if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Hit + combatText.turnInfo[Stages].Stats.Speed <= role100)
                        {
                            turnAct[0] += "hits" + move.Stats.Name + "\n";
                        }
                    
                    }
                  
                }
                #endregion
                #region player
                if (combatText.turnInfo[Stages].monster == false)
                {
                    if (playerTarget == false && move.monster == true)
                    {
                        role100 = Random.Range(0, 100);
                        Debug.Log(role100);
                        turnAct[0] += "The Attack ";
                        if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Hit + combatText.turnInfo[Stages].Stats.Speed <= role100)
                        {
                            turnAct[0] += "misess " + move.Stats.Name + "\n";
                            couter++;
                            move.AtackInformation[0] = true;
                        }
                        if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Hit + combatText.turnInfo[Stages].Stats.Speed >= role100)
                        {
                            turnAct[0] += "hits" + move.Stats.Name + "\n";
                        }
                        
                    }
                        if (playerTarget == true && move.monster == false)
                        {
                          if(combatText.turnInfo[Stages].Stats.Moves[0].Buff == false)
                            {
                                turnAct[0] += "Restores"+ move.Stats.Name+"'s HP "+ "\n";
                            }                           
                        }
                    }
                }
            #endregion
                }
            }

    }
    public void Atack()
    {
        int Mutable = Random.Range(0, 4);
        float atackNumber = 0;
        if (Damge <= 0)
        {

            if (combatText.turnInfo[Stages].MoveKind == movekind.Items)
            {
                if (combatText.turnInfo[Stages].TargetKind == targetKind.Player)
                {
                    turnAct[1] = " restores " + "\n";
                    if (invantory.items[TheMove[1]].foodkind == Items.food.HP || invantory.items[TheMove[1]].foodkind == Items.food.HPandMP)
                    {
                        turnAct[1] += invantory.items[TheMove[1]].stats[0] + "HP ";
                        combatText.turnInfo[Target].Stats.currentHealth += invantory.items[TheMove[1]].stats[0];
                    }
                    if (invantory.items[TheMove[1]].foodkind == Items.food.MP || invantory.items[TheMove[1]].foodkind == Items.food.HPandMP)
                    {
                        turnAct[1] += invantory.items[TheMove[1]].stats[1] + "MP ";
                        combatText.turnInfo[Target].Stats.MaxMana += invantory.items[TheMove[1]].stats[1];
                    }
       sound.soundEfeacts("useIteam");
                }
                if (combatText.turnInfo[Stages].TargetKind == targetKind.Enemy)
                {
                     turnAct[1] = combatText.turnInfo[Stages].Stats.Name + " did " + invantory.items[TheMove[1]].stats[2] + " Damge ";

                           sound.soundEfeacts("AtackSound");
                    if (memeory.epilepsyMode == false)
                    {
                        Efects[0].SetActive(true);
                    }
                    combatText.turnInfo[Target].Stats.currentHealth -= invantory.items[TheMove[1]].stats[2];
                }
            }
            else
            {
            sound.soundEfeacts("yes");
                turnAct[1] = "nothing happens";
            }

        }
        if (Damge > 0)
        {
            turnAct[1] = "";

            if (combatText.turnInfo[Stages].AtackInformation[2]  == true)
            {
                turnAct[1] += " is week to " + combatText.turnInfo[Target].Stats.Weekness + " ";
            }
            if (combatText.turnInfo[Stages].AtackInformation[1]  == true)
            {
                turnAct[1] += " critical hit " + "\n";
            }
            if (combatText.turnInfo[Stages].MoveKind == movekind.Attack || combatText.turnInfo[Stages].MoveKind == movekind.BlackMajic || combatText.turnInfo[Stages].MoveKind == movekind.NA)
            {

                    turnAct[1] += combatText.turnInfo[Stages].Stats.Name + " did " + Damge + " Damge ";
             
                if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].mutable == true)
                {
                    if (Mutable > 0)
                    {
                        atackNumber = Damge;
                        Damge = atackNumber * Mutable;
                    }
                    turnAct[1] +="X"+Mutable ;
                }

                combatText.turnInfo[Target].Stats.currentHealth -= Damge;
                if (combatText.turnInfo[Stages].monster == false)
                {
                    var Atack = Instantiate(combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].AttckPrefab, new Vector3(combatText.turnInfo[Target].Stats.MonsterStuff[0].location.transform.position.x, locatonY.transform.position.y, combatText.turnInfo[Target].Stats.MonsterStuff[0].location.transform.position.z), Quaternion.identity);
                    Atack.gameObject.GetComponent<atackAamation>().battleM = gameObject.GetComponent<battleM>();
                    combatText.turnInfo[Target].Stats.MonsterStuff[0].isHit.battle();
                }
                if (combatText.turnInfo[Stages].monster == true)
                {
                           sound.soundEfeacts("AtackSound");
                    if (memeory.epilepsyMode == false)
                    {
                        Efects[0].SetActive(true);
                    }
                }
            }
            if (combatText.turnInfo[Stages].MoveKind == movekind.whiteMaic)
            {
       sound.soundEfeacts("useIteam");
                if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Buff == false)
                {
                    if (combatText.turnInfo[Stages].TargetKind == targetKind.Player)
                    {
                        float heal = combatText.turnInfo[Target].Stats.currentHealth;
                        heal += Damge;
                        if (Damge < combatText.turnInfo[Target].Stats.currentHealth)
                        {
                            Damge = combatText.turnInfo[Target].Stats.MaxHealth;
                        }

                    }
                    turnAct[1] += combatText.turnInfo[Target].Stats.Name + " gets " + Damge + " HPback ";

                    combatText.turnInfo[Target].Stats.currentHealth += Damge;
                }
                if(combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Buff == true)
                {
                    buffs();
                }
                if (combatText.turnInfo[Stages].MoveKind == movekind.BlackMajic || combatText.turnInfo[Stages].MoveKind == movekind.whiteMaic)
                {

                    if (combatText.turnInfo[Stages].Stats.currentMana < combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Cost)
                    {
                        float cost = combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Cost - combatText.turnInfo[Stages].Stats.currentMana;

                        if (cost > combatText.turnInfo[Stages].Stats.currentHealth)
                        {
                            cost = combatText.turnInfo[Stages].Stats.currentHealth - 1;
                        }
                        turnAct[1] += "\n" + "  but at at cost " + combatText.turnInfo[Stages].Stats.Name + " loses " + cost + "HP";
                        combatText.turnInfo[Stages].Stats.currentHealth -= cost;

                        combatText.turnInfo[Stages].Stats.currentMana = 0;

                    }
                    else
                    {
                        combatText.turnInfo[Stages].Stats.currentMana -= combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Cost;
                    }
                }

            }


        }
    }
     public void turns()
    {
        switch (turn)
        {
            case 0:
                Debug.Log("hit A");
                if (turnAct[0].Contains("PLAYER"))
                {
                    turnAct[0] = turnAct[0].Replace("PLAYER", combatText.turnInfo[Target].Stats.Name);

                }
                TheCombatText.text = turnAct[0];
            sound.soundEfeacts("yes");
                Debug.Log(combatText.turnInfo[Stages].Stats.Name);
                if (combatText.turnInfo[Stages].AtackInformation[3]  == true || combatText.turnInfo[Stages].MoveKind == movekind.Stats)
                {
                    turn = 4;
                    turns();
                }
                if (combatText.turnInfo[Stages].AtackInformation[3]  == false)
                { 
                    turn++;
                    StartCoroutine(wait());
                }
                break;
            case 1:
                Debug.Log("hit B");

                StartCoroutine(wait());
                if (combatText.turnInfo[Stages].AtackInformation[0]  == false)
                {
                    if (combatText.turnInfo[Stages].TargetKind != targetKind.All)
                    {
                        Atack();
                        Debug.Log("hit");
                    }
                    if (combatText.turnInfo[Stages].TargetKind == targetKind.All)
                    {
                        AttckAll();
                    }
                    turn = 2;

                }
                if (combatText.turnInfo[Stages].AtackInformation[0]  == true)
                {
                    turn = 4;
                }
                turns();
                break;
            case 2:
                Debug.Log("hit C");
 
                TheCombatText.text = turnAct[1];
                StartCoroutine(wait());
                if (combatText.turnInfo[Stages].MoveKind == movekind.Items)
                {
                    Debug.Log("remove");
                    invantory.items[TheMove[1]].Amount -= 1;
                    if (invantory.items[TheMove[1]].Amount <= 0)
                    {
                        invantory.items.Remove(invantory.items[TheMove[1]]);
                    }
                }
                if (combatText.turnInfo[Target].Stats.currentHealth <=0)
                {
                    turn = 3;

                }
                if (combatText.turnInfo[Target].Stats.currentHealth > 0)
                {
                    turn = 4;
                    reading[2] = false;
                }

                break;
            case 3:
                Debug.Log("hit D");

                string deadText = "";
                foreach(AtackInfo dead in combatText.turnInfo)
                {
                  if(dead.AtackInformation[3] == false)
                    {
                        if(dead.Stats.currentHealth <=0)
                        {
                            dead.AtackInformation[3] = true;
                            if(dead.monster == false)
                            {
                                deadText += dead.Stats.Name + "fanits" + "\n";
                                Alive[0] -= 1;
                            }
                            if (dead.monster == true)
                            {
                                deadText += dead.Stats.Name + " was defeated " + "\n";
                                var deadMonster = Instantiate(Efects[1], new Vector3(dead.Stats.MonsterStuff[0].location.transform.position.x, locatonY.transform.position.y, dead.Stats.MonsterStuff[0].location.transform.position.z), Quaternion.identity);
                                deadMonster.gameObject.GetComponent<DeadMonster>().monster = dead.Stats.gameObject;
                                Alive[1] -= 1;
                            }
                        }
                    }
                }
             
                TheCombatText.text = deadText;

                if (Alive[1] <= 0 || Alive[0] <= 0)
                {

                    reading[2] = true;
                    if (Alive[1] <= 0)
                    {
                        combatText.winer = roleOutcome.Fight;
                    }
                    if (Alive[0] <= 0)
                    {
                        combatText.winer = roleOutcome.lose;
                        Debug.Log("loss");
                    }
                }
                StartCoroutine(wait());
                turn++;
                break;
            case 4:
                Debug.Log("hit E");

                if (reading[2] == false)
                {
                     Stages++;                    
                    if (Stages <= combatText.turnInfo.Count-1)
                    {
                        turn = 0;
                        check();
                       turns();
                     }
                    if (Stages > combatText.turnInfo.Count-1)
                    {
                        
                        Efects[3].SetActive(true);

                    }
                }
                if (reading[2] == true)
                {
                    Efects[2].SetActive(true);

                }
                if ( Stages > combatText.turnInfo.Count-1)
                {
                    gameObject.SetActive(false);
                    Debug.Log("yo");
 
                }
                break;


        }

    }
    public void buffs()
    {
        foreach (StatsBoost buff in combatText.turnInfo[Target].statsBost)
        {
            if (buff.Name == combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].Name)
            {
                reading[3] = true;
                buff.turnsLeft += combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].turnsLeft;
            }
        }
        turnAct[1] += combatText.turnInfo[Target].Stats.Name;
                
        if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].buffkind == StatsBoost.buffs.Buff)
        {
            turnAct[1] += " gains ";
        }
        if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].buffkind == StatsBoost.buffs.Debuff)
        {
            turnAct[1] += " losses ";
        }
        if(combatText.turnInfo[Stages].TargetKind == targetKind.All)
        {
            turnAct[1] += "\n";
        }

        if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].StatToChnange == StatsKind.Attack)
        {
            turnAct[1] += " Attack ";
        }
        if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].StatToChnange == StatsKind.Defence)
        {
            turnAct[1] += " Defence ";
        }
        if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].StatToChnange == StatsKind.Speed)
        {
            turnAct[1] += " Speed";
        }
        combatText.turnInfo[Target].statsBost.Add(combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0]);
       
            turnAct[1] += "\n";
      
        if (reading[3] == false)
        {
            #region buff
            if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].buffkind == StatsBoost.buffs.Buff)
            {
                if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].StatToChnange == StatsKind.Attack)
                {
                    combatText.turnInfo[Target].Stats.Attack += combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].amount;
                }
                if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].StatToChnange == StatsKind.Defence)
                {
                    combatText.turnInfo[Target].Stats.Defence += combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].amount;
                }
                if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].StatToChnange == StatsKind.Majic)
                {
                    combatText.turnInfo[Target].Stats.Majic += combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].amount;
                }
                if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].StatToChnange == StatsKind.Speed)
                {
                    combatText.turnInfo[Target].Stats.Speed += combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].amount;
                }
            }
            #endregion
            #region debuff
            if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].buffkind == StatsBoost.buffs.Debuff)
            {
                {
                    if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].StatToChnange == StatsKind.Attack)
                    {
                        combatText.turnInfo[Target].Stats.Attack -= combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].amount;
                    }
                    if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].StatToChnange == StatsKind.Defence)
                    {
                        combatText.turnInfo[Target].Stats.Defence -= combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].amount;
                    }
                    if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].StatToChnange == StatsKind.Majic)
                    {
                        combatText.turnInfo[Target].Stats.Majic -= combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].amount;
                    }
                    if (combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].StatToChnange == StatsKind.Speed)
                    {
                        combatText.turnInfo[Target].Stats.Speed -= combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].buffDebuff[0].amount;
                    }
                }
            }
            #endregion
        }
    }
    public void AttckAll()
    {

         if(combatText.turnInfo[Stages].monster == true)
        {
                   sound.soundEfeacts("AtackSound");
            if (memeory.epilepsyMode == false)
            {
                Efects[0].SetActive(true);
            }
        }
        if(combatText.turnInfo[Stages].MoveKind != movekind.Items)
        {
            if (combatText.turnInfo[Stages].MoveKind != movekind.whiteMaic)
            {
                for (int i = 0; i < combatText.turnInfo.Count; i++)
                {
                    if (combatText.turnInfo[i].AtackInformation[0] == false && combatText.turnInfo[i].AtackInformation[1] == false && combatText.turnInfo[i].Stats.currentHealth > 0)
                    {
                        if (combatText.turnInfo[Stages].monster == true && combatText.turnInfo[i].monster == false)
                        {
                            Target = i;
                            AtackSetup();
                            turnAct[1] += combatText.turnInfo[i].Stats.Name + " took " + Damge + "Damge" + "\n";

                        }
                        if (combatText.turnInfo[Stages].monster == false && combatText.turnInfo[i].monster == true)
                        {
                            Target = i;
                            AtackSetup();
                            turnAct[1] += combatText.turnInfo[i].Stats.Name + " took " + Damge + "Damge" + "\n";
                            combatText.turnInfo[i].Stats.currentHealth -= Damge;
                            var Atack = Instantiate(combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].AttckPrefab, new Vector3(combatText.turnInfo[Target].Stats.MonsterStuff[0].location.transform.position.x, locatonY.transform.position.y, combatText.turnInfo[Target].Stats.MonsterStuff[0].location.transform.position.z), Quaternion.identity);
                            Atack.gameObject.GetComponent<atackAamation>().battleM = gameObject.GetComponent<battleM>();
                            combatText.turnInfo[Target].Stats.MonsterStuff[0].isHit.battle();
                        }
                    }
                }
            }

                if (combatText.turnInfo[Stages].MoveKind == movekind.whiteMaic)
                {
                if (memeory.epilepsyMode == false)
                {
                    Efects[0].SetActive(true);
                }
       sound.soundEfeacts("puzzleSolved");
                for (int i = 0; i < combatText.turnInfo.Count; i++)
                {

                    if (combatText.turnInfo[Stages].monster == false && combatText.turnInfo[i].monster == false)
                    {
                        turnAct[1] += combatText.turnInfo[i].Stats.Name + " restores " + combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Atack + "HP" + "\n";
                        combatText.turnInfo[i].Stats.currentHealth += combatText.turnInfo[Stages].Stats.Moves[TheMove[0]].Atack;
                    }

                }
            }
        }

        }

    public void flashingScreen()
    {
 
        if(memeory.epilepsyMode == false)
        {
        Efects[0].SetActive(true);
        }
        if (memeory.epilepsyMode == true)
        {
            reading[1] = false;
        }

    }

    IEnumerator wait()
    {
        reading[0] = true;
        yield return new WaitForSeconds(time);
        reading[0] = false;
    }
}
