using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcFaceing : MonoBehaviour {
    public npcmovement movement;
    public bool wachingPlayer;
     public movement LookNumber;
    public GameObject bigbox;
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(wachingPlayer == true)
        {
            faceingpayer();
        }
 

    }
    public void faceingpayer()
    {
         movement.walkDirection = LookNumber;
        movement.looking();
    }
    void OnDisable()
    {
         wachingPlayer = false;
    }


}
