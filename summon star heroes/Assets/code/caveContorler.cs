using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caveContorler : MonoBehaviour {
    public PlayerMemory memory;
    public sound_effect_manager sound;
    public GameObject prince;
    public GameObject flower;
    public walk walking;
    public textImport text;
    public GameObject[] Rooms;
    public string[] NextStage;
    public GameObject[] npc;
    public hitBox [] exit;
     public GameObject exittext;
    public GameObject [] startPonits;
    public bool [] talking;
    private int talkiingText;
    public int role;
    public GameObject bolcokedDoor;
    public clock theCLock;
    public GameObject blackscreen;
    public bool inplay;
    public bool reading;
    public Spikes GhostPrinceSpikes;
    public Spikes[] flowersSpikes;
    public bool spikesdown;
    public GameObject lookAt;
     // Use this for initialization
    void Awake()
    {
        foreach (GameObject box in startPonits)
        {
            box.SetActive(false);
        }
        inplay = false;
        theCLock = FindObjectOfType<clock>();
        memory = FindObjectOfType<PlayerMemory>();
        walking = FindObjectOfType<walk>();
        startPonits[0].SetActive(memory.stage[1].stagecomplated == 0);
        startPonits[1].SetActive(memory.stage[1].stagecomplated > 0);
        spikesdown = memory.stage[1].puzzles[3].puzzleSloved[0];

        for (int i = 0; i < npc.Length; i++)
        {
            if(npc[i] != null)
            {
            npc[i].SetActive(false);
            }
        }
        for (int i = 0; i < Rooms.Length; i++)
        {
            Rooms[i].SetActive(false);

        }
        if (memory.stage[1].stagecomplated == 0 && memory.hacked == true)
        {
            AmuseMe();
            if (theCLock.playTime >= 30)
            {
                memory.stage[1].puzzles[2].puzzleSloved[0] = true;
            }
        }
    }
    
    public void AmuseMe()
    {
        
        if (memory.PlayerName == "Chungus" || memory.PlayerName == "Thrillho"|| memory.PlayerName == "Pall"|| memory.PlayerName == "Papyru")
        {
             memory.stage[1].puzzles[1].puzzleSloved[0] = true;
         }
    
            for(int i = 0; i >theCLock.playTime; ++ i)
            {
         if(role == memory.Partty[0].LuckyNumber)
            {
                memory.stage[1].puzzles[1].puzzleSloved[0] = true;
              }
            }           
     
    }
    void Start ()
    {
        Debug.Log(memory.stage);
        if (memory.stage[1].stagecomplated  <=1)
        {
            if(memory.stage[1].puzzles[1].puzzleSloved[0] == true)
            {
                       sound.soundEfeacts("puzzleSolved");
            }
            if (memory.stage[1].puzzles[0].puzzleSloved[0] == false)
            {
                bolcokedDoor.SetActive(true);
            }

            if (memory.stage[1].puzzles[0].puzzleSloved[0] == true)
            {
                
                bolcokedDoor.SetActive(false);
                npc[4].SetActive(true);

            }
            if (memory.stage[1].stagecomplated == 0)
            {

                if (memory.stage[1].puzzles[1].puzzleSloved[0] == false)
                {
 
                    Rooms[2].SetActive(true);
                }
                if (memory.stage[1].puzzles[1].puzzleSloved[0] == true)
                {
                    Rooms[0].SetActive(true);
                }
            }
            if (memory.stage[1].stagecomplated == 1)
            {
                if (memory.stage[1].puzzles[1].puzzleSloved[0] == true)
                {
                    Rooms[1].SetActive(true);
                }

            }
        }
        if(memory.stage[1].stagecomplated == 2)
        {
            bolcokedDoor.SetActive(false);
            npc[4].SetActive(true);
        }

 
        

    }
    
    // Update is called once per frame
    void Update()
          {
     

            if (memory.stage[1].stagecomplated <= 1)
        {
            #region exit
            if (memory.stage[1].puzzles[0].puzzleSloved[0] == true)
            {
                if(spikesdown == false)
                {
                memory.stage[1].puzzles[3].puzzleSloved[0] = true;
                    foreach(Spikes spikes in flowersSpikes)
                    {
                        spikes.checkSpikes();
                    }
                    spikesdown = true;
                }
                bolcokedDoor.SetActive(false);
                npc[4].SetActive(true);

                if (exit[1].inTheBox == true)
                {
                    if (inplay == false)
                    {
                        Instantiate(blackscreen, new Vector3(0, 0, 0), Quaternion.identity);
                        inplay = true;
                    }
                    memory.loadRoom(NextStage[1],true,true);
                    Debug.Log(NextStage);
                }
                
            }
            #endregion
            #region CantExit
            if (memory.stage[1].puzzles[0].puzzleSloved[0] == false)
            {
                if (exit[0].inTheBox == true)
                {
                    if(reading == false)
                    {
                   exittext.SetActive(true);
                        reading = true;
                    }
                }
                if (exit[0].inTheBox == false)
                {
                         reading = false;                    
                }
            }
            #endregion
            #region vaninla
            if (memory.stage[1].puzzles[1].puzzleSloved[0] == false)
                {
                    if (exit[3].inTheBox == true)
                    {
                        npc[5].SetActive(true);
                        walking.walkDirection = movement.up;
                        walking.walking = false;
                        walking.cutseen = true;
                    if(talkiingText  == 0)
                    {
                        GhostPrinceSpikes.efeact(true);
                        sound.soundEfeacts("spikes");
                    }
                        if (talking[0] == false && text.finshed == true)
                        {
                            talkiingText++;
                            ghost();                        
                        }
                    }
                }
            #endregion
            if (memory.stage[1].puzzles[1].puzzleSloved[0] == true)
            {
                if (memory.stage[1].puzzles[0].puzzleSloved[0] == true)
                {
                    npc[0].SetActive(true);
                    npc[1].SetActive(true);
                }
                if (exit[2].inTheBox == true)
                {
                    npc[3].SetActive(true);
                    walking.walkDirection = movement.up;
                    walking.walking = false;
                    walking.cutseen = true;
                      if(talkiingText  == 0)
                    {
                        lookAt.SetActive(false);
                        GhostPrinceSpikes.efeact(true);
                        foreach(Spikes spike in flowersSpikes)
                        {
                            spike.efeact(true);
                        }
                        sound.soundEfeacts("spikes");
                    }
                    if (talking[0] == false && text.finshed == true)
                    {
                         talkiingText++;
                        talkingto();
                    }
                }

            }

        }


        if (memory.stage[1].stagecomplated == 2)
        {
            if (exit[1].inTheBox == true)
            {
                if (inplay == false)
                {
                    Instantiate(blackscreen, new Vector3(0, 0, 0), Quaternion.identity);
                    inplay = true;
                }
                 memory.loadRoom(NextStage[1], true,true);
                memory.stage[1].stagecomplated = 2;
            }
        }



    }
    public void ghost()
    {
        switch (talkiingText)
        {
            case 1:
                       sound.soundEfeacts("puzzleSolved");
                memory.MonsterFightingID.Add(prince);
                walking.playerstop();
                walking.walkDirection = movement.up;
                walking.cutSeeen();
                text.curentDialogue = 8;
                text.maxDialogue = 9;
                text.newline(true);
                break;

            case 2:         
                memory.loadRoom(NextStage[0],false,false);
                break;

        }
    }

    public void talkingto()
    {
        switch (talkiingText)
        {
            case 1:
                memory.MonsterFightingID.Add(flower);
                walking.playerstop();
                walking.walkDirection = movement.up;
                walking.cutSeeen();
                npc[3].SetActive(true);
                text.curentDialogue = 4;
                text.maxDialogue = 5;
                text.newline(true);
                break;

            case 2:
                   memory.newstage = false;               
                   memory.loadRoom(NextStage[0],false,false);
                break;

        }
    }
   
    


    }
