using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public enum ItemId
    {
        flashlight,
        key
    }
    public GameObject itemObject;

    public ItemId itemId;

}
