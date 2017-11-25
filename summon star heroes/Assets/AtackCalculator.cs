using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackCalculator : MonoBehaviour {
    public enum MoveTarget { random, lowestHp, HightHp, Fastest };
    public unitStats Moves;
    public AtackInfo AtackCard;
    public turnWacher turn;
    public MoveTarget TargetInfo;
    public int theTarget;
    public PlayerMemory AtackInfo;
     public bool monsters;    
    public int theMove;

     public void TargetPick()
    {
        if(turn == null)
        {
            turn = FindObjectOfType<turnWacher>();
        }
        if(AtackInfo == null)
        {
            AtackInfo = FindObjectOfType<PlayerMemory>();
        }
  if(TargetInfo == MoveTarget.random)
        {
            AtackCard.MoveInformation[0] = AtackInfo.Partty[Random.Range(0, AtackInfo.Partty.Count - 1)].Name;
            Debug.Log(AtackCard.MoveInformation[0]);
         }
    
    }
    public void Atackcoulataor()
    {
        for(int i=0; i<Moves.Moves.Count; i++)
        {

        }
    }   
}
