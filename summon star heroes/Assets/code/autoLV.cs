using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoLV : MonoBehaviour {
    public EXPM stats;
    public int max;
    private int couter;
	void Start () {
        stats.AutoLevel(max);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
