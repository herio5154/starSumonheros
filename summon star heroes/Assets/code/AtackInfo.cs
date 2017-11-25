using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum movekind { NA, Attack, Defence, whiteMaic,BlackMajic, Items ,Act,Stats}

public class AtackInfo : MonoBehaviour
{
   // public string Name;
    public List<Items> itemsToUse = new List<Items>();
    public unitStats Stats;
    public movekind MoveKind;
    public targetKind TargetKind;
    [Tooltip("target == 0 MoveToUse == 1 movetext = 2 statsText = 3")]
    public string[] MoveInformation;
    public bool monster;
    [Tooltip("Miss == 0 criticalHit == 1 ElmentCriticalHit == 2 dead = 3")]
    public bool[] AtackInformation; 
     public List<StatsBoost> statsBost = new List<StatsBoost>();

    public void checkstats()
    {

        MoveInformation[3]  = "";
        for (int i = 0; i < statsBost.Count; i++)
        {
            statsBost[i].turnsLeft -= 1;
            if (statsBost[i].turnsLeft <= 0)
            {
                MoveInformation[3] = statsBost[i].Name + "was removed" + "\n";
                if (statsBost[i].buffkind == StatsBoost.buffs.Buff)
                {
                    if (statsBost[i].StatToChnange == StatsKind.Attack)
                    {
                        Stats.Attack -= statsBost[i].amount;
                    }
                    if (statsBost[i].StatToChnange == StatsKind.Defence)
                    {
                        Stats.Defence -= statsBost[i].amount;
                    }
                    if (statsBost[i].StatToChnange == StatsKind.Speed)
                    {
                        Stats.Speed -= statsBost[i].amount;
                    }
                    if (statsBost[i].StatToChnange == StatsKind.Majic)
                    {
                        Stats.Majic -= statsBost[i].amount;
                    }
                }
                if (statsBost[i].buffkind == StatsBoost.buffs.Debuff)
                {
                    if (statsBost[i].StatToChnange == StatsKind.Attack)
                    {
                        Stats.Attack += statsBost[i].amount;
                    }
                    if (statsBost[i].StatToChnange == StatsKind.Defence)
                    {
                        Stats.Defence += statsBost[i].amount;
                    }
                    if (statsBost[i].StatToChnange == StatsKind.Speed)
                    {
                        Stats.Speed += statsBost[i].amount;
                    }
                    if (statsBost[i].StatToChnange == StatsKind.Majic)
                    {
                        Stats.Majic += statsBost[i].amount;
                    }
                }
                statsBost.Remove(statsBost[i]);
            }
        }
    }
    public void clear()
    {
while(statsBost.Count >0)
        {
                    if(statsBost[0].buffkind == StatsBoost.buffs.Buff)
                {
                    if(statsBost[0].StatToChnange == StatsKind.Attack)
                    {
                        Stats.Attack -= statsBost[0].amount;
                    }
                    if (statsBost[0].StatToChnange == StatsKind.Defence)
                    {
                        Stats.Defence -= statsBost[0].amount;
                    }
                    if (statsBost[0].StatToChnange == StatsKind.Speed)
                    {
                        Stats.Speed -= statsBost[0].amount;
                    }
                    if (statsBost[0].StatToChnange == StatsKind.Majic)
                    {
                        Stats.Majic -= statsBost[0].amount;
                    }
                }
                if (statsBost[0].buffkind == StatsBoost.buffs.Debuff)
                {
                    if (statsBost[0].StatToChnange == StatsKind.Attack)
                    {
                        Stats.Attack += statsBost[0].amount;
                    }
                    if (statsBost[0].StatToChnange == StatsKind.Defence)
                    {
                        Stats.Defence += statsBost[0].amount;
                    }
                    if (statsBost[0].StatToChnange == StatsKind.Speed)
                    {
                        Stats.Speed += statsBost[0].amount;
                    }
                    if (statsBost[0].StatToChnange == StatsKind.Majic)
                    {
                        Stats.Majic += statsBost[0].amount;
                    }
                }
                statsBost.Remove(statsBost[0]);
        }
    }
}

