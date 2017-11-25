using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum equipped { NA, weapon, Helmet, chest, Accessories };
public enum skillBost { Health, Mana, majic, Attack, Defence, Speed, Luck }
public enum lineWin { colem,row,diggeal}
public enum StatsKind { Attack,Defence,Speed,Majic}
public enum weponKind { knife,Sword,Staff,NA }
public class PlayerMemory : MonoBehaviour {
    public bool epilepsyMode;
    public bool hacked;
    public bool plainText;
    public bool cantSave;
    public string PlayerName;
    public float lastLocationX;
    public float lastLocationY;
     public int DeathCOunt;
    public GameObject blackscreen;
    public List<rooms> stage = new List<rooms>();
    public walk lastLocation;
     public clock theCLock;
    public List<GameObject> MonsterFightingID = new List<GameObject>();
     public List<unitStats> Partty = new List<unitStats>();
    public List<CardMutapler> cards = new List<CardMutapler>();
    static bool inplay;
    public bool newstage;
    public GameObject PlayerWalking;
    public GameObject partty;
    public Inventory Items;
    static bool inGame;

     // Use this for initialization
    void Awake()
    {
         DontDestroyOnLoad(transform.gameObject);
        if (inGame == true)
        {
            Destroy(gameObject);
        }
        if (inGame == false)
        {
            inGame = true;
        }
 
    }


    // Update is called once per frame

    public void loadRoom(string stageChange, bool newroom,bool playerviable)
    {
        if(newroom ==false)
        {
        lastLocationX = lastLocation.LocationX;
        lastLocationY = lastLocation.LocationY;
         }
        newstage = newroom;
        SceneManager.LoadScene(stageChange);
      var back =  Instantiate(blackscreen, new Vector3(0, 0, 0), Quaternion.identity);
        back.gameObject.GetComponent<StartStage>().start = false;
        PlayerWalking.SetActive(playerviable);



    }

    public void save()
    {
        SaveLoadManager.SavePlayer(this);
    }
    public void load()
    {
        SaveLoadManager.loadPlayer(this);
    }



}
