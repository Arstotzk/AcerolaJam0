using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //TODO: Rework that shi...
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
        int? emptySlot = null;
        for (int slot = 4; slot >= 1; slot--)
        {
            Item itemSlot = null;
            switch (slot)
            {
                case 1:
                    itemSlot = item1;
                    break;
                case 2:
                    itemSlot = item2;
                    break;
                case 3:
                    itemSlot = item3;
                    break;
                case 4:
                    itemSlot = item4;
                    break;
                default:
                    Debug.LogError("Inventory PickUpItem slot: " + slot);
                    break;
            }
            if (itemSlot == null)
                emptySlot = slot;
        }
        if (emptySlot.HasValue == false)
            return;

        switch (emptySlot.Value)
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
                Debug.LogError("Inventory PickUpItem: " + emptySlot.Value);
                break;
        }
        currentItemSlot = emptySlot.Value;
        chosenItem.SetItem(item);
        GetComponent<InventoryUI>().RedrawInventory();
    }

    public void RemoveItem(Item item)
    {
        if (item.Equals(item1))
            item1 = null;
        if (item.Equals(item2))
            item2 = null;
        if (item.Equals(item3))
            item3 = null;
        if (item.Equals(item4))
            item4 = null;
        GetComponent<InventoryUI>().RedrawInventory();
    }
    public void ReverseGravity()
    {
        if (item1 != null)
            item1.GetComponent<Gravity>().ReverseGravity();
        if (item2 != null)
            item2.GetComponent<Gravity>().ReverseGravity();
        if (item3 != null)
            item3.GetComponent<Gravity>().ReverseGravity();
        if (item4 != null)
            item4.GetComponent<Gravity>().ReverseGravity();
    }
}
