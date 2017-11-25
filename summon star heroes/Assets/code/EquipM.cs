using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EquipM : MonoBehaviour
{
    public List<Items> EquipmentTocheck = new List<Items>();
    public Inventory IteamToputBack;
    public PlayerMemory player;
     public int ParttyMember;
    public bool notFree;
    public int removeID;
    public bool found;

    public void equpit()     
    {
        found = false;
        if (player.Partty[ParttyMember].equipment.Count > 0)
        {
            for(int i = 0; i <player.Partty[ParttyMember].equipment.Count; i++)
            {
                if(EquipmentTocheck[0].EquipKind == player.Partty[ParttyMember].equipment[i].EquipKind)
                {
                     removeID = i;
                    found = true;

                }
            }           
           Add();
            if (found == true)
            {
                remove();
            }

        }
        if (player.Partty[ParttyMember].equipment.Count == 0)
        {
            Add();
         }
     

    }
    public void remove()
    {
        Debug.Log("woot");
        if(player.Partty[ParttyMember].equipment[removeID].EquipKind == equipped.weapon)
        {
if (player.Partty[ParttyMember].weponKind == player.Partty[ParttyMember].equipment[removeID].weponKind)
        {
             player.Partty[ParttyMember].Attack -= 2;
            player.Partty[ParttyMember].Majic -= 2;
        }
        }
        
        IteamToputBack.items.Add(player.Partty[ParttyMember].equipment[removeID]);
        player.Partty[ParttyMember].Attack -= player.Partty[ParttyMember].equipment[removeID].stats[2];
        player.Partty[ParttyMember].Defence -= player.Partty[ParttyMember].equipment[removeID].stats[3];
        player.Partty[ParttyMember].Speed -= player.Partty[ParttyMember].equipment[removeID].stats[4];
        player.Partty[ParttyMember].MaxHealth -= player.Partty[ParttyMember].equipment[removeID].stats[0];
        player.Partty[ParttyMember].MaxMana -= player.Partty[ParttyMember].equipment[removeID].stats[1];
        player.Partty[ParttyMember].Majic -= player.Partty[ParttyMember].equipment[removeID].stats[5];

        player.Partty[ParttyMember].equipment.Remove(player.Partty[ParttyMember].equipment[removeID]);
        
        
    }
    public void Add()
    {
      if(EquipmentTocheck[0].EquipKind == equipped.weapon)
        {
       if(player.Partty[ParttyMember].weponKind == EquipmentTocheck[0].weponKind)
            {
                player.Partty[ParttyMember].Attack += 2;
                player.Partty[ParttyMember].Majic += 2;
            }
        }
        player.Partty[ParttyMember].Attack += EquipmentTocheck[0].stats[2];
        player.Partty[ParttyMember].Defence += EquipmentTocheck[0].stats[3];
        player.Partty[ParttyMember].Speed += EquipmentTocheck[0].stats[4];
        player.Partty[ParttyMember].MaxHealth += EquipmentTocheck[0].stats[0];
         player.Partty[ParttyMember].MaxMana += EquipmentTocheck[0].stats[1];
        player.Partty[ParttyMember].Majic += EquipmentTocheck[0].stats[5];
        player.Partty[ParttyMember].equipment.Add(EquipmentTocheck[0]);
        EquipmentTocheck.Remove(EquipmentTocheck[0]);


    }


}
