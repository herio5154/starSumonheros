using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slot : MonoBehaviour {
    public Image theCard;
    public ActTurn Turn;
    public stasM Stats;
    public int Number;
    public slotM turn;
    public targetKind Card;
    public vaule cardVaule;
    public int baseValue;
    public float RoleSpeed;
    public static float MaxSPeed;
    public static float windUp;
    public static bool start;
    // Update is called once per frame
    void OnEnable()
    {
 
        StartCoroutine(spinit());
    }

    void Update () {
    
        Card = Stats.numbers[Number].Cardkind;
        baseValue = Stats.numbers[Number].CardBaseVaule;
        cardVaule = Stats.numbers[Number].theCardVaule;
        theCard.sprite = Stats.numbers[Number].TheSprite;

        if (RoleSpeed <MaxSPeed)
        {
            RoleSpeed += windUp * Time.deltaTime;
        }       
        
    }
    public void setSPeed(float speed, float time)
    {
        MaxSPeed = speed;
        windUp = time;
      }
 
    IEnumerator spinit()
    {
        {
            while (turn.diceRoleOver == false)
            {
                Number = Random.Range(0, Stats.numbers.Count - 1);
              
                yield return new WaitForSeconds(RoleSpeed);
            }
        }
    }

}
