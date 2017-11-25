using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class simpleUiStats : MonoBehaviour {
    public float[] HP;
    public string Name;
    public bool dead;
    public Text thetext;
    public int ID;
    public PlayerMemory stats;
    // Use this for initialization

    void OnEnable()
    {
        stats = FindObjectOfType<PlayerMemory>();
        if (dead == false)
        {
            if (ID > stats.Partty.Count-1)
            {
                Destroy(gameObject);
            }
            if (ID < stats.Partty.Count-1)
            {
                thetext.text = stats.Partty[ID].Name + "\n" + stats.Partty[ID].currentHealth + "/" + stats.Partty[ID].MaxHealth; ;

            }
        }
        if(dead == true)
        {
            gameObject.SetActive(false);
        }
 
    }


    // Update is called once per frame
    void Update () {
		if(dead == true)
        {
            gameObject.SetActive(false);
        }
        if(dead == false)
        {
            if(stats.Partty[ID].currentHealth <= 0)
            {
                dead = true;
            }
            else
            {
                HP[0] = stats.Partty[ID].currentHealth;
                thetext.text = stats.Partty[ID].Name + "\n"+stats.Partty[ID].currentHealth+"/"+ stats.Partty[ID].MaxHealth; ;
            }
        }
	}
}
