using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textImport : MonoBehaviour {
    public TextAsset thetext;
    public Textmanager Dan;
    private walk walking;
    public string[] ImportDialogue;
    public int curentDialogue;
    public int maxDialogue;
    public bool finshed;
    public float speed;
    public int sprite;
    public bool simpletext;
    public bool callout;
    public bool NotAcutseen;
    public PlayerMemory memory;
    // Use this for initialization
    void Start()
    {
        memory = FindObjectOfType<PlayerMemory>();
        ImportDialogue = (thetext.text.Split('\n'));
        walking = FindObjectOfType<walk>();

    for(int i =0; i< ImportDialogue.Length; i++)
        {
            if (ImportDialogue[i].Contains("PLAYER"))
            {
              ImportDialogue[i] = ImportDialogue[i].Replace("PLAYER",memory.Partty[0].Name);
            }

        }
 
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Dan.DilogActive == false)
        {
            finshed = true;
        }

        if (simpletext == true)
        {
            if (finshed == false)
            {

                walking.playerpause();

            }
            if (finshed == true)
            {
                walking.playergo();
                simpletext = false;
            }

        }

    }
    public void newline(bool talkingHead)
    {

        finshed = false;
        Dan.Dialogue = ImportDialogue;
        Dan.curentline = curentDialogue;
        Dan.maxline = maxDialogue;
        if (talkingHead == true)
        {
            Dan.speed = speed;
            Dan.showtext();
        }
        if (talkingHead == false)
        {
            Dan.basicTextBox();
        }
    }





}
