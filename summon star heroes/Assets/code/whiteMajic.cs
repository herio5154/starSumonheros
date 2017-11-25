using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteMajic : MonoBehaviour {
     public string Information;
    public int ID;
    public turnWacher turn;
    public List<StatsBoost> statstoChnage = new List<StatsBoost>();
   
    void OnEnable()
    {
        turn = FindObjectOfType<turnWacher>();
   
        Destroy(gameObject);
    }
    

}
