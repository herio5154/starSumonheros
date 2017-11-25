using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashingScreen : MonoBehaviour {

    private int couter;
    public int maxFlash;
    public sound_effect_manager sound;
    public battleM battle;
    // Use this for initialization
    void OnEnable()
    {
        couter = 0;
        battle.reading[1] = true;
	}

    public void stopFlashing()
    {
 
        if (couter < maxFlash)
        {
            couter += 1;
        }
        if(couter >= maxFlash)
        {
 
            battle.reading[1] = false;
            gameObject.SetActive(false);
        }


    }
   
}
