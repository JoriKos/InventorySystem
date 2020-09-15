using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;
    private Rigidbody player_rb;
    private float speed = 15f;
    private Item touchedItem;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(-Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "CollectableObject")
        {
            touchedItem = collision.gameObject.GetComponent<Item>();
            touchedItem.AssignItemType(touchedItem.GetItemPrefabName());
            inventory.AddItem(touchedItem);
            Destroy(collision.gameObject);
            Debug.Log(inventory.GetInvIndex(1));
        }
    }
}