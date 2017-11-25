using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveGameM : MonoBehaviour {
    public PlayerMemory SaveFile;
    public GameObject[] menus;
    public GameObject[] stars;
    public sound_effect_manager sound;
    public walk PlayerWalk;
    public pause pause;
    public int menu;
    public int saveStage;
    private bool reading;
 	// Use this for initialization

    void OnEnable()
    {
        menus[0].SetActive(true);
        menus[1].SetActive(false);
        saveStage = 0;
        menu = 0;
        PlayerWalk = FindObjectOfType<walk>();
        pause.menuOn = true;
        PlayerWalk.playerpause();
        SaveFile = FindObjectOfType<PlayerMemory>();
        stars[0].SetActive(true);
        stars[1].SetActive(false);
        reading = true;
        StartCoroutine(readingit());
    }
    public void themenus()
    {
    
        if (saveStage == 1)
        {
            sound.soundEfeacts("yes");
            gameObject.SetActive(false);

        }
        if (saveStage == 0)
        {
            if (menu == 0)
            {
                menus[0].SetActive(false);
                menus[1].SetActive(true);
                SaveFile.save();
                sound.soundEfeacts("puzzleSolved");
                reading = true;
                StartCoroutine(readingit());
                saveStage = 1;
            }
            if (menu == 1)
            {
                sound.soundEfeacts("no");
                gameObject.SetActive(false);

            }
        }
    }
        // Update is called once per frame
    void Update () {

        if(reading == false)
        {
            if (Input.GetButtonDown("AButton"))
            {
                themenus();         
            }     
        }
        if (Input.GetButtonDown("BButton"))
        {
            gameObject.SetActive(false);
        }
        if (Input.GetButtonDown("UpArrow"))
        {
           sound.soundEfeacts("select");
            stars[0].SetActive(true);
            stars[1].SetActive(false);
            menu = 0;
        }
        if (Input.GetButtonDown("DownArrow"))
        {
            sound.soundEfeacts("select");
            stars[0].SetActive(false);
            stars[1].SetActive(true);
            menu = 1;

        }
    }
    void OnDisable()
    {
        pause.menuOn = false;
        PlayerWalk.playergo();
    }
    IEnumerator readingit()
    {
        reading = true;
        yield return new WaitForSeconds(1);
        reading = false;
    }
}
