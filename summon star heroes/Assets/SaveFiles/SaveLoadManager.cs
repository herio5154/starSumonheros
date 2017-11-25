using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class SaveLoadManager
{
    
    public static void SavePlayer(PlayerMemory player)
    {
        BinaryFormatter Bf = new BinaryFormatter();
        FileStream Stream = new FileStream(Application.persistentDataPath+"/timelines.sav",FileMode.Create);
        PlayerData data = new PlayerData(player);
        Bf.Serialize(Stream, data);
        Stream.Close();
        Debug.Log("save");
     }
    public static void  loadPlayer(PlayerMemory playerMemory)
    {
         if (File.Exists(Application.persistentDataPath + "/timelines.sav"))
        {
            BinaryFormatter Bf = new BinaryFormatter();
            FileStream Stream = new FileStream(Application.persistentDataPath + "/timelines.sav", FileMode.Open);
            PlayerData data = Bf.Deserialize(Stream) as PlayerData;
            for(int i =0; i<data.stages.Length; i++)
            {
                Debug.Log(data.stages[i].roomName);
             }
            
            Stream.Close();
                }
         else
        {
            Debug.Log("no file");
       
         }
     }
    [Serializable]
    public class PlayerData
    {

         public rooms[] stages;
         public unitStats[] playersStats;
         public PlayerData(PlayerMemory player)
        {
              stages = new rooms[player.stage.Count];
             playersStats = new unitStats[player.Partty.Count];
   for(int i = 0; i > player.stage.Count; i++)
            {
                stages[i] = player.stage[i];
            }
            for (int i = 0; i > player.Partty.Count; i++)
            {
                playersStats[i] = player.Partty[i];
            }
            Debug.Log(stages.Length);
        }
    }


}
