using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Items


{
    public enum food {HP,MP,HPandMP }
    public enum inventory { Key , Equip, Food,Books,Atack, potion};
    public string ItemName;
    public weponKind weponKind;
    public inventory IteamKind;
    public food foodkind;
    public equipped EquipKind;
    public Sprite IteamPick;
    public targetKind Target;
    public majic[] itemStrengthWeekness;
    public string Description;
    public string IteamAction;
    public int []ItemNumber;
    public int Amount;
    [Tooltip("0max helth 1max mana 2attkc 3deff ,4speed 5macjic")]
    public float [] stats;
    public int value;
    public string MoveTOlurnName;
}
