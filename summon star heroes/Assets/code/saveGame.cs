using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveGame : MonoBehaviour {
    public textImport Text;  
    public int savetext;
    public int[] maxMin;
    public bool reading;
    public GameObject savePonit;
	// Use this for initialization
	void Start () {
 

    }
    void OnEnable()
    {
        reading = false;
        savetext = 0;
        Text.curentDialogue = maxMin[0];
        Text.maxDialogue = maxMin[1];
     }
    // Update is called once per frame
    void Update () {
		if(reading == false)
        {
            if (Input.GetButtonDown("AButton"))
            {
                StartCoroutine(readingit());
                textbox();
             }
        }
    }
    public void textbox()
    {
        switch (savetext)
        {
            case 0:
                savetext++;
                Text.newline(false);
                break;
            case 1:
                savePonit.SetActive(true);
                gameObject.SetActive(false);
                Debug.Log("hit");
                break;
        }
        

    }
    IEnumerator readingit()
    {
        reading = true;
      yield return new WaitForSeconds(0.5f);
        reading = false;
    }
}
