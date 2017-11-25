using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour {
    public walk walking;
    public GameObject menu;
    public bool menuOn;
    public float off;
    public GameObject [] invantory;
    public sound_effect_manager sound;
      void Start()
    {
walking = FindObjectOfType<walk>();
    }
 
    // Update is called once per frame
    void Update () {

        if (Input.GetButtonDown("XButton"))
        {
            sound.soundEfeacts("select");
            if (walking.notMoveing == false)
            {               

                if (menuOn == false)
                {
                    Debug.Log("hit");
                    menu.SetActive(true);
                    menuOn = true;
                    Time.timeScale = 0f;

                }

            }
        }
      
    }
 
    
    IEnumerator turnoff()
    {
        menuOn = true;
            yield return new WaitForSeconds(off);
        menuOn = false;
        
    }
    public void itsoff()
    {
        menu.SetActive(false);
        StartCoroutine(turnoff());
        Time.timeScale = 1.0f;
        menuOn = false;


    }
   

}

