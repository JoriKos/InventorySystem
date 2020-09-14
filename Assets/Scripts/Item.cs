using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private GameObject itemPrefab;
    private Sprite inventorySprite;
    private enum ItemTypes
    {
        Cube,
        Cylinder,
        Sphere,
        Capsule
    }
}
