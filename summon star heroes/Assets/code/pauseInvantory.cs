using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseInvantory : MonoBehaviour
{
    public GameObject[] menu;
    public Inventory iteams;
    public pauseMenu pause;
    public sound_effect_manager sound;
     public Image thepick;
    public Text[] infoSlot;
    public Text   ItemInfo;
    public int sleact;
    public bool noItems;
    public bool reading;
    public bool inuse;
    public float time;
    public int ID;
    public GameObject useIt;
     public GameObject itemsPick;
    public int readitNumber;
    public Text gold;


    void OnEnable()
    {
        useIt.SetActive(false);
        inuse = false;
                iteams = FindObjectOfType<Inventory>();
        gold.text = "Gold: " + iteams.Gold;

sleact = 0;
        foreach (Text item in infoSlot)
        {
            item.text = "";
        }

        if (iteams.items.Count == 0)
        {
            infoSlot[0].text = "no items";
            noItems = true;
            itemsPick.SetActive(false);
            ItemInfo.text = "no items";
        }
        else
        {

        startup();
        information();
        }

    }

    public void startup()
    {

 
        noItems = false;
        for (int i = 0; i < infoSlot.Length; i++)
        {
            menu[i].SetActive(i == 0);
            if (i < iteams.items.Count)
            {

                infoSlot[i].text = iteams.items[i].ItemName;
                if (iteams.items[i].Amount > 0)
                {
                    infoSlot[i].text += " X" + iteams.items[i].Amount;
                }
            }
        }
        itemsPick.SetActive(true);


    }






    void Update()
    {

        if(inuse == false)
        {
            #region back
            if (reading == false)
            {
         if (Input.GetButtonDown("BButton"))
        {
            pause.readingit();
            gameObject.SetActive(false);
        }
            }
            #endregion

            if (noItems == false)
            {
                if (Input.GetButtonDown("AButton"))
                {
                    ID = sleact;
                      time = 0;
                    Debug.Log("hit");
                    inuse = true;
                    useIt.SetActive(true);
                }
                if (Input.GetButtonDown("DownArrow"))
                {
                    menu[sleact].SetActive(false);
                    sleact = (sleact + 1) % iteams.items.Count;
                    menu[sleact].SetActive(true);
       sound.soundEfeacts("select");
                    information();

                }
                if (Input.GetButtonDown("UpArrow"))
                {
                    menu[sleact].SetActive(false);
                    if (sleact > 0)
                    {
                        sleact -= 1;
                        information();
                    }

                    menu[sleact].SetActive(true);
       sound.soundEfeacts("select");

                }
            }
            if(noItems == true)
            {
                if (Input.GetButtonDown("AButton"))
                {
       sound.soundEfeacts("no");
                }

            }

        }
        if(reading == true && inuse == false)
        {
            time += 0.1f;
            if(time >= 1)
            {
                reading = false;
 
            }
        }

    }
    public void information()
    {
        string words = iteams.items[sleact].ItemName + "\n" + iteams.items[sleact].Description + "\n";
 
       
        thepick.sprite = iteams.items[sleact].IteamPick;
        if(iteams.items[sleact].IteamKind == Items.inventory.Food)
        {
if(iteams.items[sleact].foodkind == Items.food.HP || iteams.items[sleact].foodkind == Items.food.HPandMP)
            {
                words += iteams.items[sleact].stats[0] + "Hp ";
            }
            if (iteams.items[sleact].foodkind == Items.food.MP || iteams.items[sleact].foodkind == Items.food.HPandMP)
            {
                words += iteams.items[sleact].stats[1] + "Mp";
            }
        }
     
        if (iteams.items[sleact].IteamKind == Items.inventory.Key)
        {
            words += "????";
        }
        ItemInfo.text = words;
    }
    public void used()
    {
 
        reading = true;
        inuse = false;
        useIt.SetActive(false);
    }

  
}

