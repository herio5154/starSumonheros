using UnityEngine;
using System.Collections;

public class StartingPoints : MonoBehaviour {
    public GameObject spawnPoint;
    public bool player;
    public PlayerMemory memory;
    public walk playerWalk;
    //  private MainCamera theCamara;
    // Use this for initialization
    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {
        findPLayer();
        //thePlayer = FindObjectOfType<walk>();
        // thePlayer.transform.position = transform.position;

              //theCamara = FindObjectOfType<MainCamera>();
        ///  theCamara.transform.position = new Vector3(transform.position.x,transform.position.y, theCamara.transform.position.z) ;

    }
    public void findPLayer()
    {
        memory = FindObjectOfType<PlayerMemory>();
        playerWalk = FindObjectOfType<walk>();
        if (player == true)
        {
            spawnPoint = playerWalk.gameObject;
            if (memory.newstage == false)
            {
                transform.position = new Vector3(memory.lastLocationX, memory.lastLocationY, 0);

            }
            if (memory.newstage == true)
            {
                spawnPoint.transform.position = transform.position;
            }
        }
        else
        {
            spawnPoint.GetComponent<npcmovement>();
            spawnPoint.transform.position = transform.position;


        }

    }

    void OnEnable()
    {
        findPLayer();
    }
}
