using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum roleOutcome { noWin, win,lose,draw,Fight}
 
public class ActTurn : MonoBehaviour {
    public turnWacher Win;
     public GameObject [] turns;
    public slotM theSLots;
    public roleOutcome ActOutCome;
    public List<lineCheck> victoryCard = new List<lineCheck>();
    public bool turnover;
    public bool Act;
       // Use this for initialization
    void OnEnable()
    {
         Act = false;
        turnover = false;
        for(int i = 0; i<turns.Length; i++)
        {
            turns[i].SetActive(i == 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(turnover == false)
        {
            if (Input.GetButtonDown("AButton"))
            {
                if (Act == false)
            {
                theSLots.diceRoleOver = true;
              }
             if(Act == true)
            {
                turns[0].SetActive(false);
                turns[1].SetActive(true);
                    turnover = true;
            }
        }
    
        }

    }
    public void wincheck()
    {
        Act = true;
    }
     }
