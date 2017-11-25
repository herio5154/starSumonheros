using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]


public class Levelup
{
    public string SkillName;
    public int  levelReqired;
    public List<AtackList> skill = new List<AtackList>();

}
