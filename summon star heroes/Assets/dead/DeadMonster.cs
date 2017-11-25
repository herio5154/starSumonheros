using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMonster : MonoBehaviour {
    public ParticleSystem sprites;
    public GameObject monster;
    
    void Start()
    {
        monster.SetActive(false);
    }
    void Update()
    {
 
        if(sprites.time >= sprites.main.duration)
        {
             Destroy(gameObject);            
        }
    }
}
