using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class sound_effect_manager : MonoBehaviour {

    public AudioSource soundEfeact;   
    public List<SoundEfeactCards> Soundefects = new List<SoundEfeactCards>();

    public void soundEfeacts(string soundID)
    {
 
        foreach (SoundEfeactCards Sounds in Soundefects)
        {
            if (Sounds.name == soundID)
            {
 
                soundEfeact.PlayOneShot(Sounds.SoundEfeact, 1.0F);
            }
        }

    }

     


 


}
