using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choseAbook : MonoBehaviour {
    public List<Items> books = new List<Items>();
    public PlayerMemory memory;
    public walk walking;
    public bool reading;
    public int booksMenu;
    public Sprite chests;
    public SpriteRenderer chestR;
    public GameObject unlockedBox;
    public GameObject choise;
    public GameObject[] starts;
    public int CHoiseID;
    public sound_effect_manager sound;

     public List<Items> iteamToGive = new List<Items>();
    public Inventory stuff;
    // Use this for initialization
    void OnEnable()
    {
       
        stuff = FindObjectOfType<Inventory>();
        walking = FindObjectOfType<walk>();
        walking.playerpause();
        CHoiseID = 0;
        starts[0].SetActive(true);
        starts[1].SetActive(false);
        unlockedBox.SetActive(false);
        chestR.sprite = chests;
        memory = FindObjectOfType<PlayerMemory>();
         memory.stage[1].puzzles[2].puzzleSloved[1] = true; 
        reading = true;
        StartCoroutine(readingthis());
    }
	
	// Update is called once per frame
	/// <summary>
    /// 
    /// </summary>
    void Update () {
		if(reading == false)
        {
           if (Input.GetButtonDown("UpArrow"))
            {
                sound.soundEfeacts("select");
                CHoiseID = 0;
                starts[0].SetActive(true);
                starts[1].SetActive(false);
            }
            if (Input.GetButtonDown("DownArrow"))
            {
                sound.soundEfeacts("select");
                CHoiseID = 1;
                starts[0].SetActive(false);
                starts[1].SetActive(true);
            }
            if (Input.GetButtonDown("AButton"))
            {
                sound.soundEfeacts("yes");
                if (CHoiseID == 0)
                {
                    stuff.items.Add(iteamToGive[0]);
                    stuff.items.Add(iteamToGive[1]);

                }
                if (CHoiseID == 1)
                {
                    stuff.items.Add(iteamToGive[2]);
                    stuff.items.Add(iteamToGive[3]);
                }
                walking.playergo();
                gameObject.SetActive(false);
            }

        }
    }
    
    IEnumerator readingthis()
    {
        yield return new WaitForSeconds(0.5f);
        reading = false;
    }
}
