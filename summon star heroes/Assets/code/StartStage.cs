using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStage : MonoBehaviour {
    public Animator stage;
    public bool start;
    public PlayerMemory theMemory;
    public walk playerWalk;

   
    public void stageOver()
    {
      
           playerWalk.playergo();
        Destroy(gameObject);
  
  

    }
    public void starGame()
    {
        playerWalk.playerpause();
        stage.SetBool("fadeIN", true);
    }
    void OnEnable()
    {

        if (start == false)
        {
            stage.SetBool("fadeout", true);
        }

    }
   



}
