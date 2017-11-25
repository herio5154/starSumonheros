using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuNav : MonoBehaviour {
    public GameObject[] MenuSelect;
    public GameObject [] menuItems;
    public GameObject back;
    public sound_effect_manager sound;
    public turnWacher turns;
    public int menuNumber;
    public int TurnInfo;
     // Use this for initialization
    void OnEnable()
    {
        menuNumber = 0;  
        for (int I = 0; I< MenuSelect.Length; I++)
        {
          MenuSelect[I].SetActive(I == 0);
        }

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("DownArrow"))
        {

            MenuSelect[menuNumber].SetActive(false);
                menuNumber = (menuNumber +1)% MenuSelect.Length;
                MenuSelect[menuNumber].SetActive(true);
            
        
       sound.soundEfeacts("select");
        }
        if (Input.GetButtonDown("UpArrow"))
        {
            MenuSelect[menuNumber].SetActive(false);
            if (menuNumber > 0)
            {
                menuNumber -= 1;
            }
            MenuSelect[menuNumber].SetActive(true);
       sound.soundEfeacts("select");

        }

        if (Input.GetButtonDown("AButton"))
        {
            nav();
            sound.soundEfeacts("yes");
        }
        if (Input.GetButtonDown("BButton"))
        {
       sound.soundEfeacts("no");
            backNAv();
        }


    }
    public void nav()
    {
        switch (TurnInfo)
        {
            case 0:
                moves();
                break;
            case 1:
                Atack();
                break;
    

        }

    }
    public void backNAv()
    {
        switch (TurnInfo)
        {
            case 0:
           sound.soundEfeacts("no");
                break;
            case 1:
                back.SetActive(true);
                gameObject.SetActive(false);
                break;
            case 2:
                Debug.Log("hit");
                back.SetActive(true);
                gameObject.SetActive(false);
                break;
        }

 
    }
  
    public void Atack()
    {
        switch (menuNumber)
        {
            case 0:
                turns.turnInfo[turns.ParttyMemberInuse].MoveKind = movekind.Attack;
                 break;
            case 1:
                  turns.turnInfo[turns.ParttyMemberInuse].MoveKind = movekind.whiteMaic;

                break;
            case 2:
                turns.turnInfo[turns.ParttyMemberInuse].MoveKind = movekind.BlackMajic;

                break;
            case 3:
                turns.turnInfo[turns.ParttyMemberInuse].MoveKind = movekind.Defence;
                turns.turnInfo[turns.ParttyMemberInuse].TargetKind = targetKind.Player;

                break;               
        }
        menuItems[0].SetActive(true);
        gameObject.SetActive(false);
    }
    public void moves()
    {
        switch (menuNumber)
        {
            case 0:
                turns.turnInfo[turns.ParttyMemberInuse].MoveKind = movekind.Attack;
                break;
            case 1:
                turns.turnInfo[turns.ParttyMemberInuse].MoveKind = movekind.Items;
                break;
            case 2:
                turns.turnInfo[turns.ParttyMemberInuse].MoveKind = movekind.Act;
                break;

        }
        menuItems[menuNumber].SetActive(true);
        gameObject.SetActive(false);
    }
}
