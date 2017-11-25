using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clock : MonoBehaviour {

    public int playTime = 0;
    public int seconds = 0;
    public int minuits = 0;
    public int hours = 0;
   
 	// Use this for initialization
	void Start () {
     
        StartCoroutine(playtime());
 	}

    private IEnumerator playtime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            playTime++;
            seconds = (playTime % 60);
            minuits = (playTime / 60)%60;
            hours = (playTime/ (60*24)) % 24;
        }
    }
	
}
