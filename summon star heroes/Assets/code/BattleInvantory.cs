using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleInvantory : MonoBehaviour {
    public Inventory TheInvantory;
    public EquipM EquipItems;
    public stasM Stats;
    public turnWacher players;
    public GameObject[] sleact;
    public Text[] invantoryText;
    public Text[] Amount;
    public int itemSLeact;
    public bool onlyKeys;
    public int maxItems;
    public GameObject[] next;
    public sound_effect_manager sound;
    private bool use;
    public turnWacher turn;
     void OnEnable()
    {
       
       use = false;
         maxItems = 0;
        EquipItems = FindObjectOfType<EquipM>();
        TheInvantory = FindObjectOfType<Inventory>();
        for (int i = 0; i < sleact.Length; i++)
        {
            sleact[i].SetActive(i == 0);
            if (i < TheInvantory.items.Count)
            {
                invantoryText[i].text = "";
                Amount[i].text = "";
                if (TheInvantory.items[i].IteamKind == Items.inventory.Food|| TheInvantory.items[i].IteamKind == Items.inventory.Atack)
                {
                     Amount[maxItems].text = "X"+TheInvantory.items[i].Amount;
                    invantoryText[maxItems].text = TheInvantory.items[i].ItemName;
                   maxItems++;                    
                }
            }
        

        }
        if(maxItems == 0)
        {
            invantoryText[0].text = "No iteams";

        }


    }



    // Update is called once per frame
    void Update()
    {
         
        if (Input.GetKeyDown(KeyCode.X))
        {
            next[0].SetActive(true);
            gameObject.SetActive(false);
       sound.soundEfeacts("no");
        }
        #region menu
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (itemSLeact < maxItems - 1)
            {
                sleact[itemSLeact].SetActive(false);
                itemSLeact += 1;
                sleact[itemSLeact].SetActive(true);
            }
            else
            {
                itemSLeact = maxItems - 1;
            }
            sound.soundEfeacts("select");
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (itemSLeact > 0)
            {
                sleact[itemSLeact].SetActive(false);
                itemSLeact -= 1;
                sleact[itemSLeact].SetActive(true);
            }
            if (itemSLeact == 0)
            {
                itemSLeact = 0;
            }
            sound.soundEfeacts("select");

        }
        #endregion



        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(use == false)
            {
    ///turn.turnInfo[parrty.turnNumber].MoveToUse  = invantoryText[itemSLeact].text;
            //turn.turnInfo[parrty.turnNumber].MoveKind = movekind.Items; 
            sound.soundEfeacts("yes");
                serch();
                use = true;
            }
         
 
        }
    }
    public void serch()
    {
  for(int i = 0; i < TheInvantory.items.Count; ++i)
     //   {
       ///     if(TheInvantory.items[i].ItemName == turn.turnInfo[parrty.turnNumber].MoveToUse)
          ///  {
            ///    turn.turnInfo[parrty.turnNumber].TargetKind = TheInvantory.items[i].Target;

          //  }
       // }
        next[1].SetActive(true);
        gameObject.SetActive(false);
    }
    
}
