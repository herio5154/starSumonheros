using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class lineCheck  {
    public lineWin kindofwin;
    public bool win;
    public targetKind Cardkind;
    public slot [] Slots;
    public vaule CardVaule;
    public int cardBaseVaule;
    


    public void checkLine()
    {
        win = false;
        if (Slots[1].Number == Slots[0].Number && Slots[2].Number == Slots[0].Number)
        {    
            win = true;
            cardBaseVaule = Slots[1].baseValue;
        }
    }
  
}
