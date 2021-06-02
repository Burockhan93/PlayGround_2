using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    SnakeInventory inventory;

    ItemSlot main;
    ItemSlot prev;
    ItemSlot next;

    
    // Start is called before the first frame update
    void Start()
    {
        
        main = gameObject.transform.GetChild(0).GetComponent<ItemSlot>();
        prev = gameObject.transform.GetChild(1).GetComponent<ItemSlot>();
        next = gameObject.transform.GetChild(2).GetComponent<ItemSlot>();

        inventory = FindObjectOfType<SnakeInventory>();
        inventory.onInventoryAdd += InventoryAdd;
        inventory.onInventoryRemove += InventoryRemove;
        inventory.onInventoryChange += InventoryChange;


    }
    void InventoryAdd(Item item)
    {
        Debug.Log("Buraya geldin");
        main.icon.color = new Color(255, 255, 255, 1);

        if (main.icon.sprite == null)
        {
            main.icon.sprite = item.icon;
            return;
        }
        else if (next.icon.sprite == null)
        {
            next.icon.sprite = item.icon;
            next.icon.color = new Color(255, 255, 255, 0.5f);
            return;
        }
        return;

    }
    void InventoryChange(Item item, Item itemnext, Item itemprev)
    {
        if (item.icon)
        {
            main.icon.sprite = item.icon;
            main.icon.color = new Color(255, 255, 255, 1f);
        }
        else
        {
            main.icon.sprite = null;
            main.icon.color = new Color(255, 255, 255, 0f);
        }
        

        if (itemnext.icon)
        {
            next.icon.sprite = itemnext.icon;
            next.icon.color = new Color(255, 255, 255, 0.5f);
        }
        else
        {
            next.icon.sprite = null;
            next.icon.color = new Color(255, 255, 255, 0f);
        }
        
        if (itemprev.icon)
        {
            prev.icon.sprite = itemprev.icon;
            prev.icon.color = new Color(255, 255, 255, 0.5f);
        }
        else
        {
            prev.icon.sprite = null;
            prev.icon.color = new Color(255, 255, 255, 0f);
        }
        
  
    }
    void InventoryRemove(Item item)
    {
        main.icon.sprite = null;
        main.icon.color = new Color(255, 255, 255, 0);

    }
}
