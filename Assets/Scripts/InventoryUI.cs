using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Image[] inventoryUI = new Image[4];
    [SerializeField] private Sprite unselectedSlotSprite;
    private GameObject selectedSpriteOverlayObject;
    private Sprite selectedSlotSprite;
    private Inventory inventory;
    private int selectedSlot;

    private void Awake()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        selectedSpriteOverlayObject = GameObject.Find("OverlayGameObject");
        selectedSlotSprite = selectedSpriteOverlayObject.GetComponent<Sprite>();
        selectedSlot = 0;
        selectedSpriteOverlayObject.transform.position = inventoryUI[selectedSlot].transform.position;
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) //up
        {
            selectedSlot++;
            if (selectedSlot >= 4) //Resets to previous slot
            {
                selectedSlot = 0;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) //down
        {
            selectedSlot--;
            if (selectedSlot <= -1)
            {
                selectedSlot = 3;
            }
        }
        
        selectedSpriteOverlayObject.transform.position = inventoryUI[selectedSlot].transform.position;
    }

    public void UpdateInventory(Item anItem)
    {
        if (inventory.GetInvIndex(selectedSlot) == null)
        {
            inventoryUI[selectedSlot].sprite = anItem.GetInventorySprite();
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (i != selectedSlot && inventory.GetInvIndex(i) != null)
                {
                    inventoryUI[i].sprite = unselectedSlotSprite;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (i != selectedSlot && inventory.GetInvIndex(i) != null)
                {
                    inventoryUI[i].sprite = anItem.GetInventorySprite();
                    break;
                }
            }
        }
    }
}
