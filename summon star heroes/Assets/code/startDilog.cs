using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startDilog : MonoBehaviour {
    public turnWacher turn;
    public monsterTurnM Atacks;
     public Text text;
    public sound_effect_manager sound;
     void OnEnable()
    {
        

            Atacks.basicAtack();
        string Dialogue = "";
        turn.information = false;
        turn.start = false;
        foreach (AtackInfo card in turn.turnInfo)
        {
            card.checkstats();
            if (card.AtackInformation[3] == false)
            {
               
                Dialogue += card.MoveInformation[3];
              
                if (card.monster == true)
                {
                    Dialogue += card.Stats.Name+" "+ card.MoveInformation[2] + "\n";
                }
            }
        }
 
        text.text = Dialogue;
        

    }
    void OnDisable()
    {
       sound.soundEfeacts("select");
    }
}
