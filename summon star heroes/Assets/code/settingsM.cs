using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class settingsM : MonoBehaviour
{
    public pauseMenu pause;
    public PlayerMemory memory;
    public GameObject[] Stars;
    public sound_effect_manager sound;
     public AudioMixer masterMix;
    public float[] soundSetUp;
    public Slider[] soundSlider;
    public GameObject[] menustars;
     public int menuPick;
    public bool inuse;
    public bool reading;
    public float time;
    // Use this for initialization


    // Use this for initialization

    void OnEnable()
    {
        memory = FindObjectOfType<PlayerMemory>();
        reading = false;
        Stars[0].SetActive(memory.epilepsyMode == false);
        Stars[1].SetActive(memory.epilepsyMode == true);
        Stars[2].SetActive(memory.hacked == true);
        Stars[3].SetActive(memory.hacked == false);
        Stars[4].SetActive(memory.plainText == true);
        Stars[5].SetActive(memory.plainText == false);
        menuPick = 0;
        masterMix.SetFloat("Master", soundSetUp[0]);
        masterMix.SetFloat("soundtrack", soundSetUp[1]);
        masterMix.SetFloat("soundEfeacts", soundSetUp[2]);
        masterMix.SetFloat("voce", soundSetUp[3]);
        for (int i = 0; i < soundSetUp.Length; i++)
        {
            soundSlider[i].value = soundSetUp[i];
        }

        for (int i = 0; i < menustars.Length; i++)
        {
            menustars[i].SetActive(i == 0);
        }


    }




    // Update is called once per frame
    void Update()
    {
        #region not In use
        if (inuse == false)
        {
       if(reading == false)
            {
      if (Input.GetButtonDown("BButton"))
        {
            pause.readingit();
            gameObject.SetActive(false);
        }
            }
  
            if (Input.GetButtonDown("AButton"))
            {
                      sound.soundEfeacts("yes");
                inuse = true;
            }
            if (Input.GetButtonDown("UpArrow"))
            {
                menustars[menuPick].SetActive(false);
       sound.soundEfeacts("select");
                if (menuPick > 0)
                {
                    menuPick -= 1;

                }
                menustars[menuPick].SetActive(true);

            }
            if (Input.GetButtonDown("DownArrow"))
            {
       sound.soundEfeacts("select");

                menustars[menuPick].SetActive(false);
                menuPick = (menuPick + 1) % menustars.Length;
                menustars[menuPick].SetActive(true);


            }
          
        }
        #endregion
        if(reading == true)
        {
            time += 0.1f;
            if(time >= 1)
            {
                reading = false;
                Debug.Log("hay");
            }
        }
        #region in use
        if(inuse == true)
        {
            if (Input.GetButtonDown("BButton"))
            {
                       sound.soundEfeacts("no");
                reading = true;
                time = 0;
                inuse = false;
            }
            switch (menuPick)
            {
                case 0:
                    if (Input.GetButtonDown("AButton"))
                    {
                              sound.soundEfeacts("yes");
                        memory.epilepsyMode = !memory.epilepsyMode;
                        Stars[0].SetActive(memory.epilepsyMode == false);
                        Stars[1].SetActive(memory.epilepsyMode == true);
                    }
                    break;
                case 1:
                    if (Input.GetButtonDown("AButton"))
                    {
                              sound.soundEfeacts("yes");
                         if(memory.cantSave == false)
                        {
                        memory.hacked = !memory.hacked;
                        Stars[2].SetActive(memory.hacked == true);
                        Stars[3].SetActive(memory.hacked == false);
                        }
          
                    }
                    break;
                case 2:
                    if (Input.GetButtonDown("AButton"))
                    {
                              sound.soundEfeacts("yes");
                        memory.plainText = !memory.plainText;
                        Stars[4].SetActive(memory.plainText == true);
                        Stars[5].SetActive(memory.plainText == false);
                    }
                    break;
                case 3:
                    soundSlider[0].value = soundSetUp[0];

                    if (Input.GetButtonDown("LeftArrow"))
                    {
                        masterMix.SetFloat("Master", soundSetUp[0]);
                        if (soundSetUp[0] > -80)
                        {
                            soundSetUp[0] -= 1;
                        }
                    }
                    if (Input.GetButtonDown("RightArrow"))
                    {
                        masterMix.SetFloat("Master", soundSetUp[0]);
                        if (soundSetUp[0] < 0)
                        {
                            soundSetUp[0] += 1;
                        }
                    }
                    break;
                case 4:
                    soundSlider[1].value = soundSetUp[1];

                    if (Input.GetButtonDown("LeftArrow"))
                    {
                        masterMix.SetFloat("soundtrack", soundSetUp[1]);
                        if (soundSetUp[1] > -80)
                        {
                            soundSetUp[1] -= 1;
                        }
                    }
                    if (Input.GetButtonDown("RightArrow"))
                    {
                        masterMix.SetFloat("soundtrack", soundSetUp[1]);
                        if (soundSetUp[1] < 0)
                        {
                            soundSetUp[1] += 1;
                        }
                    }
                    break;
                case 5:
                    soundSlider[2].value = soundSetUp[2];

                    if (Input.GetButtonDown("LeftArrow"))
                    {
                        masterMix.SetFloat("soundEfeacts", soundSetUp[1]);
                        if (soundSetUp[2] > -80)
                        {
                            soundSetUp[2] -= 1;
                        }
                    }
                    if (Input.GetButtonDown("RightArrow"))
                    {
                        masterMix.SetFloat("soundEfeacts", soundSetUp[2]);
                        if (soundSetUp[2] < 0)
                        {
                            soundSetUp[2] += 1;
                        }
                    }
                    break;
                case 6:
                    soundSlider[3].value = soundSetUp[3];

                    if (Input.GetButtonDown("LeftArrow"))
                    {
                        masterMix.SetFloat("voce", soundSetUp[3]);
                        if (soundSetUp[3] > -80)
                        {
                            soundSetUp[3] -= 1;
                        }
                    }
                    if (Input.GetButtonDown("RightArrow"))
                    {
                        masterMix.SetFloat("voce", soundSetUp[3]);
                        if (soundSetUp[3] < 0)
                        {
                            soundSetUp[3] += 1;
                        }
                    }
                        break;
                     
             }

        }
        #endregion
    }


}
       

