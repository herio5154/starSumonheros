using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class moveSleact : MonoBehaviour {
    public enum moveTipe {inuse,Defence,NA}
    public Inventory TheInvantory;
    public moveTipe theMove;
    public turnWacher turn;
    public Text[] infoText;
    public Text Defence;
    public int MenuNav;
    public int ParttryID;
    public GameObject[] moves;
    public GameObject[] slect;
    public GameObject Back;
    public bool defence;
   public int moveCount = 0;
    public bool reading;
    public sound_effect_manager sound;
    public GameObject target;
    public GameObject battle;
    public GameObject menu;
    public string[] Moveinfo;
    // Use this for initialization
    void OnEnable()
    {
        moveCount = 0;
        reading = true;
        StartCoroutine(readthis());
        MenuNav = 0;
        ParttryID = turn.ParttyMemberInuse;
        TheInvantory = FindObjectOfType<Inventory>();
        moves[0].SetActive(turn.turnInfo[ParttryID].MoveKind == movekind.Defence);
        moves[1].SetActive(turn.turnInfo[ParttryID].MoveKind != movekind.Defence);
        if (turn.turnInfo[ParttryID].MoveKind == movekind.Defence)
        {
            theMove = moveTipe.Defence;
   
            Defence.text = turn.turnInfo[ParttryID].Stats.Name + " gets ready for the next atack!!";
        }
       else
        {
            for(int i = 0; i<slect.Length; i++)
            {
                slect[i].SetActive(i == 0);
            }
            foreach (Text item in infoText)
            {
                item.text = "";
            }
        

            if (turn.turnInfo[ParttryID].MoveKind == movekind.Items)
            {
                foreach (Items stuff in TheInvantory.items)
                {
                    if (stuff.IteamKind == Items.inventory.Food)
                    {
                        infoText[moveCount].text = stuff.ItemName+" X "+ stuff.Amount;
                        Moveinfo[moveCount] = stuff.ItemName;
                        moveCount += 1;
                    }
                }

                if (moveCount == 0)
                {
                    Defence.text =  "No Items";
                    moves[0].SetActive(true);
                    moves[1].SetActive(false);
                    theMove = moveTipe.NA;

                }
                else
                {
                    theMove = moveTipe.inuse;
                }

            }
            else
            {
             foreach(AtackList move in turn.turnInfo[ParttryID].Stats.Moves)
                {
                    if(move.moveKind == turn.turnInfo[ParttryID].MoveKind)
                    {
                        
                        if (move.moveKind == movekind.BlackMajic || move.moveKind == movekind.whiteMaic)
                        {
                            infoText[moveCount].text = move.MoveName + "MP:"+ move.Cost;
                        }
                        if (move.moveKind == movekind.Attack)
                        {
                            infoText[moveCount].text = move.MoveName + "  "+ Mathf.Round(move.Hit/100* 100)+ "%hit";
                        }
                        Moveinfo[moveCount] = move.MoveName;

                        moveCount += 1;
                    }
                }
              
                if (moveCount == 0)
                {
                    Defence.text =  "No avable moves";
                    moves[0].SetActive(true);
                    moves[1].SetActive(false);
                    theMove = moveTipe.NA;

                }
                else
                {
                    theMove = moveTipe.inuse;
                }
            }
        }
         


	}
	
	// Update is called once per frame
	void Update () {
        if(reading == false)
        {
      if (theMove != moveTipe.NA)
        {
                if(theMove != moveTipe.Defence)
                {
                    if (Input.GetButtonDown("DownArrow"))
                    {

                        sound.soundEfeacts("select");
                        slect[MenuNav].SetActive(false);
                        MenuNav = (MenuNav + 1) % moveCount;
                        slect[MenuNav].SetActive(true);


                    }
                    if (Input.GetButtonDown("UpArrow"))
                    {
                        sound.soundEfeacts("select");
                        slect[MenuNav].SetActive(false);
                        if (MenuNav > 0)
                        {
                            MenuNav -= 1;
                        }
                        slect[MenuNav].SetActive(true);


                    }
                    if (Input.GetButtonDown("AButton"))
                    {
                        sound.soundEfeacts("yes");
                        reading = false;
                        turn.turnInfo[ParttryID].MoveInformation[1] = Moveinfo[MenuNav];
                        Debug.Log(turn.turnInfo[ParttryID].MoveInformation[1]);
                        lookForAthing();
                    }
                }
                else
                {
                    if (Input.GetButtonDown("AButton"))
                    {
                        turn.next();
                      }
                }


            }

            if (Input.GetButtonDown("BButton"))
            {
                if (turn.turnInfo[turn.ParttyMemberInuse].MoveKind == movekind.Items)
                {
                    menu.SetActive(true);
                }
                else
                {
                Back.SetActive(true);
                }
                gameObject.SetActive(false);
       sound.soundEfeacts("no");
            }
        }
  
    }
    IEnumerator readthis()
    {
        yield return new WaitForSeconds(0.5f);
        reading = false;
    }
    public void lookForAthing()
    {
        if (turn.turnInfo[ParttryID].MoveKind == movekind.Items)
        {
            for (int i = 0; i < TheInvantory.items.Count; i++)
            {
                if(TheInvantory.items[i].ItemName == turn.turnInfo[ParttryID].MoveInformation[1])
                {
                    turn.turnInfo[ParttryID].TargetKind = TheInvantory.items[i].Target;

                }
            }

        }
        else
        {
            for (int i = 0; i < turn.turnInfo[ParttryID].Stats.Moves.Count; i++)
            {
                if (turn.turnInfo[ParttryID].Stats.Moves[i].MoveName == turn.turnInfo[ParttryID].MoveInformation[1])
                {
                    turn.turnInfo[ParttryID].TargetKind = turn.turnInfo[ParttryID].Stats.Moves[i].Target[0];
 
                }
            }
        }
        target.SetActive(true);
        gameObject.SetActive(false);
       }


}