using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//被序列化
[System.Serializable]
public class ItemsData 
{
    public GameObject itemPrefab;
    public int itemConst=10;
    public int effect;
    public ItemType type;
}
public enum ItemType
{
    Apple,
    Orange
}
