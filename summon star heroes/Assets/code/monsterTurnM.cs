using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monsterTurnM : MonoBehaviour
{

    public turnWacher turn;
    public stasM targets; 
    public void basicAtack()
    {
        int move = 0;
        int target = 0;




         for (int i =0; i != turn.turnInfo.Count; i++)
        {
            move = Random.Range(0, turn.turnInfo[i].Stats.Moves.Count);
            target = Random.Range(0, targets.Stats.Count - 1);
            if (turn.turnInfo[i].AtackInformation[3] == false)
            {
 
                if (turn.turnInfo[i].monster == true)
                {
             
                    turn.turnInfo[i].MoveInformation[0] = targets.Stats[target].Name;                   
                    turn.turnInfo[i].MoveInformation[2] = turn.turnInfo[i].Stats.Moves[move].monsterMoveInforamation;
                    if (turn.turnInfo[i].MoveInformation[2].Contains("PLAYER"))
                    {

                        turn.turnInfo[i].MoveInformation[2] = turn.turnInfo[i].MoveInformation[2].Replace("PLAYER",targets.Stats[target].Name);
                    }
                    turn.turnInfo[i].MoveInformation[1] = turn.turnInfo[i].Stats.Moves[move].MoveName;
                    turn.turnInfo[i].TargetKind = turn.turnInfo[i].Stats.Moves[move].Target[0];
                     if(turn.turnInfo[i].Stats.Name == turn.turnInfo[i].Stats.Name)
                    {
 
                        turn.turnInfo[i].MoveKind = movekind.Defence;

                    }
                    if (turn.turnInfo[i].Stats.Name != turn.turnInfo[i].MoveInformation[0])
                    {
                        turn.turnInfo[i].MoveKind = turn.turnInfo[i].Stats.Moves[move].moveKind;
                    }

                }
            }
         
        }    
    }
     
 
    }
 

 
