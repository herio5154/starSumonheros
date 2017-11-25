using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineCheker : MonoBehaviour {
    public ActTurn turn;
    public List<lineCheck> lines = new List<lineCheck>();
         void OnEnable()
    {
         for(int i = 0; i<lines.Count; i++)
        {
            lines[i].win = false;
        }
    }

    public void checkwin()
    {
        turn.ActOutCome = roleOutcome.draw;
        for (int i = 0; i<lines.Count; i++)
        {
            lines[i].checkLine();
            if(lines[i].win == true)
            {
                if (lines[i].Slots[1].Number == lines[i].Slots[0].Number&& lines[i].Slots[2].Number == lines[i].Slots[0].Number)
                {
                    if (lines[i].Slots[1].Card == lines[i].Slots[0].Card&& lines[i].Slots[2].Card == lines[i].Slots[0].Card)
                    {
                        if(lines[i].Slots[0].Card == targetKind.Player)
                        {
                            turn.ActOutCome = roleOutcome.win;
                          turn.victoryCard.Add(lines[i]);
                        }
                        if (lines[i].Slots[0].Card == targetKind.Enemy)
                        {
                            turn.ActOutCome = roleOutcome.lose;
                         }
                    }
                 }
            }
        }
        turn.wincheck();
        }
    }

    

