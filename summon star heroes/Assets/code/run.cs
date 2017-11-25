using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class run : MonoBehaviour {
    public string runText;
    public Text theText;
    public bool Runfail;
    public monsterSheat monster;
    public turnWacher turns;
    public GameObject battle;
    private bool reading;
    public PlayerMemory memory;
    /// <summary>
    /// 
    /// </summary>
    void OnEnable()
    {
        Runfail = false;
        reading = true;
        runText = "got away safely";
        StartCoroutine(readingIt());
        monster = FindObjectOfType<monsterSheat>();
        memory = FindObjectOfType<PlayerMemory>();
        int D100 = Random.Range(0,10);
        if(D100 == turns.turnInfo[0].Stats.LuckyNumber||monster.kindofBattle != battleKInds.noraml)
        {

                Runfail = true;
            
        }
        if(Runfail == true)
        {
            runText = "you failed to get away";
            if (monster.kindofBattle == battleKInds.boss)
            {
                runText = "you cant do this in a boss battle";
            }
         }
        theText.text = runText;
    }

    // Update is called once per frame
    void Update () {

        if (reading == false)
        {
            if (Input.GetButtonDown("AButton"))
            {
                if (Runfail == false)
                {
                    while(memory.MonsterFightingID.Count >0)
                    {
                        memory.MonsterFightingID.Remove(memory.MonsterFightingID[0]);
                    }
                    memory.loadRoom(monster.stagetoGoback,false,true);
                }
             if(Runfail == true)
                {
                    battle.SetActive(true);
                    gameObject.SetActive(false);
                }
            }

        }
    }
    IEnumerator readingIt()
    {
        yield return new WaitForSeconds(0.2f);
        reading = false;
    }
}
