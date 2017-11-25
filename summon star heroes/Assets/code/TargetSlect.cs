using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TargetSlect : MonoBehaviour {
    public sound_effect_manager sound;
    public turnWacher turn;
    public Text[] theText;
    public GameObject [] menu;
    public int MenuNav;
    public int menuCount;
    public GameObject back;
    public Text [] hpText;
    public float number;
    // Use this for initialization
    void OnEnable()
    {
        MenuNav = 0;
        menuCount = 0;
  
        for (int i = 0; i < theText.Length; i++)
        {
            theText[i].text = "";
            hpText[i].text = "";
             menu[i].SetActive(i == 0);   
        }
        if (turn.turnInfo[turn.ParttyMemberInuse].TargetKind != targetKind.All)
        {
            foreach (AtackInfo unit in turn.turnInfo)
            {
                if(unit.AtackInformation[3] == false)
                {
              if (turn.turnInfo[turn.ParttyMemberInuse].TargetKind == targetKind.Enemy)
                {
                        if(unit.Stats.currentHealth >0)
                        {
                            if (unit.monster == true)
                            {
                                theText[menuCount].text = unit.Stats.Name;
                                number = (Mathf.Round(unit.Stats.currentHealth / unit.Stats.MaxHealth * 100));

                                hpText[menuCount].text = number + "% HP";
                                menuCount++;
                            }
                        }
                        if (turn.turnInfo[turn.ParttyMemberInuse].TargetKind == targetKind.Player)
                        {
                            if (unit.monster == false)
                            {
                                theText[menuCount].text = unit.Stats.Name;
                                menuCount++;
                            }
                        }
                    }
                
                }
                

            }
        }
        if (turn.turnInfo[turn.ParttyMemberInuse].TargetKind == targetKind.All)
        {
            theText[menuCount].text = "All";
            foreach(AtackList Atack  in turn.turnInfo[turn.ParttyMemberInuse].Stats.Moves)
            {
                if(Atack.MoveName == turn.turnInfo[turn.ParttyMemberInuse].MoveInformation[1])
                {
                    if(Atack.Target[1] == targetKind.Enemy)
                    {
                        theText[menuCount].text += " Enemys";
                    }
                    if (Atack.Target[1] == targetKind.Player)
                    {
                        theText[menuCount].text += " Players";
                    }
                    if (Atack.Target[1] == targetKind.All)
                    {
                        theText[menuCount].text += "???? why";
                    }
                }
            }
        }


    }


    // Update is called once per frame
    void Update () {
        if(Input.GetButtonDown("DownArrow")|| Input.GetButtonDown("UpArrow"))
        {
            sound.soundEfeacts("select");
        }

        if (Input.GetButtonDown("DownArrow"))
        {

            menu[MenuNav].SetActive(false);
            MenuNav = (MenuNav + 1) % menuCount;
            menu[MenuNav].SetActive(true);
        }
        if (Input.GetButtonDown("UpArrow"))
        {
            menu[MenuNav].SetActive(false);
            if (MenuNav >0)
            {
                MenuNav -= 1;
            }
            menu[MenuNav].SetActive(true);      

        }
        if (Input.GetButtonDown("AButton"))
        {
             turn.turnInfo[turn.ParttyMemberInuse].MoveInformation[0] = theText[MenuNav].text;
             turn.next();
            sound.soundEfeacts("yes");

        }
        if (Input.GetButtonDown("BButton"))
        {
            back.SetActive(true);
            gameObject.SetActive(false);
            sound.soundEfeacts("no");
            Debug.Log("hit");
        }
    }
}
