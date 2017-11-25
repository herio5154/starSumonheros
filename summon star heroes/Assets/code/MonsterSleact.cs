using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterSleact : MonoBehaviour
{
     public sound_effect_manager sound;
     public GameObject[] sleact;
    public Text[] menu;
    public Text[] helth;
    public stasM stats;
    public turnWacher Target;
    public int TargetSleact;
    public GameObject[] next;
   public int nameCouter;
    void OnEnable()
    {
         TargetSleact = 0;
        nameCouter = 0;
        for (int i = 0; i < sleact.Length; i++)
        {
             sleact[i].SetActive(i == 0);
            menu[i].text = "";
            helth[i].text = "";

            if (i < Target.turnInfo.Count)
            {
 if(Target.turnInfo[i].AtackInformation[3] == false)
                {
                    if (Target.turnInfo[0].TargetKind == targetKind.Enemy)
                    {
                        if (Target.turnInfo[i].monster == true)
                        {

                            menu[nameCouter].text = Target.turnInfo[i].Stats.Name;
                            helth[nameCouter].text = "HP:" + Target.turnInfo[i].Stats.currentHealth;


                        }

                    }
                    if (Target.turnInfo[0].TargetKind == targetKind.Player)
                    {
                        if (Target.turnInfo[i].monster == false)
                        {
                            menu[nameCouter].text = Target.turnInfo[i].Stats.Name;
                            nameCouter++;
                        }
                    }
                }
             
            } 
         }
    
     }
    // Use this for initialization
    void Update()
    {
        #region menu

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (TargetSleact < nameCouter - 1)
            {
                sleact[TargetSleact].SetActive(false);
                TargetSleact += 1;
                sleact[TargetSleact].SetActive(true);
            }
            else
            {
                TargetSleact = nameCouter - 1;
            }
       sound.soundEfeacts("select");
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (TargetSleact > 0)
            {
                sleact[TargetSleact].SetActive(false);
                TargetSleact -= 1;
                sleact[TargetSleact].SetActive(true);
            }
            if (TargetSleact == 0)
            {
                TargetSleact = 0;
            }
       sound.soundEfeacts("select");
        }
        #endregion
        if (Input.GetKeyDown(KeyCode.X))
        {
            next[0].SetActive(true);
            gameObject.SetActive(false);
            Debug.Log("hay");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {

            Target.turnInfo[TargetSleact].MoveInformation[0] = menu[TargetSleact].text;
             Target.next();
             }
        }
     
}
 
