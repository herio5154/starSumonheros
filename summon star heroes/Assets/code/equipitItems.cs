using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class equipitItems : MonoBehaviour {
    public GameObject[] menu;
    public EquipM Eqiptment;
    public Inventory iteams;
    public Text [] playerstats;
    public PlayerMemory memory;
    public pauseMenu pause;
    public sound_effect_manager sound;
    public Image mugShot;
    public Text[] infoSlot;
    public Text[] stats;
    public int sleact;
    public bool noItems;
    public bool read;
    public bool inuse;
    public float time;
    public int readitNumber;
    public bool noIteams;
    public int partty;
    public float []difrence;
    public equipped tocheck;
    int cout;
    public string exqipit;
    public GameObject used;
    public Text itemText;
    public Text theitemText;
    public Image Pick;
    public Text infoText;
    // Use this for initialization
    void OnEnable()
    {
        infoText.text = "";
        noIteams = true;
        inuse = false;
        used.SetActive(false);
        Eqiptment = FindObjectOfType<EquipM>();
        memory = FindObjectOfType<PlayerMemory>();
        iteams = FindObjectOfType<Inventory>();
        swap();
        sleact = 0;
         cout = 0;
        for(int i = 0; i<infoSlot.Length; i++)
        {
            menu[i].SetActive(i == 0);
            infoSlot[i].text = "";
            if(i<iteams.items.Count)
            {
               if(iteams.items[i].IteamKind == Items.inventory.Equip)
                {
                    infoSlot[cout].text = iteams.items[i].ItemName;
                    cout++;
                    noIteams = false;
                }
            }
        }
        if(noIteams == true)
        {
             infoSlot[0].text = "no Items";
 foreach(Text words in stats)
            {
                words.text = "" + 0;
            }

        }
        if (noIteams == false)
        {
            checkStats();
        }
        Pick.gameObject.SetActive(noIteams == false);

    }
    public void checkStats()
    {
        for(int X = 0; X<difrence.Length; X++)
        {
            difrence[X] = 0;
        }        

        if(noIteams == false)
        {
 
            for(int i = 0; i< iteams.items.Count; i++)
            {
             if(infoSlot[sleact].text == iteams.items[i].ItemName)
                {
                    infoText.text = iteams.items[i].Description + "\n" + iteams.items[i].weponKind;
                    Pick.sprite = iteams.items[i].IteamPick;
                    tocheck = iteams.items[i].EquipKind;
                    if (iteams.items[i].stats[0] >= 0)
                    {
                    difrence[0] = iteams.items[i].stats[0];
                    }
                    if (iteams.items[i].stats[1] >= 0)
                    {
                        difrence[1] = iteams.items[i].stats[1];
                    }
                    if (iteams.items[i].stats[2] >= 0)
                    {
                        difrence[2] = iteams.items[i].stats[2];
                         
                    }
                    if (iteams.items[i].stats[5] >= 0)
                    {
                        difrence[3] = iteams.items[i].stats[5];
                      
                    }
                    if (iteams.items[i].stats[4] >= 0)
                    {
                        difrence[4] = iteams.items[i].stats[4];
                    }
                    if (iteams.items[i].stats[4] >= 0)
                    {
                        difrence[5] = iteams.items[i].stats[3];
                    }
                    if(iteams.items[i].EquipKind == equipped.weapon)
                    {
                    if (memory.Partty[partty].weponKind == iteams.items[i].weponKind)
                    {
                        difrence[2] += 1;
                        difrence[3] += 1;
                    }
                    }
                    
                }
            }
         for(int z = 0; z< memory.Partty[partty].equipment.Count; z++)
            {
                if(memory.Partty[partty].equipment[z].EquipKind ==  tocheck )
                {
                    difrence[0] -= memory.Partty[partty].equipment[z].stats[0];
                    difrence[1] -= memory.Partty[partty].equipment[z].stats[1];
                    difrence[2] -= memory.Partty[partty].equipment[z].stats[2];
                    difrence[3] -= memory.Partty[partty].equipment[z].stats[5];
                    difrence[4] -= memory.Partty[partty].equipment[z].stats[4];
                    difrence[5] -= memory.Partty[partty].equipment[z].stats[3];
                }
            }
          for(int i = 0; i< stats.Length; i++)
            {
                stats[i].text = "";
                if (difrence[i] > 0)
                {
                    stats[i].text = " +";
                }
                stats[i].text += "" + difrence[i];

                if (difrence[i] == 0)
                {
                    stats[i].text  = "-";

                }

            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if(inuse == false)
        {
            if (Input.GetButtonDown("BButton"))
            {
                pause.readingit();
                gameObject.SetActive(false);
                Debug.Log("im hit");
            }
        }
      if(inuse == false)
        {
            if (Input.GetButtonDown("RightArrow"))
            {
       sound.soundEfeacts("select");
                time = 0;
                read = true;
                if(memory.Partty.Count >1)
                {
                partty = (partty + 1) % memory.Partty.Count;
                swap();
                }
            }
            if (Input.GetButtonDown("LeftArrow"))
            {
       sound.soundEfeacts("select");
                time = 0;
                read = true;
                if (partty > 0)
                {
                    partty -= 1;
                }
                swap();
            }
        }
        if(noIteams == false)
        {
     #region not in use
        if (inuse == false)
        {

            if (read == false)
            {
                if (Input.GetButtonDown("AButton"))
                {
 
                     time = 0;
                     used.SetActive(true);
                    exqipit = memory.Partty[partty].Name + "Eqipits"+ infoSlot[sleact].text;
                    itemText.text = exqipit;
                    inuse = true;
                    read = true;
                    GiveItem();
                           sound.soundEfeacts("yes");
                   
                }
              
                if (Input.GetButtonDown("DownArrow"))
                {
                    menu[sleact].SetActive(false);
                    sleact = (sleact + 1) % cout;
                    menu[sleact].SetActive(true);
           sound.soundEfeacts("select");
                    checkStats();
                    time = 0;
                    read = false;
                }
                if (Input.GetButtonDown("UpArrow"))
                {
                    menu[sleact].SetActive(false);
                    if (sleact > 0)
                    {
                        sleact -= 1;
                    }
                    menu[sleact].SetActive(true);
           sound.soundEfeacts("select");
                    checkStats();
                    time = 0;
                    read = false;

                }
            }

         }
        #endregion
        #region inuse
        if(inuse == true)
        {
          if(read == false)
            {
                if (Input.GetButtonDown("AButton"))
                {
                           sound.soundEfeacts("yes");
                    pause.restart();
                    
                }
            }
        }
        if (read == true)
        {
            time += 0.1f;
            if (time >= 1)
            {
                read = false;
            }
        }
        #endregion
        }
   
    }
    public void GiveItem()
    {
        for(int i = 0; i<iteams.items.Count; i++)
        {
            if(infoSlot[sleact].text == iteams.items[i].ItemName)
            {
                iteams.items[i].Amount -= 1;
                Eqiptment.EquipmentTocheck.Add(iteams.items[i]);
                Eqiptment.ParttyMember = partty;
                Eqiptment.equpit();
                if(iteams.items[i].Amount <= 0)
                {
                    iteams.items.Remove(iteams.items[i]);
                }
            }
        }
    }
         public void swap()
    {
        mugShot.sprite = memory.Partty[partty].face;
        playerstats[0].text = memory.Partty[partty].Name +" level: "+ memory.Partty[partty].Level + "  uses  " + memory.Partty[partty].weponKind;
        playerstats[1].text = "Max HP: " + memory.Partty[partty].MaxHealth;
        playerstats[2].text = "Max MP: " + memory.Partty[partty].MaxMana;
        playerstats[3].text = "Attack: " + memory.Partty[partty].Attack;
        playerstats[4].text = "Majc: " + memory.Partty[partty].Majic;
        playerstats[5].text = "Speed: " + memory.Partty[partty].Speed;
        playerstats[6].text = "Defence: " + memory.Partty[partty].Defence;
        checkStats();
    }
}
