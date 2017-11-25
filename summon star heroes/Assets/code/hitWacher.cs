
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class hitWacher : MonoBehaviour {
    public battleM BattleWach;
    public Animator hit;
    public PlayerMemory memory;
    public unitStats stats;
    // Use this for initialization

    public void hitit()
    {   
        if(stats.currentHealth >0)
        {
     if(memory.epilepsyMode == true)
        {
           if(BattleWach.reading[0] == false)
            {
                hit.SetBool("Hit", false);
            }
        }
        if (memory.epilepsyMode == false)
        {
            if (BattleWach.reading[1] == false &&BattleWach.reading[0] == false)
        {
            hit.SetBool("Hit", false);
        }
        }
      }
        
    }
    public void battle()
    {
        hit.SetBool("Hit", true);

    }
  public void win()
    {
        hit.SetBool("win", true);

    }
    public void fade()
    {
        gameObject.SetActive(false);
    }



}
