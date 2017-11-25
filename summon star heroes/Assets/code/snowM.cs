using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowM : MonoBehaviour {
    public sound_effect_manager sound;
    public PlayerMemory memory;
    public GameObject [] stages;
    public textImport text;
    public textImport flower;
    public hitBox []hitboxs;
    public walk walking;
    [Header("snow cuteen")]
    public int cuteen;
    public npcmovement guy;
    public bool taking;
    public GameObject[] texts;
    public string[] Nextlevel;
    public AudioClip voce;
    public AudioSource soundTrack;
    public GameObject blackscreen;
    public bool wait;
    public hitBox []exit;
    public string [] room;
    private int role;
    public clock theCLock;
    public List<Items> cheapjoke = new List<Items>();
    public Inventory stuf;
    public bool Hasiteam;
    private int flowerint;
    public GameObject talkingflower;
    public bool loaded;
    public GameObject bossbattle;
   
    // Use this for initialization
    void Start () {
        walking = FindObjectOfType<walk>();
        memory = FindObjectOfType<PlayerMemory>();
        stuf = FindObjectOfType<Inventory>();
    
        foreach (GameObject level in stages)
        {
            level.SetActive(false);
        }
        #region snow cutsen
        if (memory.stage[2].stagecomplated == 0)
        {
            for(int i = 0; i<texts.Length; i++)
            {
                texts[i].SetActive(i == 0);
            }
            stages[0].SetActive(true);
            guy.walkDirection = movement.up;


        }
        #endregion
        if (memory.stage[2].monstersInTheRoom >0 && memory.hacked == true && memory.stage[2].stagecomplated == 1)
        {
            AmuseMe();
         }
        stages[1].SetActive(memory.stage[2].BossBattles[0] == false);
    


    }
    public void AmuseMe()
    {


        if ( memory.PlayerName == "Pall" || memory.PlayerName == "Chungus")
        {
            Debug.Log("hello my name is pall");
            stages[2].SetActive(true);
        }
        if (memory.PlayerName == "Papyru")
        {
 
            if(memory.stage[1].puzzles[2].puzzleSloved[2] == false)
            {
            stages[3].SetActive(true);
            }            
        }

    }

    // Update is called once per frame
    void Update () {
       if(memory.stage[2].stagecomplated >=1)
        {
    #region snowseen
        if (memory.stage[2].stagecomplated == 0)
        {
            if (cuteen == 0 && hitboxs[0].inTheBox == true)
            {
                walking.playerpause();
                talking();
            }
            if (cuteen >= 1)
            {
                if (text.finshed == true && wait == false)
                {
                    talking();
                }
            }
        }
        #endregion
 
        #region it
        if (memory.stage[2].BossBattles[0] == false)
        {
            if(hitboxs[1].inTheBox == true)
            {
                if(memory.stage[2].puzzles[1].puzzleSloved[0] == false)
                {
                    if (memory.PlayerName == "Pall")
                    {
                        stuf.items.Add(cheapjoke[0]);
                    }
                    if (memory.PlayerName == "Chungus")
                    {
                        stuf.Gold = 9999;
                    }
                }
          memory.stage[2].puzzles[1].puzzleSloved[0] = true;
         stages[2].SetActive(false);
        sound.soundEfeacts("useIteam");
         }                      
        }
        #endregion
        #region her
        if (memory.stage[2].BossBattles[0] == false)
        {
            if (hitboxs[3].inTheBox == true)
            {
                if(loaded == false)
                {
                var black = Instantiate(blackscreen, new Vector3(0, 0, 0), Quaternion.identity);
                    memory.MonsterFightingID.Add(bossbattle);
                    memory.loadRoom(room[2], false, false);
                    loaded = true;
                }


            }
        }
        if (memory.stage[2].puzzles[1].puzzleSloved[1] == false)
        {
            if (hitboxs[2].inTheBox == true)
            {

                if (flowerint == 0)
                {
                    sound.soundEfeacts("select");
                    stuf.items.Add(cheapjoke[1]);
                    stuf.items.Add(cheapjoke[2]);
                    talkingflower.SetActive(true);
                    flowerint = 1;
                    wait = true;
                    StartCoroutine(waitforit());
                }
                if (flowerint == 1)
                {
                    if (wait == false)
                    {
                        if (flower.finshed == true)
                        {
                            memory.stage[2].puzzles[1].puzzleSloved[1] = true;
                            stages[3].SetActive(false);

                        }
                    }

                }

            }
            #endregion
        }  
        
        }
       #region exit
        if (exit[0].inTheBox == true)
        {
             memory.loadRoom(room[0],true,true);
        }
        if (exit[1].inTheBox == true)
        {
            memory.loadRoom(room[1], true,true);
            if(memory.stage[2].stagecomplated >= 1)
            {
                memory.stage[2].stagecomplated = 2;
            }
        }
        #endregion
     


    }
    public void talking()
    {
        switch (cuteen)
        {
            case 0:
                text.newline(true);
                cuteen++;
                break;
            case 1:
                if (memory.hacked == true)
                {
                    soundTrack.clip = voce;
                    soundTrack.Play();
                    texts[0].SetActive(false);
                    texts[1].SetActive(true);
                    text.curentDialogue = 2;
                    text.maxDialogue = 2;
                    text.newline(true);

                }
                if (memory.hacked == false)
                {
                    text.curentDialogue = 3;
                    text.maxDialogue = 3;
                    text.newline(true);
                }
                 cuteen++;
                break;
            case 2:
                wait = true;
                StartCoroutine(waitforit());
                cuteen++;
                break;
            case 3:
                memory.stage[2].stagecomplated += 1;
                var black = Instantiate(blackscreen, new Vector3(0, 0, 0), Quaternion.identity);
                black.gameObject.GetComponent<StartStage>().start = false;
                memory.loadRoom(Nextlevel[0], false,memory.hacked);
               
                break;
        }

    }
    IEnumerator waitforit()
    {

        yield return new WaitForSeconds(0.5f);
        wait = false;
    }
}
