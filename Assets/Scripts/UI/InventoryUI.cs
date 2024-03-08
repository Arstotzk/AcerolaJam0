using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Image item1;
    public Image item2;
    public Image item3;
    public Image item4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RedrawInventory()
    {
        var inventory = GetComponent<Inventory>();
        if (inventory != null)
        {
            if (inventory.item1 != null)
            {
                item1.color = new Color(1, 1, 1, 0.8f);
                item1.sprite = inventory.item1.itemImage;
            }
            else
                SetItemNull(item1);

            if (inventory.item2 != null)
            {
                item2.color = new Color(1, 1, 1, 0.8f);
                item2.sprite = inventory.item2.itemImage;
            }
            else
                SetItemNull(item2);

            if (inventory.item3 != null)
            {
                item3.color = new Color(1, 1, 1, 0.8f);
                item3.sprite = inventory.item3.itemImage;
            }
            else
                SetItemNull(item3);

            if (inventory.item4 != null)
            {
                item4.color = new Color(1, 1, 1, 0.8f);
                item4.sprite = inventory.item4.itemImage;
            }
            else
                SetItemNull(item4);
        }
    }
    private void SetItemNull(Image item)
    {
        item.color = new Color(1, 1, 1, 0);
        item = null;
    }
}
