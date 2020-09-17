using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Item : ItemTypes
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Sprite inventoryImage;
    private TypeOfItems itemType;
    private bool isDefined;

    public string GetItemPrefabName()
    {
        return itemPrefab.name;
    }
    public GameObject GetItemPrefab()
    {
        return itemPrefab;
    }

    public void AssignItemType(string enumParse)
    {
        switch (Enum.IsDefined(typeof(TypeOfItems), enumParse)) //Checks whether or not the given name is in ItemTypes
        {
            case true:
                this.itemType = (TypeOfItems)Enum.Parse(typeof(TypeOfItems), enumParse); //Converts string to enum
                break;
            case false:
                Debug.Log("Critical error: itemType does not exist!");
                break;
        }
    }

    public Sprite GetInventorySprite()
    {
        return inventoryImage;
    }

    public TypeOfItems GetItemType()
    {
        return itemType;
    }
}
