using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nameGame : MonoBehaviour {
    public GameObject newgame;
    public PlayerMemory oldgame;
    public string newGameStart;
    public PlayerMemory thenewGame;
    public bool start;
    // Use this for initialization
    void OnEnable()
    {
        oldgame = FindObjectOfType<PlayerMemory>();
        if(oldgame != null)
        {
            Destroy(oldgame.gameObject);
            start = true;
           var game = Instantiate(newgame, new Vector3(0, 0, 0), Quaternion.identity);
          thenewGame =   game.GetComponent<PlayerMemory>();
            thenewGame.PlayerWalking.SetActive(false);
        }
        if (oldgame == null&& start == false)
        {
            var game = Instantiate(newgame, new Vector3(0, 0, 0), Quaternion.identity);
            thenewGame = game.GetComponent<PlayerMemory>();
            thenewGame.PlayerWalking.SetActive(false);

        }

    }

        // Update is called once per frame
        void Update ()
    {
        if(start == false)
        {
 if (Input.GetButtonDown("AButton"))
        {
                start = true;
                thenewGame.loadRoom(newGameStart, true, true);
                Debug.Log("hit");
            }
        }
       
    }



    }

