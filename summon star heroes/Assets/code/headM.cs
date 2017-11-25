using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class headM : MonoBehaviour {
    public Image head;
    public AudioSource vocesound;
    public Sprite NPCFace;
    public string NpcName;
    public AudioClip Npcvoce;
    public npcinfo info;
    public Text NPCname;
    public int sprite;
    public List <ParrtyVoces> NPC  = new List<ParrtyVoces>();
     public bool looked;
       void OnEnable()
    {
        info = FindObjectOfType<npcinfo>();
 
  Npcvoce = info.voce;
   NpcName = info.npcName;
        head.sprite = info.face;
         NPCname.text = info.npcName;
    }
 
    public void talking()
    {
        
        vocesound.PlayOneShot(Npcvoce, 1.0F);

    }
    public void faceswap()
    {
        NPCFace = NPC[sprite].face;
        Npcvoce = NPC[sprite].voce;
        NpcName = NPC[sprite].Name;
        head.sprite = NPCFace;
        NPCname.text = NpcName;
    }
    public void looking()
    {
        info = FindObjectOfType<npcinfo>();
        looked = true;
    }

}
