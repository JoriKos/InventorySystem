using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Item : ItemTypes
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Sprite inventorySprite;
    [SerializeField] private ItemTypes itemType;

    public string GetItemPrefabName()
    {
        return itemPrefab.name;
    }

    public void AssignItemType(string enumParse)
    {
        itemType = (ItemTypes)Enum.Parse(typeof(ItemTypes), enumParse);
    }

    public ItemTypes GetItemType()
    {
        return itemType;
    }
}
