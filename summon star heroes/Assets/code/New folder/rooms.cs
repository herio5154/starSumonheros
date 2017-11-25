 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class rooms

{
    public string roomName;
    public float monstersInTheRoom;
    public int stagecomplated;
    public bool[] BossBattles;
    public bool roomloaded;
    public roleOutcome Bossfight;
    public List<roomPuzles> puzzles = new List<roomPuzles>();

}
