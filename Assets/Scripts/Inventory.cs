using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private Item[] inventory = new Item[5];






    public void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                itemToAdd = inventory[i];
                break;
            }
        }
    }
}