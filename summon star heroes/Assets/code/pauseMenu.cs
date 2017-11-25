using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject[] menu;
    public GameObject[] menuItems;
    public pause pasued;
    public int menuNumber;
    public bool inuse;
    public bool backscreen;
    public bool reading;
    public int time;
    public bool useing;

    public sound_effect_manager sound;
      // Use this for initialization
    void OnEnable()
    {
        pasued.menuOn = true;
         menuNumber = 0;
        for(int i = 0; i<menu.Length; i++ )
        {
            menu[i].SetActive(i == 0);
            if(i<menuItems.Length)
            {
               menuItems[i].SetActive(false);
            }
        }
        reading = false;

    }
    // Update is called once per frame
    void Update()
    {

         if (inuse == false)
        {
            
 
            if (Input.GetButtonDown("AButton"))
            {
                menu[menuNumber].SetActive(false);
                menuItems[menuNumber].SetActive(true);
       sound.soundEfeacts("yes");
                inuse = true;
                reading = true;
            }
            if (Input.GetButtonDown("BButton"))
            {
                if (reading == false)
                {
                back();
                    Debug.Log("hit");
                }
           }
            if (Input.GetButtonDown("UpArrow"))
            {
       sound.soundEfeacts("select");
                menu[menuNumber].SetActive(false);
                if(menuNumber >0)
                {
                    menuNumber -= 1;
                }
                 menu[menuNumber].SetActive(true);
            }
            if (Input.GetButtonDown("DownArrow"))
            {              
       sound.soundEfeacts("select");
                menu[menuNumber].SetActive(false);
               menuNumber = (menuNumber + 1)% menu.Length;              
                menu[menuNumber].SetActive(true);
            }
           if(reading == true)
            {
                time++;
                if(time >= 5)
                {
                    reading = false;
                    time = 0;
                }
            }
        }
    
    
}
    public void back()
    {
         foreach (GameObject item in menuItems)
        {
            item.SetActive(false);
        }
        pasued.itsoff();
               sound.soundEfeacts("no");
        inuse = false;
        reading = true;
       
     }
    public void restart()
    {
        menuItems[menuNumber].SetActive(false);
        menuItems[menuNumber].SetActive(true);
    }

    public void readingit()
    {
               sound.soundEfeacts("no");
        menuNumber = 0;
        menu[menuNumber].SetActive(true);
        inuse = false;
        time = 0;
        reading = true;
    }
 
  
}
   

