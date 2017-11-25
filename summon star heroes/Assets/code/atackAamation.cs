using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atackAamation : MonoBehaviour {

    public AudioSource soundEfeact;
    public AudioClip AtackSound;
    public battleM battleM;
    public int couter;
    public int deathCout;


  
    public void end()
    {
         battleM.flashingScreen();
        Destroy(gameObject);
    }
    public void hit()
    {
        soundEfeact.PlayOneShot(AtackSound, 1.0F);
    }


}
