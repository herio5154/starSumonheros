using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class treasureChest : MonoBehaviour {
    public Sprite[] chests;
    public int stage;
    public SpriteRenderer chestR;
    public PlayerMemory Memory;
    public Inventory playerInvantory;
    public sound_effect_manager sound;
    public walk player;
    public movement lookD;
    public int boxNumber;
    public int puzzleNUmber;
    public hitBox colider;
    public GameObject textBox;
    public GameObject  OpenText;
    public Text theText;   
    public int boxCode;
    public bool reading;
    public bool IsOpen;
    public List<Items> iteamToGive = new List<Items>();
    public bool foundGold;
    public int gold;
    public pause stop;
    public string words;
    // Use this for initialization
    void Start()
    {
        Memory = FindObjectOfType<PlayerMemory>();

        if (Memory.stage[stage].puzzles[boxNumber].puzzleSloved[puzzleNUmber] == true)
        {
            colider.gameObject.SetActive(false);
            chestR.sprite = chests[1];
            IsOpen = true;
            OpenText.SetActive(true);
        }
        else if (Memory.stage[stage].puzzles[boxNumber].puzzleSloved[puzzleNUmber] == false)

        {
            playerInvantory = FindObjectOfType<Inventory>();
            words = Memory.Partty[0].Name + " found " + "\n";

            chestR.sprite = chests[0];
            player = FindObjectOfType<walk>();


        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stop.menuOn == false)
        {

            if (IsOpen == false)
            {
                if (colider.inTheBox == true)
                {
                    if (Input.GetButtonDown("AButton"))
                    {
                        if (reading == false)
                        {
                            openbox();
                            StartCoroutine(Example());
                        }
                    }
                }
            }
        }
    }
    public void openbox()
    {

        switch (boxCode)
        {
            case 0:
                player.playerpause();
                if (foundGold == false)
                {
                    foreach (Items item in iteamToGive)
                    {
                        if (item.Amount > 0)
                        {
                            words += item.ItemName + " X " + item.Amount + "\n";
                        }
                        else
                        {
                            words += item.ItemName + "\n";
                        }
                        playerInvantory.items.Add(item);
                    }
                }
                if (foundGold == true)
                {
                    words += "" + gold + " Gold";
                    playerInvantory.Gold += gold;
                }
                chestR.sprite = chests[0];
                player = FindObjectOfType<walk>();
                theText.text = words;
                chestR.sprite = chests[1];
                textBox.SetActive(true);
                boxCode++;
                break;
            case 1:
                textBox.SetActive(false);
                OpenText.SetActive(true);
                Memory.stage[stage].puzzles[boxNumber].puzzleSloved[puzzleNUmber] = true;
                player.playergo();

                break;
        }
    }
    public void next()
    {
        reading = false;
        boxCode += 1;
    }
    IEnumerator Example()
    {
        reading = false;
        sound.soundEfeacts("yes");
        yield return new WaitForSeconds(1);
        reading = false;

    }

}
