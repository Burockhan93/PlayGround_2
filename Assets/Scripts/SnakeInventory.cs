using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SnakeInventory : MonoBehaviour
{
    private List<Item> items = new List<Item>();
    private SnakeInput _snakeInput;
    public Item currentItem{ get; private set; }
    private Item prevItem;
    private Item nextItem;
    private int indexer = 0;

    public delegate void OnInventoryAdd(Item item);
    public OnInventoryAdd onInventoryAdd;
    public delegate void OnInventoryRemove(Item item);
    public OnInventoryRemove onInventoryRemove;
    public delegate void OnInventoryChanged(Item item, Item itemnext, Item itemprev);
    public OnInventoryChanged onInventoryChange;

    public event Action<float> onScrollEvent;
    public event Action onDropEvent;

    private int _limit = 4;
    // Start is called before the first frame update
    private void Start()
    {
        
        currentItem = ScriptableObject.CreateInstance<Item>();
        prevItem = ScriptableObject.CreateInstance<Item>();
        nextItem  = ScriptableObject.CreateInstance<Item>();

        _snakeInput = GetComponent<SnakeInput>();
        onScrollEvent += Scroll;
        onDropEvent += Remove;
    }

    private void Update()
    {       
        doesScroll();
        didDrop();
    }
    void didDrop()
    {
        if (_snakeInput.dropInput && currentItem !=null)
        {
            onDropEvent?.Invoke();
        }
    }

    void doesScroll()
    {
        if (_snakeInput.scrollInput < 0.1f && _snakeInput.scrollInput > -0.1) return;

        onScrollEvent?.Invoke(_snakeInput.scrollInput);
    }
    public bool Add (Item item)
    { 

        if (items.Count >= _limit || items.Contains(item))
        {
            return false;
        }

        items.Add(item);

        if (currentItem.icon == null)
        {
            currentItem = item;
        }
        else if (nextItem.icon==null)
        {
            nextItem = item;
        }
        

        onInventoryAdd?.Invoke(item);
        onInventoryChange?.Invoke(currentItem, nextItem, prevItem);
        return true;
    }

    public void Remove()
    {
        if (currentItem != null)
        {
            items.Remove(currentItem);
            currentItem = ScriptableObject.CreateInstance<Item>();
            onInventoryChange.Invoke(currentItem,nextItem,prevItem);
            Debug.Log(currentItem.icon);
        }
        
        
        
    }
    void Scroll(float f)
    {        

        if (items.Count == 0 )
        {
            return;

        }else if( items.Count == 1)
        {
            indexer = 0;
            currentItem = items[indexer];
            onInventoryChange?.Invoke(currentItem,nextItem,prevItem);
        }
        if (f > 0 && indexer < items.Count - 1)
        {
            
            indexer++;
            prevItem = items[indexer - 1];

            currentItem = items[indexer];
            

            if (indexer == items.Count - 1)
            {
                nextItem = ScriptableObject.CreateInstance<Item>() ;
            }
            else
            {
                nextItem = items[indexer + 1];
            }
            
            
            Debug.Log(indexer);

            onInventoryChange?.Invoke(currentItem,nextItem,prevItem);
        }
        else if (f < 0 && indexer > 0)
        {
            indexer--;
            
            if (indexer >= items.Count-1)
            {
                nextItem = ScriptableObject.CreateInstance<Item>();
            }
            else
            {
                nextItem = items[indexer +1];
            }

            currentItem = items[indexer];

            if (indexer == 0)
            {
                prevItem = ScriptableObject.CreateInstance<Item>();
            }
            else
            {
                prevItem = items[indexer - 1] ;
            }

            Debug.Log(indexer);

            onInventoryChange?.Invoke(currentItem, nextItem, prevItem);
        }
        
    }

    
}
