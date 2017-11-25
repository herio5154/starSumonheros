using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleSound : MonoBehaviour {
    public AudioSource music;
    public AudioClip normalBattle;
    public monsterSheat monster;

    // Use this for initialization
    void Start()

    {
        monster = FindObjectOfType<monsterSheat>();
        if (monster.kindofBattle == battleKInds.boss)
        {
              music.clip = monster.soundtrack;

        }
        else
        {
             music.clip = normalBattle;

        }
        music.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void winer()
    {
        music.Stop();
 
    }
}
