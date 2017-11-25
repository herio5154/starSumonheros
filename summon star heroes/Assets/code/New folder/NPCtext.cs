using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCtext : MonoBehaviour {
    public sound_effect_manager sound;
    public textImport text;
    public npcFaceing npcFace;
    public npcmovement movement;
     public lookat look;
    public walk plaer;
    public bool sign;
    public bool notes;
    public bool talking;
    public bool finshed;
    public int startingText;
    public int cutrentText;
    public int maxtext;
     public int startingD;
    void Start()
    {
        plaer = FindObjectOfType<walk>();

    }
    void OnEnable()
    {
        cutrentText = startingText;
        talking = true;
         plaer = FindObjectOfType<walk>();
    }
    void Update()
    {

        if (talking == true)
        {
            if (sign == true)
            {
                sigan();
            }
            if (sign == false)
            {
                npc();
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (cutrentText < maxtext)
            {

                talking = true;
                cutrentText += 1;
                sigan();
       sound.soundEfeacts("yes");
            }

            else
            {

                gameObject.SetActive(false);
            }



        }


    }
    void OnDisable()
    {

    }

    public void npc()
    {
        if (notes == false)
        {
            npcFace.faceingpayer();
        }
        text.simpletext = true;
        text.maxDialogue = maxtext;
        text.curentDialogue = cutrentText;
        text.newline(true);
        talking = false;


    }
    public void sigan()
    {
        text.simpletext = true;
        text.maxDialogue = maxtext;
        text.curentDialogue = cutrentText;
        text.newline(false);
    }
}
