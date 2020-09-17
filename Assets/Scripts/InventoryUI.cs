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
    private GameObject player;
    private int selectedSlot;

    private void Awake()
    {
        player = GameObject.Find("Player");
        inventory = player.GetComponent<Inventory>();
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
        
        selectedSpriteOverlayObject.transform.position = inventoryUI[selectedSlot].transform.position; //Selectoverlay always renders correctly

        if (Input.GetMouseButtonUp(0))
        {
            if (inventory.GetInvIndex(selectedSlot) != null)
            {
                Instantiate(inventory.GetInvIndex(selectedSlot).GetItemPrefab(), new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 5), Quaternion.identity);
                inventory.UseItem(selectedSlot);
                inventoryUI[selectedSlot].sprite = unselectedSlotSprite;
            }
            else
            {
                Debug.Log("Can't do that!");
            }
        }
    }

    public void UpdateInventory(Item anItem) //anItem is determined by Player.cs
    {
        if (inventory.GetInvIndex(selectedSlot) == null) //If the currently selected inventory slot is empty, it will go in there
        {
            inventory.AddItem(anItem);
            inventoryUI[selectedSlot].sprite = anItem.GetInventorySprite();
        }
        else //If not, it will determine the next empty slot
        {
            for (int i = 0; i < 4; i++)
            {
                if (inventory.GetInvIndex(i) == null && i != selectedSlot)
                {
                    inventory.AddItem(anItem);
                    inventoryUI[i].sprite = anItem.GetInventorySprite();
                    break;
                }
            }
        }
    }
}