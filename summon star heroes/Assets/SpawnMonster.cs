using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("test");

        }
     }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {

        }
         
    }
}
