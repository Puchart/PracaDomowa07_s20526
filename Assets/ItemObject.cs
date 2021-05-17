using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item item;
    private bool isCollision;
    private inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        isCollision = false;
        GameObject inventoryOBJ = GameObject.Find("InventoryOBJ");
        inventory = inventoryOBJ.GetComponent<inventory>();

        GetComponent<SpriteRenderer>().sprite = item.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isCollision)
        {
           if (inventory.PickUp(item))
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollision = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollision = false;
        }
    }
}
