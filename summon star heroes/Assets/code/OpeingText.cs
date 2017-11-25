using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeingText : MonoBehaviour
{
    public float speed;
    public float sppedX;
    public GameObject start;
    public GameObject skip;
    public sound_effect_manager sound;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, speed, 0);
        speed += sppedX;
        if (Input.GetButtonDown("AButton"))
        {
            skip.SetActive(false);
            start.SetActive(true);
            gameObject.SetActive(false);
       sound.soundEfeacts("yes");


        }
        if(speed >= 45)
        {
            start.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}