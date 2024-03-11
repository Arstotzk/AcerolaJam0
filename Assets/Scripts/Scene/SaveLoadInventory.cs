using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadInventory : MonoBehaviour
{
    // Start is called before the first frame update
    private string item1 = "item1";
    private string item2 = "item2";
    private string item3 = "item3";
    private string item4 = "item4";
    private string slot = "slot";

    public GameObject flashlight;
    public GameObject lamp;
    public GameObject rock;
    public GameObject gravityRock;

    public Inventory inventory;

    public bool isSaveDebug = false;
    public bool isLoadDebug = false;

    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSaveDebug)
        {
            Save();
            isSaveDebug = false;
        }

        if (isLoadDebug)
        {
            Load();
            isLoadDebug = false;
        }
    }

    public void Save()
    {
        if (inventory.item1 != null)
            PlayerPrefs.SetString(item1, inventory.item1.saveName);
        else
            PlayerPrefs.SetString(item1, "null");
        if (inventory.item2 != null)
            PlayerPrefs.SetString(item2, inventory.item2.saveName);
        else
            PlayerPrefs.SetString(item2, "null");
        if (inventory.item3 != null)
            PlayerPrefs.SetString(item3, inventory.item3.saveName);
        else
            PlayerPrefs.SetString(item3, "null");
        if (inventory.item4 != null)
            PlayerPrefs.SetString(item4, inventory.item4.saveName);
        else
            PlayerPrefs.SetString(item4, "null");

        PlayerPrefs.SetInt(slot, inventory.currentItemSlot);
    }
    public void Load()
    {
        var itemLoad1 = GetItem(PlayerPrefs.GetString(item1));
        if (itemLoad1 != null)
            inventory.PickUpItem(Instantiate(itemLoad1).GetComponent<Item>());
        var itemLoad2 = GetItem(PlayerPrefs.GetString(item2));
        if (itemLoad2 != null)
            inventory.PickUpItem(Instantiate(itemLoad2).GetComponent<Item>());
        var itemLoad3 = GetItem(PlayerPrefs.GetString(item3));
        if (itemLoad3 != null)
            inventory.PickUpItem(Instantiate(itemLoad3).GetComponent<Item>());
        var itemLoad4 = GetItem(PlayerPrefs.GetString(item4));
        if (itemLoad4 != null)
            inventory.PickUpItem(Instantiate(itemLoad4).GetComponent<Item>());

        inventory.currentItemSlot = PlayerPrefs.GetInt(slot);
    }

    private GameObject GetItem(string itemName) 
    {
        switch (itemName)
        {
            case "flashlight":
                return flashlight;
                break;
            case "lamp":
                return lamp;
                break;
            case "rock":
                return rock;
                break;
            case "gravityRock":
                return gravityRock;
                break;
        }
        return null;
    }
}
