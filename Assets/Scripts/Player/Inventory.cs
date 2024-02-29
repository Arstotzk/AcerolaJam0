using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item item1;
    public Item item2;
    public Item item3;
    public Item item4;

    public int _currentItemSlot;
    public int currentItemSlot
    {
        get => _currentItemSlot;
        set
        {
            var previosItem = GetChosenItem();
            if (previosItem != null)
                previosItem.gameObject.SetActive(false);
            _currentItemSlot = value;
            var item = GetChosenItem();
            if (item != null)
                item.gameObject.SetActive(true);
        }
    }

    public ChosenItem chosenItem;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Item1"))
        {
            currentItemSlot = 1;
        }
        if (Input.GetButtonDown("Item2"))
        {
            currentItemSlot = 2;
        }
        if (Input.GetButtonDown("Item3"))
        {
            currentItemSlot = 3;
        }
        if (Input.GetButtonDown("Item4"))
        {
            currentItemSlot = 4;
        }

    }

    public Item GetChosenItem()
    {
        Item item = null;
        switch (currentItemSlot)
        {
            case 1:
                item = item1;
                break;
            case 2:
                item = item2;
                break;
            case 3:
                item = item3;
                break;
            case 4:
                item = item4;
                break;
            default:
                Debug.LogError("Inventory chosenItem: " + currentItemSlot);
                break;
        }
        return item;
    }

    public void PickUpItem(Item item)
    {
        switch (currentItemSlot)
        {
            case 1:
                item1 = item;
                break;
            case 2:
                item2 = item;
                break;
            case 3:
                item3 = item;
                break;
            case 4:
                item4 = item;
                break;
            default:
                Debug.LogError("Inventory PickUpItem: " + currentItemSlot);
                break;
        }
        chosenItem.SetItem(item);
    }
}
