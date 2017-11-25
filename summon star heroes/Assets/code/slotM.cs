using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slotM : MonoBehaviour {
     public lineCheker linesCheck;
    public bool diceRoleOver;
    private bool looking;
    public slot SLotSpeed;
    public PlayerMemory memory;

   
    // Use this for initialization
    void OnEnable()
    {
         memory = FindObjectOfType<PlayerMemory>();
        SLotSpeed.setSPeed(memory.cards[0].realoadSpeed,memory.cards[0].roleSpeed);
        looking = false;
        diceRoleOver = false;
 
 

    }

    void Update()
    {
        if (diceRoleOver == true)
        {
            if(looking == false)
            {
 
                linesCheck.checkwin();
                 looking = true;

            }
        }
    }
 
}
