using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textmanager : MonoBehaviour {
    public bool DilogActive;
    public bool IsTypeing;
    public bool CanelTypeing;
    public bool basictext;
    public float speed;
    public GameObject Dbox;
    public Text Dext;
    public PlayerMemory playerName;
    public sound_effect_manager sound;
    public string[] Dialogue;
    public int curentline;
    public int maxline;
    public GameObject head;
    public float basicTextCounter = 5f;
    // Use this for initialization
    void Start () {
             playerName = FindObjectOfType<PlayerMemory>();
        }
    

	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("AButton"))
        {

            {

                if (IsTypeing == false)
                {

                    if (curentline >= maxline)
                    {
                        DilogActive = false;
                    }
                    else
                    {
                        curentline += 1;
 
                        if (basictext == false)
                        {
                            StartCoroutine(textscroll(Dialogue[curentline]));
                        }
                    }
                }
            }
            if (DilogActive == false)
            {
                if (basictext == true)
                {
                           sound.soundEfeacts("yes");
                }
                basictext = false;
                Dbox.SetActive(false);
                StopAllCoroutines();
            }

        }
        if (Input.GetButtonDown("YButton"))
        {
            if (IsTypeing == true)
            {
                CanelTypeing = true;
                       sound.soundEfeacts("yes");
            }
        }
    }
    public void showtext()
    {
         basictext = false;
        DilogActive = true;
        Dbox.SetActive(true);
        StartCoroutine(textscroll(Dialogue[curentline]));
        head.SetActive(true);
    }
    // basic text
    public void basicTextBox()
    {

         basictext = true;
        DilogActive = true;
        Dbox.SetActive(true);
        Dext.text = Dialogue[curentline];
        head.SetActive(false);

    }
    public void newLine()
    {
        curentline += 1;
         StartCoroutine(textscroll(Dialogue[curentline]));
    }
    IEnumerator textscroll(string Dialogue)
    {
        int letter = 0;
        Dext.text = "";
        IsTypeing = true;
        CanelTypeing = playerName.plainText;

        while (IsTypeing == true && CanelTypeing == false && letter < Dialogue.Length - 1)
        {
            Dext.text += Dialogue[letter];
            letter += 1;
            head.GetComponent<headM>().talking();
            yield return new WaitForSeconds(speed);
        }
        
        Dext.text = Dialogue;
        IsTypeing = false;
        CanelTypeing = false;
    }
   
   
}

