using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Dead : MonoBehaviour {
    public PlayerMemory memory;
    public GameObject[] sleact;
    public GameObject player;    
     public string[] rooms;
    public int couter;
    public sound_effect_manager sound;

    // Use this for initialization
    void Start()
    {
        couter = 0;
        memory = FindObjectOfType<PlayerMemory>();
        player = memory.gameObject;
        sleact[0].SetActive(true);
        sleact[1].SetActive(false);
        foreach(unitStats player in memory.Partty)
        {
            player.currentHealth = player.MaxHealth;
            player.atackCard.AtackInformation[3] = false;
        }
 
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("DownArrow"))
        {
            sleact[couter].SetActive(false);
            couter = 1;
            sleact[couter].SetActive(true);
        }
        if (Input.GetButtonDown("UpArrow"))
        {
            sleact[couter].SetActive(false);
            couter = 0;
            sleact[couter].SetActive(true);
       sound.soundEfeacts("select");

        }
        if (Input.GetButtonDown("AButton"))
        {

            switch (couter)
            {
                case 0:
                    if(memory.MonsterFightingID[0].GetComponent<monsterSheat>().kindofBattle == battleKInds.boss)
                    {
                        memory.loadRoom(rooms[0], false, false);
                    }
                    if (memory.MonsterFightingID[0].GetComponent<monsterSheat>().kindofBattle != battleKInds.boss)
                    {
                        memory.loadRoom(memory.MonsterFightingID[0].GetComponent<monsterSheat>().stagetoGoback, true, true);
                    }
                    break;
                case 1:
                    Destroy(player);
                    SceneManager.LoadScene(rooms[1]);
                    break;
            
            }

       sound.soundEfeacts("yes");

        }

        }
    }
    

