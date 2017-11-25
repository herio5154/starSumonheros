using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newgame : MonoBehaviour {
    public PlayerMemory memory;
    public GameObject player;
    public string newGame;
    // Use this for initialization
    void Start () {
        memory = FindObjectOfType<PlayerMemory>();
        player = memory.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("AButton"))
        {
            SceneManager.LoadScene(newGame);

        }
    }
}
