using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class lookat : MonoBehaviour
{
    public GameObject thingtolookAt;
    public walk walking;
    public bool inbox;
    public bool reading;
    public movement lookD;
    public pause stop;
      // Use this for initialization
    void Start()
    {
        walking = FindObjectOfType<walk>();
 
    }

    // Update is called once per frame
    void Update()
    {

        if(walking == null)
        {
            walking = FindObjectOfType<walk>();

        }
        if (inbox == true && stop.menuOn == false)
        {
             if(reading == false)
                {
                if (Input.GetButtonDown("AButton"))
                {
                    thingtolookAt.SetActive(true);
                    reading = true;
                     walking.playerpause();
                    StartCoroutine(readingthis());
                }
            }
         }
 
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag.Equals("Player"))
        {
             inbox = true;
        }


    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            inbox = false;
            reading = false;
        }


    }
  
    IEnumerator readingthis()
    {
         yield return new WaitForSeconds(5);
        reading = false;
    }

}
    