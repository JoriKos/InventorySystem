using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Item[] inventory = new Item[4];

    public Item GetInvIndex(int index)
    {
        return inventory[index];
    }

    public void AddItem(Item itemToAdd, int preferredIndex = 0)
    {
        if (inventory[preferredIndex] == null)
        {
            inventory[preferredIndex] = itemToAdd;
        }
        else
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
    public void UseItem(int index)
    {
        inventory[index] = null;
    }
}