using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActMenu : MonoBehaviour
{
    public PlayerMemory memory;
    public turnWacher turns;
    public sound_effect_manager sound;
     public GameObject[] star;
    public GameObject Act;
    private int menuNumber;
    public GameObject back;
    public GameObject Menu;
    public GameObject run;
    public GameObject[] theMenu;

    public int menucount;
     void OnEnable()
    {
         #region setUp
        menuNumber = 0;
        menucount = 0;
        memory = FindObjectOfType<PlayerMemory>();
        Act.SetActive(memory.hacked);

        for (int i = 0;i < star.Length; i++)
        {
        if(i < star.Length)
            {
                star[i].SetActive(i == 0);
                menucount++;
            }
           
        }
        if(memory.hacked == false)
        {
            menucount -= 1;

        }
        #endregion
    }
    void Update()
    {
        #region menu
        if (Input.GetButtonDown("DownArrow"))
        {
            star[menuNumber].SetActive(false);
            menuNumber = (menuNumber + 1) % menucount;
            star[menuNumber].SetActive(true);
            sound.soundEfeacts("select");
        }
        if (Input.GetButtonDown("UpArrow"))
        {
            if (menuNumber > 0)
            {
                star[menuNumber].SetActive(false);
                menuNumber -= 1;
                star[menuNumber].SetActive(true);
            }
            if (menuNumber <= 0)
            {
                menuNumber = 0;
            }
            sound.soundEfeacts("select");

        }
        if (Input.GetButtonDown("BButton"))
        {
            back.SetActive(true);
            gameObject.SetActive(false);
       sound.soundEfeacts("no");
        }
        #endregion

        if (Input.GetButtonDown("AButton"))
        {
            sound.soundEfeacts("yes");
            if (menuNumber == 0)
            {
                turns.turnInfo[turns.ParttyMemberInuse].MoveKind = movekind.Stats;
                turns.information = true;                
                turns.next();
            }
            if(menuNumber == 1)
            {
                turns.runforIt();
                run.SetActive(true);
                gameObject.SetActive(false);

            }
            if (menuNumber == 2)
            {
                turns.act();
 
             }


            }
        }
       

    }
    
     




