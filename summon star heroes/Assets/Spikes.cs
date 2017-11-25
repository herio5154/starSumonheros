using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
     public int stage;
    public int puzleID;
    public int puzzleNumber;
    public GameObject[] spikes;
    public PlayerMemory memory;
    
    // Use this for initialization
    void Start()
    {
        memory = FindObjectOfType<PlayerMemory>();
        checkSpikes();

    }
    public void checkSpikes()
    {
        spikes[0].SetActive(memory.stage[stage].puzzles[puzleID].puzzleSloved[puzzleNumber] == true);
        spikes[1].SetActive(memory.stage[stage].puzzles[puzleID].puzzleSloved[puzzleNumber] == false);
 
    }
    public void efeact(bool up)
    {
        spikes[0].SetActive(up = false);
        spikes[1].SetActive(up = true);
 
    }

}
	 
