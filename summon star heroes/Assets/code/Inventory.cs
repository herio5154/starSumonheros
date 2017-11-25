using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public enum vaule {NA,EXP,gold,MP,HP }
public class Inventory : MonoBehaviour {

    public int Gold;
    public List<Items> items = new List<Items>();    
    public List<slots> PlayerActSlots = new List<slots>();


}
