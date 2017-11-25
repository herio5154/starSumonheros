using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatsScreen : MonoBehaviour {
    public pauseMenu pause; 
    public PlayerMemory stats;
     public sound_effect_manager sound;
    public bool read;
     public int partty;
    public float time;
    [Header("stat info")]
     public int InfoSLot;
    public Text[] information;
    public Image face;

    // Use this for initialization
    void OnEnable()
    {

        stats = FindObjectOfType<PlayerMemory>();
        InfoSLot = 0;
        plauyers();
     }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("BButton"))
        {
            pause.readingit();
            gameObject.SetActive(false);
        }
        if (read == false)
        {
            if (Input.GetButtonDown("RightArrow"))
            {
                sound.soundEfeacts("select");
                time = 0;
                read = true;
                InfoSLot = (InfoSLot + 1) % stats.Partty.Count;
                plauyers();

            }
            if (Input.GetButtonDown("LeftArrow"))
                {
                sound.soundEfeacts("select");
                time = 0;
                read = true;
                if (InfoSLot > 0)
                {
                    InfoSLot -= 1;
                }
                plauyers();

            }
        }
        if(read == true)
        {
            time += 0.1f;
            if(time >= 1)
            {
                read = false;
            }
        }

    }

    public void plauyers()
    {
        string weapons = "weapons : " + "\n";
        string helmet = "Helmet : " + "\n";
        string Armour = "Armour : " + "\n";
        string Acc = "Accessories : " + "\n";
        string letters;
        face.sprite = stats.Partty[InfoSLot].face;
        information[0].text = stats.Partty[InfoSLot].Name + "  LV: " + stats.Partty[InfoSLot].Level + "\n" + "HP: " + stats.Partty[InfoSLot].currentHealth + " / " + stats.Partty[InfoSLot].MaxHealth + "\n" + "MP: " + stats.Partty[InfoSLot].currentMana + "/" + stats.Partty[InfoSLot].MaxMana + "\n" + "Exp : " + stats.Partty[InfoSLot].Exp.CurentExp + " / " + stats.Partty[InfoSLot].Exp.ExpNeeded;
        letters = "Atack : " + stats.Partty[InfoSLot].Attack+"\n"+"Majic :" + stats.Partty[InfoSLot].Majic+ "\n" + "speed : " + stats.Partty[InfoSLot].Speed + "\n" + "Defence : " + stats.Partty[InfoSLot].Defence + "\n" + "luck : " + stats.Partty[InfoSLot].Luck + "\n";


        if (stats.Partty[InfoSLot].stretnth == majic.NA)
        {
            letters += "Elemetnt : normal";
        }
        else
        {
            letters += "Elemetnt " + stats.Partty[InfoSLot].stretnth;
        }
        information[1].text = letters;

        foreach(Items stuff in stats.Partty[InfoSLot].equipment)
        {
            if(stuff.EquipKind == equipped.weapon)
            {
                weapons += stuff.ItemName;
            }
            if (stuff.EquipKind == equipped.Helmet)
            {
                helmet += stuff.ItemName;
            }
            if (stuff.EquipKind == equipped.chest)
            {
                Armour += stuff.ItemName;
            }
            if (stuff.EquipKind == equipped.Accessories)
            {
                Acc += stuff.ItemName;
            }
        }
      
        information[2].text = weapons + "\n" + helmet + "\n" + Armour + "\n" + Acc;

    }

}

