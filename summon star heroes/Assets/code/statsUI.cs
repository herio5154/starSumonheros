using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class statsUI : MonoBehaviour
{
    public turnWacher turn;
    public Slider HPslider;
    public Slider MPslider;
      public Text PlayerName;
     public Image FaceRenfer;
    public Text [] numbers;
 
 
    public void setpartty(int ID)
    {
        FaceRenfer.sprite = turn.turnInfo[ID].Stats.face;
        PlayerName.text = turn.turnInfo[ID].Stats.Name;
        HPslider.value = turn.turnInfo[ID].Stats.currentHealth;
        HPslider.maxValue = turn.turnInfo[ID].Stats.MaxHealth;
        MPslider.value = turn.turnInfo[ID].Stats.currentMana;
        MPslider.maxValue = turn.turnInfo[ID].Stats.MaxMana;
        numbers[0].text = "HP" + turn.turnInfo[ID].Stats.currentHealth + " / " + turn.turnInfo[ID].Stats.MaxHealth;
        numbers[1].text = "MP" + turn.turnInfo[ID].Stats.currentMana + " / " + turn.turnInfo[ID].Stats.MaxMana;
    }
 
     
}
