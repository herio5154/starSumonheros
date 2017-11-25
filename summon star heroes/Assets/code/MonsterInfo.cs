using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterInfo : MonoBehaviour {
    public monsterSheat monsters;
    public Text  Info;
    public string infoString;
    public bool reading;
    private float time = 0.5f;
    public GameObject combat;
  
    void OnEnable()
    {
        infoString = "";
        if(monsters == null)
        {
        monsters = FindObjectOfType<monsterSheat>();
        }
        StartCoroutine(read());
        foreach (unitStats item in monsters.UnitStats)
        {
            if(item.currentHealth >0)
            {
                infoString += " Name: " + item.Name;
                if (item.Level == 0)
                {
                    infoString += "???" + "\n";
                }
                else
                {
                    infoString += " Level:" + item.Level + "\n";
                }
                infoString += " HP:" + item.currentHealth + "/" + item.MaxHealth + "\n" + "weakness:" + item.Weekness + "\n" + item.MonsterStuff[0].info + "\n";
            }
           
       }
        Info.text = infoString;


    }

    // Update is called once per frame
    void Update () {
		if(reading == false)
        {
            if (Input.GetButtonDown("AButton"))
            {
                combat.SetActive(true);
                gameObject.SetActive(false);
            }

        }
    }
    IEnumerator read()
    {
        reading = true;
       yield return new WaitForSeconds(time);
        reading = false;
    }
}
