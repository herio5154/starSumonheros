using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavelockedBox : MonoBehaviour {
    public PlayerMemory memory;
    public int stage;
    public int puzzleID;
     public Sprite[] chests;
    public SpriteRenderer chestR;
    public GameObject [] lockeBox;
  
    // Use this for initialization
    void Start () {
        foreach (GameObject box in lockeBox)
        {
            box.SetActive(false);
        }
        memory = FindObjectOfType<PlayerMemory>();
        if(memory.stage[stage].puzzles[puzzleID].puzzleSloved[1] == false)
        {
            chestR.sprite = chests[0];
            if (memory.stage[stage].puzzles[puzzleID].puzzleSloved[0] == false)
            {
                lockeBox[0].SetActive(true);
            }
            if (memory.stage[stage].puzzles[puzzleID].puzzleSloved[0] == true)
            {
                lockeBox[1].SetActive(true);
            }
        }
        if (memory.stage[stage].puzzles[puzzleID].puzzleSloved[1] == true)
        {
            chestR.sprite = chests[1];
            lockeBox[2].SetActive(true);
        }

    }
	
	// Update is called once per frame
 
}
