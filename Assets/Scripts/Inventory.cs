using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Item[] inventory = new Item[4];

    public Item GetInvIndex(int index)
    {
        return inventory[index];
    }

    public void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                 inventory[i] = itemToAdd;
                break;
            }
        }
    }
}