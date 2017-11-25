using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLoaction : MonoBehaviour {
    public PlayerMemory location;
    
	// Use this for initialization
	void Start () {
        location = FindObjectOfType<PlayerMemory>();
        gameObject.transform.position = new Vector3(location.lastLocationX, location.lastLocationX, 0);
              
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
