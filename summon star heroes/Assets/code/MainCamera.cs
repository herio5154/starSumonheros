using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
    public GameObject player;
    private Vector3 traget;
    public float movespeed;
     public bool ingame;
     public walk playerWalk;
    public StartStage newStage;
    public GameObject blackscreen;
    // Use this for initialization
    void Start()
    {
        playerWalk = FindObjectOfType<walk>();
        player = playerWalk.gameObject;
        movespeed = 100;
          traget = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
       transform.position = Vector3.Lerp(transform.position, traget, movespeed * Time.deltaTime);
             var black = Instantiate(blackscreen, new Vector3(0, 0, 0), Quaternion.identity);
         newStage = black.gameObject.GetComponent<StartStage>();
        newStage.playerWalk = playerWalk;
        newStage.start = true;
  
    }
    // Update is called once per frame
    void Update()
    {
 
        if (ingame == false)
        {
            if (gameObject.transform.position.x == player.transform.position.x && gameObject.transform.position.y == player.transform.position.y)
            {
                movespeed = 5;
                newStage.starGame();
                ingame = true;
            }
        }
        
        traget = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, traget, movespeed * Time.deltaTime);
       
    }
}
