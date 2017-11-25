using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnSetup : MonoBehaviour


{
    public GameObject [] menunav;
    void OnEnable()
    {
        for(int i = 0; i<menunav.Length; i++)
        {
            menunav[i].SetActive(i == 0);
        }
    }



}
