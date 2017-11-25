using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveGIver : MonoBehaviour {

    public moveCalog themoves;
    public unitStats moves;
    public int[] MoveID;
    public bool player;
	// Use this for initialization
	void Start () {
 
for(int i = 0; i< MoveID.Length; i++)
        {
            
            moves.Moves.Add(themoves.MoveCalog[MoveID[i]]);
        }
	}

}
