using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPM : MonoBehaviour {
    public unitStats stats;

    public List<Levelup> skilltree = new List<Levelup>();
    public string expText;
    public int skillcouter;
    public float ExpAttack;
    public float ExpDefence;
    public float ExpSpeed;
    public float ExpMajic;
    public float ExpMana;
    public float ExpHelth;
    public float CurentExp;
    public float ExpNeeded;
    public int expMulatply;
    public int MaxLevel;
     // Use this for initialization

    public void levelup(float ExpGiven)
    {
        CurentExp += ExpGiven;
        Debug.Log(ExpGiven);
        if(stats.Level<MaxLevel)
        {
            if (CurentExp >= ExpNeeded)
            {
                stats.Level += 1;
                CurentExp -= ExpNeeded;
                ExpNeeded = ExpNeeded + expMulatply;
                stats.MaxHealth += ExpHelth;
                stats.MaxMana += ExpMana;
                stats.Majic += ExpMajic;
                stats.Attack += ExpSpeed;
                stats.Defence += ExpDefence;
                stats.Speed += ExpSpeed;
                expText += "\n"+  stats.Name + " is now level " + stats.Level + "\n";
                if (skillcouter < skilltree.Count)
                {
                    if (stats.Level == skilltree[skillcouter].levelReqired)
                    {
                        expText += stats.Name + " learnt " + skilltree[skillcouter].SkillName + "\n";
                        stats.Moves.Add(skilltree[skillcouter].skill[0]);
                        skillcouter += 1;
                    }
                }
            }
        }

        }
    public void AutoLevel(int Multyplier)
    {
        float oldLevel = stats.Level;
        float newLevel = oldLevel + Multyplier;
       
        #region Level up
        if(newLevel <MaxLevel)
        {
    
            stats.Level += Multyplier;

            if (ExpHelth > 0)
            {
                stats.MaxHealth += ExpHelth * Multyplier;
                stats.currentHealth = stats.MaxHealth;
            }
            if (ExpMana > 0)
            {
                stats.MaxMana += ExpMana * Multyplier;
                stats.currentMana += stats.MaxMana;
            }
            if (ExpMajic > 0)
            {
                stats.Majic += ExpMajic * Multyplier;
            }
            if (ExpAttack > 0)
            {
                stats.Attack += ExpSpeed * Multyplier;
            }
            if (ExpDefence > 0)
            {
                stats.Defence += ExpDefence * Multyplier;
            }
            if (ExpSpeed > 0)
            {
                stats.Speed += ExpSpeed * Multyplier;
            }

            if (ExpHelth < 0)
            {
                stats.MaxHealth += 1;
            }
            if (ExpMana < 0)
            {
                stats.MaxMana += 1;
            }
            if (ExpMajic < 0)
            {
                stats.Majic += 1;
            }
            if (ExpAttack < 0)
            {
                stats.Attack += 1;
            }
            if (ExpDefence < 0)
            {
                stats.Defence += 1;
            }
            if (ExpSpeed < 0)
            {

                Debug.Log("hit");
                stats.Speed += 1;
            }
            expText += stats.Name + " is now level " + stats.Level + "\n";
            #endregion
            for (float i = oldLevel; i < newLevel; i++)
            { 
               if(skillcouter <skilltree.Count)
                {

                    if (i == skilltree[skillcouter].levelReqired)
                    {
 
                        expText += stats.Name + " learnt   " + skilltree[skillcouter].SkillName + "\n";
                        stats.Moves.Add(skilltree[skillcouter].skill[0]);
                        skillcouter += 1;
                    }
                }
            }
        }
       
 
    }


}








