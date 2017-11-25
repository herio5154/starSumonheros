using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class useItem : MonoBehaviour
{
    public pauseInvantory back;
    public pauseMenu pause;
    public PlayerMemory memory;
    public EquipM Eqiptment;
    public Text infoText;
    public Inventory items;
    public sound_effect_manager sound;
    public bool key;
    public Text cantUse;
    public GameObject[] boxes;
    public GameObject[] starts;
    public bool useing;
    public Text[] theText;
    public bool reading;
    public int menuSlect;
    public float time;
    public Text used;
    public int theItem;
     void OnEnable()

    {
         memory = FindObjectOfType<PlayerMemory>();
        items = FindObjectOfType<Inventory>();

        foreach (GameObject item in boxes)
        {
            item.SetActive(false);
        }

        if (items.items.Count > 0)
        {
            Eqiptment = FindObjectOfType<EquipM>();
            theItem = back.ID;
            Debug.Log(items.items[theItem].ItemName);
            back.sleact = 0;
            useing = false;
            reading = false;

            if (items.items[theItem].IteamKind == Items.inventory.Key || items.items[theItem].IteamKind == Items.inventory.Atack)
            {
                boxes[0].SetActive(true);
                key = true;
                cantUse.text = "you cant use that right now" + "\n" + memory.Partty[0].Name;
            }
            else
            {
                boxes[1].SetActive(true);
                for (int i = 0; i < theText.Length; i++)
                {
                    starts[i].SetActive(i == 0);
                    theText[i].text = "";
                    if (i < memory.Partty.Count)
                    {
                        theText[i].text = memory.Partty[i].Name;
                    }
                }
            }
        }
        else
        {
            gameObject.SetActive(false);
        }



    }

    void Update()
    {


        if (key == true)
        {
            if (Input.GetButtonDown("AButton")|| Input.GetButtonDown("BButton"))
            {
                back.menu[theItem].SetActive(true);
                gameObject.SetActive(false);
                       sound.soundEfeacts("no");
            }
        }
        if (key == false)
        {
            if (useing == false)
            {
                if (Input.GetButtonDown("UpArrow"))
                {
                    starts[menuSlect].SetActive(false);
                    if (menuSlect > 0)
                    {
                        menuSlect -= 1;
                    }
                    starts[menuSlect].SetActive(true);
       sound.soundEfeacts("select");
                }
                if (Input.GetButtonDown("DownArrow"))
                {
                    starts[menuSlect].SetActive(false);
                    menuSlect = (menuSlect + 1) % memory.Partty.Count;
                    starts[menuSlect].SetActive(true);
       sound.soundEfeacts("select");
                }
                if (Input.GetButtonDown("BButton"))
                {
                           sound.soundEfeacts("no");
                    back.used();
                }
                if (Input.GetButtonDown("AButton"))
                {
                    useText();
                    reading = true;
                    useing = true;
                    boxes[2].SetActive(true);
                }
            }

            if (useing == true)
            {
                if (reading == false)
                {
                    if (Input.GetButtonDown("AButton"))
                    {
                        if (items.items[theItem].Amount <= 0)
                        {
                            items.items.Remove(items.items[theItem]);
                        }
                        if (items.items.Count < 0)
                        {
                            back.noItems = false;
                        }
                        pause.restart();
       sound.soundEfeacts("useIteam");
                        gameObject.SetActive(false);
                    }
                }
                if (reading == true)
                {

                    time++;
                    if (time >= 5)
                    {
                        if (items.items[theItem].IteamKind == Items.inventory.Equip)
                        {
                            Eqiptment.EquipmentTocheck.Add(items.items[theItem]);
                            Eqiptment.ParttyMember = menuSlect;
                            Eqiptment.equpit();
                        }
                        items.items[theItem].Amount -= 1;

                        reading = false;
                    }
                }
            }
        }





    }
    public void useText()
    {
        float HPToGive = 0;
        float MPToGive = 0;
        //int majicouter = 0;
        string itemWords = memory.Partty[menuSlect].Name;
        if (items.items[theItem].IteamKind == Items.inventory.Equip)
        { 
            itemWords += "Eqipits ";
        }
        else
        {
            itemWords += " uses ";
        }
        itemWords += "\n" + items.items[theItem].ItemName + "\n";
        #region books
        if (items.items[theItem].IteamKind == Items.inventory.Books)
        {
            Debug.Log("Fix this soon");

            if (memory.Partty[menuSlect].Moves.Count < 10)
            {
                itemWords += " And learnt" + items.items[menuSlect].MoveTOlurnName;
                Debug.Log("fix this");
            }

        }
        #endregion
        #region food
        if (items.items[theItem].IteamKind == Items.inventory.Food)
        {
            itemWords += " restors ";
            if (items.items[theItem].foodkind == Items.food.HP || items.items[theItem].foodkind == Items.food.HPandMP)
            {
                HPToGive = items.items[menuSlect].stats[0];
                if (HPToGive + memory.Partty[menuSlect].currentHealth > memory.Partty[menuSlect].MaxHealth)
                {
                    HPToGive = memory.Partty[menuSlect].currentHealth;
                  }
                memory.Partty[menuSlect].currentHealth += HPToGive;
                itemWords += " Hp " + HPToGive;
            }
            if (items.items[theItem].foodkind == Items.food.MP || items.items[theItem].foodkind == Items.food.HPandMP)
            {
                MPToGive = items.items[menuSlect].stats[1];
                if (MPToGive + memory.Partty[menuSlect].currentMana > memory.Partty[menuSlect].MaxMana)
                {
                    MPToGive = memory.Partty[menuSlect].MaxMana;
                    Debug.Log("im hit");
                }
                memory.Partty[menuSlect].currentMana += MPToGive;
                itemWords += " MP " + MPToGive;
            }
        }
        #endregion
        used.text = itemWords;
    }
}
 

